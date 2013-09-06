using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGCellBar.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBarViewModel : IViewModel<IBarCellView>, IBarViewModelBase
	{
        /// <summary>
        /// Gets the add command.
        /// </summary>
		ICommand AddCommand { get; }

        /// <summary>
        /// Gets or sets the views.
        /// </summary>
        ObservableCollection<IBarViewModelBase> Views { get; set; }

        /// <summary>
        /// Gets the next command.
        /// </summary>
		ICommand NextCommand { get; }

	    /// <summary>
	    /// Gets the previous command.
	    /// </summary>
	    ICommand PreviousCommand { get; }
	}


    /// <summary>
    /// 
    /// </summary>
    public interface IBarViewModelTwo : IBarViewModel
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IBarViewModelBase
    {
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        string Header { get; set; }
    }
}

