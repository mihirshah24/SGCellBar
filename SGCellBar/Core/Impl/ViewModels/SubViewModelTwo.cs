using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels.Common;
using SGCellBar.Core.Interfaces.Views;

namespace SGCellBar.Core.Impl.ViewModels
{
    public class SubViewModelTwo : MvxViewModel, ISubViewModelTwo
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public ISubViewTwo View { get; set; }

        public ISGFactory Factory { get; set; }

        IMvxView IViewModel.View
        {
            get { return View; }
            set { View = (ISubViewTwo)value; }
        }
    }
}
