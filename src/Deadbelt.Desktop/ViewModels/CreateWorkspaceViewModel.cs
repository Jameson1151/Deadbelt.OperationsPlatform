using System.IO;
using System.Windows.Input;
using Deadbelt.Desktop.MVVM;
using Microsoft.Win32;

namespace Deadbelt.Desktop.ViewModels;

public sealed class CreateWorkspaceViewModel : ViewModelBase
{
    private string _workspaceName = string.Empty;
    private string _folderPath = string.Empty;
    private string? _description;
    private string _validationMessage = "Workspace name is required.";

    public CreateWorkspaceViewModel()
    {
        BrowseCommand = new RelayCommand(BrowseForFolder);
        CreateCommand = new RelayCommand(
            execute: () => { },
            canExecute: CanCreate);
    }

    public string WorkspaceName
    {
        get => _workspaceName;
        set
        {
            if (SetProperty(ref _workspaceName, value))
                Validate();
        }
    }

    public string FolderPath
    {
        get => _folderPath;
        set
        {
            if (SetProperty(ref _folderPath, value))
                Validate();
        }
    }

    public string? Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public string ValidationMessage
    {
        get => _validationMessage;
        private set => SetProperty(ref _validationMessage, value);
    }

    public ICommand BrowseCommand { get; }

    public RelayCommand CreateCommand { get; }

    public bool IsValid()
    {
        Validate();
        return string.IsNullOrWhiteSpace(ValidationMessage);
    }

    private bool CanCreate()
    {
        return !string.IsNullOrWhiteSpace(WorkspaceName)
            && IsValidFolderPath(FolderPath);
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(WorkspaceName))
        {
            ValidationMessage = "Workspace name is required.";
            CreateCommand.RaiseCanExecuteChanged();
            return;
        }

        if (string.IsNullOrWhiteSpace(FolderPath))
        {
            ValidationMessage = "Workspace folder is required.";
            CreateCommand.RaiseCanExecuteChanged();
            return;
        }

        if (!IsValidFolderPath(FolderPath))
        {
            ValidationMessage = "Workspace folder must be a valid full path.";
            CreateCommand.RaiseCanExecuteChanged();
            return;
        }

        ValidationMessage = string.Empty;
        CreateCommand.RaiseCanExecuteChanged();
    }

    private void BrowseForFolder()
    {
        var dialog = new OpenFolderDialog
        {
            Title = "Select Workspace Folder"
        };

        if (dialog.ShowDialog() == true)
        {
            FolderPath = dialog.FolderName;
        }
    }

    private static bool IsValidFolderPath(string folderPath)
    {
        if (string.IsNullOrWhiteSpace(folderPath))
            return false;

        try
        {
            var trimmedPath = folderPath.Trim();

            if (!Path.IsPathFullyQualified(trimmedPath))
                return false;

            var root = Path.GetPathRoot(trimmedPath);

            if (string.IsNullOrWhiteSpace(root))
                return false;

            if (!Directory.Exists(root))
                return false;

            var invalidPathChars = Path.GetInvalidPathChars();

            return trimmedPath.IndexOfAny(invalidPathChars) < 0;
        }
        catch
        {
            return false;
        }
    }
}
