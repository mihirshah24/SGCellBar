using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels.Common;
using SGCellBar.Core.Interfaces.Views;

namespace SGCellBar.Core.Impl.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class BarHolderViewModel : MvxViewModel//, IBarHolderViewModel
	{
		private ObservableCollection<IBarViewModel> _bars = new ObservableCollection<IBarViewModel>();

        private bool _isRightButtonEnabled;
        private bool _isLeftButtonEnabled;
        private bool _isAddBarClicked;


        public virtual IBarHolderView View { get; set; }
        public virtual ISGFactory Factory { get; set; }
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

        public IBarViewModel Initialize()
        {
            //_bars.Add(new BarViewModel { Header = "Default", Factory = Factory});
            //_bars.Add(
              //  Factory.Create<IBarViewModel, IBarCellView>());
			return Factory.Create<IBarViewModel, IBarCellView> ();
        }
        private void DoAddBar()
        {
        }

	}
}

