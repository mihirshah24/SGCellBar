using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGCellBar.Core.ViewModels
{
    public interface IBarViewModel : IBarviewModelBase
	{
		ICommand AddCommand { get; }
        ObservableCollection<IBarviewModelBase> Views { get; set; }
		ICommand NextCommand { get; }

	    /// <summary>
	    /// Gets the previous command.
	    /// </summary>
	    ICommand PreviousCommand { get; }
	}

    public interface IBarviewModelBase
    {
        string Header { get; set; }
    }
}

