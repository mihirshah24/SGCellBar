using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels.Common;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.Core.Impl.ViewModels
{
	public class BarViewModel : MvxViewModel, IBarViewModel
	{
        private ObservableCollection<IViewModel> _barViews = 
            new ObservableCollection<IViewModel>();
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

        public ISGFactory Factory { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public IBarCellView View { get; set; }

        IMvxView IViewModel.View
        {
            get { return View; }
            set { View = (IBarCellView)value; }
        }

	    public ICommand AddCommand
	    {
            get { return new MvxCommand(AddBar); }
	    }
        

	    /// <summary>
        /// Gets or sets the views.
        /// </summary>
        public ObservableCollection<IViewModel> Views
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

	    public virtual void AddBarCell()
        {
            AddSubView<IBarViewModel, IBarCellView>();
	    }

	    public virtual void AddSubViewOne()
        {
            AddSubView<ISubViewModelOne, ISubViewOne>();
	    }

	    public virtual void AddSubViewTwo()
	    {
            AddSubView<ISubViewModelTwo, ISubViewTwo>();
	    }

		private void AddSubView<TVM, TV>()
			where TV : class, IView<TVM>
				where TVM : class, IViewModel<TV>, IMvxViewModel
        {
            var viewModel = Factory.Create<TVM, TV>();
            if (viewModel == null) return;
            var view = viewModel.View;
            View.AddSubView(view);
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
