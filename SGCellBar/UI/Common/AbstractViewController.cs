using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.Foundation;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.UI.Common
{
    public abstract class AbstractViewController<TVm, TVmi> : MvxViewController, IView<TVm>
        where TVm : class, IMvxViewModel
        where TVmi : class, TVm
    {

        protected AbstractViewController(string nibName, NSBundle bundle)
            : base(nibName, bundle)
		{
		}

        public virtual TVm MyViewModel
        {
            get { return (TVm) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public new TVmi ViewModel
        {
            get { return (TVmi)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public virtual void AddSubView(IView subView)
        {
            
        }
    }
}
