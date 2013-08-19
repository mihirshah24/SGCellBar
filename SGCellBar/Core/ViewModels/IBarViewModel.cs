using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGCellBar.Core.ViewModels
{
	public interface IBarViewModel
	{
		string Header { get; set;}
		ObservableCollection<BarCollectionViewModel> Views { get; set;}
		ICommand NextCommand { get; }

	    /// <summary>
	    /// Gets the previous command.
	    /// </summary>
	    ICommand PreviousCommand { get; }
	}
}

