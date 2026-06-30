using System.Windows;
using System.Windows.Input;
using Deadbelt.Application.Workspaces;
using Deadbelt.Desktop.MVVM;
using Deadbelt.Desktop.Services;

namespace Deadbelt.Desktop.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly IWorkspaceService _workspaceService;
    private readonly IWorkspaceDialogService _workspaceDialogService;

    private string _workspaceStatus = "Workspace: None";
    private string _welcomeMessage = "No workspace is currently open.";
    private string _statusMessage = "Ready";

    public MainWindowViewModel(
        IWorkspaceService workspaceService,
        IWorkspaceDialogService workspaceDialogService)
    {
        _workspaceService = workspaceService;
        _workspaceDialogService = workspaceDialogService;

        CreateWorkspaceCommand = new AsyncRelayCommand(CreateWorkspaceAsync);
        OpenWorkspaceCommand = new RelayCommand(OpenWorkspace);
    }

    public string ApplicationName => "DEADBELT";

    public string ApplicationSubtitle => "Operations Platform";

    public string WorkspaceStatus
    {
        get => _workspaceStatus;
        private set => SetProperty(ref _workspaceStatus, value);
    }

    public string WelcomeMessage
    {
        get => _welcomeMessage;
        private set => SetProperty(ref _welcomeMessage, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        private set => SetProperty(ref _statusMessage, value);
    }

    public ICommand CreateWorkspaceCommand { get; }

    public ICommand OpenWorkspaceCommand { get; }

    private async Task CreateWorkspaceAsync()
    {
        var dialogResult = _workspaceDialogService.ShowCreateWorkspaceDialog();

        if (!dialogResult.Confirmed)
        {
            StatusMessage = "Workspace creation cancelled.";
            return;
        }

        StatusMessage = "Creating workspace...";

        var result = await _workspaceService.CreateWorkspaceAsync(
            new CreateWorkspaceRequest
            {
                Name = dialogResult.Name,
                FolderPath = dialogResult.FolderPath,
                Description = dialogResult.Description
            });

        if (!result.Succeeded || result.Workspace is null)
        {
            StatusMessage = "Failed to create workspace.";

            MessageBox.Show(
                result.ErrorMessage ?? "Failed to create workspace.",
                "Deadbelt",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            return;
        }

        WorkspaceStatus = $"Workspace: {result.Workspace.Name}";
        WelcomeMessage = $"Active workspace location: {result.Workspace.Path}";
        StatusMessage = "Workspace created.";
    }

    private static void OpenWorkspace()
    {
        MessageBox.Show(
            "Open Workspace is not implemented yet.",
            "Deadbelt",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}