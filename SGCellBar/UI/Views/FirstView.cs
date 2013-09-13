using System.Drawing;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SGCellBar.Core.ViewModels;
using SGCellBar.UI.Common;
using SGCellBar.UI.Views.Cells;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.UIKit;

namespace SGCellBar.UI.Views
{
    /// <summary>
    /// 
    /// </summary>
    [Register("FirstView")]
    public class FirstView : MvxCollectionViewController
    {
        private readonly bool _isInitialised;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstView"/> class.
        /// </summary>
        public FirstView(): base(new UICollectionViewFlowLayout
            {
                ItemSize = new SizeF(320, 340),
                ScrollDirection = UICollectionViewScrollDirection.Vertical
            })
        {
            _isInitialised = true;
            ViewDidLoad();
        }


        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public new BarHolderViewModel ViewModel
        {
            get { return (BarHolderViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public sealed override void ViewDidLoad()
        {
            if (!_isInitialised)
                return;

            base.ViewDidLoad();

            CollectionView.RegisterNibForCell(BarCell.Nib, BarCell.Key);
            var source = new MvxCollectionViewSource(CollectionView, BarCell.Key);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<FirstView, BarHolderViewModel>();
            set.Bind(source).To(vm => vm.Bars);
            set.Apply();

            CollectionView.ReloadData();

            SGFactory.Request = this.Request;

        }
    }
}
