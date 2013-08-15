using Cirrious.MvvmCross.ViewModels;

namespace SGCellBar.Core.ViewModels
{
	public class BarCollectionViewModel : MvxViewModel
	{
		private string _header;
		public string Header
		{
			get { return _header; }
			set
			{
				_header = value;
				RaisePropertyChanged(() => Header);
			}
		}
	}
}

