using Cirrious.MvvmCross.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.Views;

namespace SGCellBar.Core.Impl.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class BarCollectionViewModel : MvxViewModel, IBarCollectionViewModel
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

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public IBarCollectionCellView View { get; set; }
	}
}

