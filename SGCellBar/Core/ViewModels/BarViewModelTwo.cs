using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace SGCellBar.Core.ViewModels
{
    public class BarViewModelTwo : MvxViewModel, IBarViewModel
    {
        private int i;
        private ObservableCollection<IBarviewModelBase> _barViews = new ObservableCollection<IBarviewModelBase>();
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

        public ICommand AddCommand
        {
            get { return new MvxCommand(AddBar); }
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
                //barViewModel.Views.Add(new BarCollectionViewModel { Header = "View 4" });
                Views.Add(barViewModel);
            }

            ++i;
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
