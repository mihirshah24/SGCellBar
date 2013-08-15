using System.Collections.ObjectModel;

namespace SGCellBar.Core.ViewModels
{
	public interface IBarViewModel
	{
		string Header { get; set;}
		ObservableCollection<BarCollectionViewModel> Views { get; set;}
	}
}

