using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace SGCellBar.Core.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class BarHolderViewModel : MvxViewModel
	{
		private ObservableCollection<IBarViewModel> _bars = new ObservableCollection<IBarViewModel> {
			new BarViewModel { Header = "Default",
            }
		};

        private int _currentBarIndex;
        private bool _isRightButtonEnabled;
        private bool _isLeftButtonEnabled;
        private bool _isAddBarClicked;
		int i = 0;


        /// <summary>
        /// Gets or sets the bars.
        /// </summary>
		public ObservableCollection<IBarViewModel> Bars
        {
            get { return _bars; }
            set
            {
                _bars = value; 
                RaisePropertyChanged(() => Bars);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is add bar clicked.
        /// </summary>
        public bool IsAddBarClicked
        {
            get { return _isAddBarClicked; }
            set
            {
                _isAddBarClicked = value;
                RaisePropertyChanged(() => IsAddBarClicked);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is left button enabled.
        /// </summary>
        public bool IsLeftButtonEnabled
        {
            get { return _isLeftButtonEnabled; }
            set
            {
                _isLeftButtonEnabled = value;
                RaisePropertyChanged(() => IsLeftButtonEnabled);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is right button enabled.
        /// </summary>
        public bool IsRightButtonEnabled
        {
            get { return _isRightButtonEnabled; }
            set
            {
                _isRightButtonEnabled = value;
                RaisePropertyChanged(() => IsRightButtonEnabled);
            }
        }

        /// <summary>
        /// Gets the add bar command.
        /// </summary>
        public ICommand AddBarCommand
        {
            get { return new MvxCommand(DoAddBar); }
        }

        private void DoAddBar()
        {
            IsAddBarClicked = true;
			string headerText = "Default";

            IBarViewModel barViewModel = null;
			switch (i)
			{
			    case 0: 
				    headerText = "Home";
                    barViewModel = new BarViewModel { Header = headerText };
				    break;
			    case 1:
				    headerText = "Inbox";
                    barViewModel = new BarViewModelTwo { Header = headerText };
				    break;
			    case 2:
				    headerText = "Itemized Bill";
                    barViewModel = new BarViewModel { Header = headerText };
				    break;
			    case 3: 
				    headerText = "Description";
                    barViewModel = new BarViewModelTwo { Header = headerText };
			        break;
			}

            if (barViewModel != null)
            {
                barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 1" });
                barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 2" });
                barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 3" });
                barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 4" });
                Bars.Add(barViewModel);
            }
			
			++i;
        }
	}
}

