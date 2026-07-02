using System.Windows;
using Deadbelt.Desktop.ViewModels;
using Deadbelt.Desktop.Views;

namespace Deadbelt.Desktop.Services;

public sealed class EnvironmentDialogService : IEnvironmentDialogService
{
    public EnvironmentDialogResult ShowCreateEnvironmentDialog(Window owner)
    {
        var viewModel = new CreateEnvironmentViewModel();

        var window = new CreateEnvironmentWindow(viewModel)
        {
            Owner = owner
        };

        var result = window.ShowDialog();

        if (result != true)
            return EnvironmentDialogResult.Cancelled();

        return EnvironmentDialogResult.Success(
            viewModel.EnvironmentName,
            viewModel.Description,
            viewModel.SelectedGameType);
    }
}