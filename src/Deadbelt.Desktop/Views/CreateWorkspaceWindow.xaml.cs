using System.Windows;
using Deadbelt.Desktop.ViewModels;

namespace Deadbelt.Desktop.Views;

public partial class CreateWorkspaceWindow : Window
{
    private readonly CreateWorkspaceViewModel _viewModel;

    public CreateWorkspaceWindow(CreateWorkspaceViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        DataContext = viewModel;
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void Create_Click(object sender, RoutedEventArgs e)
    {
        if (!_viewModel.IsValid())
            return;

        DialogResult = true;
        Close();
    }
}