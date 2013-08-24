using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGCellBar.Core.ViewModels
{
	public class BarViewModel : MvxViewModel, IBarViewModel
	{
	    private int i = 0;
        private ObservableCollection<IBarviewModelBase> _barViews = new ObservableCollection<IBarviewModelBase>
		                                                                     {																			     
		                                                                         //new BarCollectionViewModel { Header = "View 1" },
																				 //new BarCollectionViewModel { Header = "View 2" },
		                                                                     };
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

	    public ICommand AddCommand
	    {
            get { return new MvxCommand(AddBar); }
	    }

	    

	    /// <summary>
        /// Gets or sets the views.
        /// </summary>
        public ObservableCollection<IBarviewModelBase> Views
		{
			get { return _barViews; }
			set
			{
				_barViews = value; 
				RaisePropertyChanged(() => Views);
			}
		}

		/// <summary>
		/// Gets the next command.
		/// </summary>
		public ICommand NextCommand
		{
			get { return new MvxCommand(GoToNextView); }
		}

        /// <summary>
        /// Gets the previous command.
        /// </summary>
        public ICommand PreviousCommand
        {
            get { return new MvxCommand(GoToPreviousView); }
        }

		private void GoToNextView()
		{
			RaisePropertyChanged(() => NextCommand);
		}

        private void GoToPreviousView()
        {
            RaisePropertyChanged(() => PreviousCommand);
        }

        private void AddBar()
        {
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
                //barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 2" });
                //barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 3" });
                //barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 1" });
                Views.Add(barViewModel);
            }

            ++i;
        }
    }
}
