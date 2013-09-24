using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using SGCellBar.Core.Interfaces.ViewModels.Common;

namespace SGCellBar.Core.Impl.ViewModels.Common
{
    public abstract class AbstractViewModel<TV> : MvxViewModel, IViewModel<TV>
        where TV : class, IMvxView
    {
        public ISGFactory Factory { get; set; }

        public TV MyView { get; set; }
        IMvxView IViewModel.MyView
        {
            get { return MyView; }
            set { MyView = (TV)value; }
        }
    }
}