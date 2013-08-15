using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace SGCellBar.Core.ViewModels
{
	public class BarViewModel : MvxViewModel, IBarViewModel
    {
		private ObservableCollection<BarCollectionViewModel> _barViews = new ObservableCollection<BarCollectionViewModel>();
        private string _header;

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
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
        /// Gets or sets the views.
        /// </summary>
		public ObservableCollection<BarCollectionViewModel> Views
		{
			get { return _barViews; }
			set
			{
				_barViews = value; 
				RaisePropertyChanged(() => Views);
			}
		}       
    }
}
