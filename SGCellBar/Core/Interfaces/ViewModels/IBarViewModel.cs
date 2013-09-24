using System.Collections.ObjectModel;
using System.Windows.Input;
using SGCellBar.Core.Interfaces.ViewModels.Common;
using SGCellBar.Core.Interfaces.Views;

namespace SGCellBar.Core.Interfaces.ViewModels
{
    /// <summary />
    public interface IBarViewModel : IViewModel<IBarCellView>
	{
        /// <summary>
        /// Gets the add command.
        /// </summary>
		ICommand AddCommand { get; }

        /// <summary>
        /// Gets or sets the views.
        /// </summary>
        ObservableCollection<IBaseCellViewModel> Views { get; set; }

        /// <summary>
        /// Gets the next command.
        /// </summary>
		ICommand NextCommand { get; }

	    /// <summary>
	    /// Gets the previous command.
	    /// </summary>
	    ICommand PreviousCommand { get; }

        void AddBarCell();

        void AddSubViewOne();

        void AddSubViewTwo();


	}
}

