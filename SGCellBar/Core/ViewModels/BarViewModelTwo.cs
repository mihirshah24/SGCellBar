using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace SGCellBar.Core.ViewModels
{
    public class BarViewModelTwo : MvxViewModel, IBarViewModel
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
    }
}
