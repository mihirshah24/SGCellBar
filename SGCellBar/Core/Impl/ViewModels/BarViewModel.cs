using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using SGCellBar.Core.Impl.ViewModels.Common;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels.Common;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.Core.Impl.ViewModels
{
    public class BarViewModel : AbstractViewModel<IBarCellView>, IBarViewModel
    {
		private ObservableCollection<IBaseCellViewModel> _barViews = new ObservableCollection<IBaseCellViewModel> ();

        # region Properties
	    public ICommand AddCommand
	    {
            get { return new MvxCommand(AddBarCell); }
        }
        public ICommand NextCommand
        {
            get { return new MvxCommand(GoToNextView); }
        }
        public ICommand PreviousCommand
        {
            get { return new MvxCommand(GoToPreviousView); }
        }
        public ObservableCollection<IBaseCellViewModel> Views
		{
			get { return _barViews; }
			set
			{
				_barViews = value; 
				RaisePropertyChanged(() => Views);
			}
		}
        # endregion

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

		private void AddSubView<TVm, TV>()
			where TV : class, IView<TVm>
				where TVm : class, IViewModel<TV>, IMvxViewModel
        {
            // First, create a new cell
            var cellViewModel = Factory.Create<IBaseCellViewModel, IBaseCellView>();
            Views.Add(cellViewModel);

            // Now that new cell is created, create the new vm and v
            var viewModel = Factory.Create<TVm, TV>();
            var view = viewModel.MyView;
            MyView.AddSubView(view);
	    }

	    private void GoToNextView()
		{
			RaisePropertyChanged(() => NextCommand);
		}

        private void GoToPreviousView()
        {
            RaisePropertyChanged(() => PreviousCommand);
        }
	}
}
