using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SGCellBar.Core.Interfaces;

namespace SGCellBar.Core.ViewModels
{
	public class BarViewModel : MvxViewModel, IBarViewModel
	{
	    private int i = 0;
        private ObservableCollection<IBarViewModelBase> _barViews = new ObservableCollection<IBarViewModelBase>
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

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public IBarCellView View { get; set; }

	    public ICommand AddCommand
	    {
            get { return new MvxCommand(AddBar); }
	    }

	    

	    /// <summary>
        /// Gets or sets the views.
        /// </summary>
        public ObservableCollection<IBarViewModelBase> Views
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
            //string headerText = "Default";

            //IBarViewModel barViewModel = null;
            //switch (i)
            //{
            //    case 0:
            //        headerText = "Home";
            //        barViewModel = new BarViewModel { Header = headerText };
            //        //barViewModel = App.SGFactory.Create<IBarViewModel, IBarCellView>();
            //        //barViewModel.Header = headerText;
            //        break;
            //    case 1:
            //        headerText = "Inbox";
            //        //barViewModel = Core.App.SGFactory.Create<IBarViewModelTwo, IBarCellView>();
            //        //barViewModel.Header = headerText;
            //        //barViewModel = new BarViewModelTwo { Header = headerText };
            //        break;
            //    case 2:
            //        headerText = "Itemized Bill";
            //        barViewModel = new BarViewModel { Header = headerText };
            //        break;
            //    case 3:
            //        headerText = "Description";
            //        barViewModel = new BarViewModelTwo { Header = headerText };
            //        break;
            //}

            //if (barViewModel != null)
            //{
            //    barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 1" });
            //    //barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 2" });
            //    //barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 3" });
            //    //barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 1" });
            //    Views.Add(barViewModel);
            //}

            //++i;
        }

	    
	}
}
