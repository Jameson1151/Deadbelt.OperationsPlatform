using System.Windows;

namespace Deadbelt.Desktop.Services;

public interface IEnvironmentDialogService
{
    EnvironmentDialogResult ShowCreateEnvironmentDialog(Window owner);
}