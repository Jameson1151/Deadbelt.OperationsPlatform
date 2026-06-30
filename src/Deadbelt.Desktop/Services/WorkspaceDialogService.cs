using Deadbelt.Desktop.ViewModels;
using Deadbelt.Desktop.Views;

namespace Deadbelt.Desktop.Services;

public sealed class WorkspaceDialogService : IWorkspaceDialogService
{
    public WorkspaceDialogResult ShowCreateWorkspaceDialog()
    {
        var viewModel = new CreateWorkspaceViewModel();
        var window = new CreateWorkspaceWindow(viewModel);

        var result = window.ShowDialog();

        if (result != true)
            return WorkspaceDialogResult.Cancelled();

        return WorkspaceDialogResult.Success(
            viewModel.WorkspaceName,
            viewModel.FolderPath,
            viewModel.Description);
    }
}