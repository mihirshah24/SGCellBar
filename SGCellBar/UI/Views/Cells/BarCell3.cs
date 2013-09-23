using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.ViewModels;
using System.ComponentModel;
using System.Linq;
using SGCellBar.Core.Interfaces.Views.Common;
using SGCellBar.Core;

namespace SGCellBar.UI.Views.Cells
{
	public partial class BarCell3 : MvxViewController, IBarCellView
	{
        public static readonly UINib Nib = UINib.FromName("BarCell3", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("BarCell3");

		public BarCell3 () : base ("BarCell3", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}


        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public new IBarViewModel ViewModel { get; set; }

        IMvxViewModel IMvxView.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IBarViewModel)value; }
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns><see cref="BarCell3"/></returns>
        public static BarCell3 Create()
        {
            return (BarCell3) Nib.Instantiate(null, null)[0];
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            //CollectionView.RegisterNibForCell(BarCell.Nib, BarCell.Key);
            //var source = new MvxCollectionViewSource(CollectionView, BarCell.Key);
            //CollectionView.Source = source;

            //var set = this.CreateBindingSet<BarCell, BarViewModel>();
            //set.Bind(source).To(vm => vm.Views);
            //set.Apply();

            // Disable the scrolling since we want to control it via Previous and Next button clicks.
            //CollectionView.ScrollEnabled = false;
            // With Paging enabled, each view will snap to the edges of the frame as they scroll.
            CollectionView.PagingEnabled = true;
            CollectionView.ReloadData();

        }

        private void HandleBarViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NextCommand")
            {
                GoToNextCollectionView();
                return;
            }

            if (e.PropertyName == "PreviousCommand")
            {
                GoToPreviousCollectionView();
                return;
            }
        }

        public void AddSubView(IView subView)
        {
            var mvxViewController = subView as MvxViewController;
            if (mvxViewController != null)
            {
                mvxViewController.View.ClipsToBounds = true;
                mvxViewController.View.Hidden = false;
                mvxViewController.View.Frame = new RectangleF(0, 0, 320, 200);
                CollectionView.AddSubview(mvxViewController.View);
                //BringSubviewToFront(mvxViewController.View);
            }
        }

        partial void HandleButtonAddS1TouchUpInside(NSObject sender)
        {
            ViewModel.AddSubViewOne();
        }


        partial void HandleButtonAddS2TouchUpInside(NSObject sender)
        {
            ViewModel.AddSubViewTwo();
        }

        // Do NOT remove this handler even if ReSharper cannot find it's usage. It is referred in BarCell.designer.cs file by its name. That's how Xamarin is linking the event on the button.
        partial void HandleButtonAddBarTouchUpInside(NSObject sender)
        {
            ViewModel.AddBarCell();
        }

        // Do NOT remove this handler even if ReSharper cannot find it's usage. It is referred in BarCell.designer.cs file by its name. That's how Xamarin is linking the event on the button.
        partial void HandleButtonRightTouchUpInside(NSObject sender)
        {
            var subViewModelTwo = App.SGFactory.Create<ISubViewModelTwo, ISubViewTwo>();
            if (subViewModelTwo != null)
            {
                var subViewTwo = subViewModelTwo.View as MvxViewController;
                if (subViewTwo != null)
                {
                    subViewTwo.View.Hidden = false;
                    subViewTwo.View.Frame = new RectangleF(0, 0, 320, 200);
                    CollectionView.AddSubview(subViewTwo.View);
                    //BringSubviewToFront(subViewTwo.View);
                }
            }
        }

        private void GoToNextCollectionView()
        {
            if (CollectionView == null) return;

            NSIndexPath[] indexPathsForVisibleItems = CollectionView.IndexPathsForVisibleItems;
            if (indexPathsForVisibleItems == null || indexPathsForVisibleItems.Count() <= 0) return;

            // If we ensure only one view in the viewable area, then this collection should always have just one item
            var currentViewIndexPath = indexPathsForVisibleItems[0];

            // Disable the button if the next subview is the last subview so that the button cannot be clicked.
            //ButtonRight.Enabled = (currentViewIndexPath.Row + 1) != (SubViewCount - 1);

            var nextViewIndexPath = NSIndexPath.FromRowSection(currentViewIndexPath.Row + 1, currentViewIndexPath.Section);
            CollectionView.ScrollToItem(nextViewIndexPath, UICollectionViewScrollPosition.Right, true);

            //ButtonLeft.Enabled = true;
        }

        private void GoToPreviousCollectionView()
        {
            if (CollectionView == null) return;

            NSIndexPath[] indexPathsForVisibleItems = CollectionView.IndexPathsForVisibleItems;
            if (indexPathsForVisibleItems == null || indexPathsForVisibleItems.Count() <= 0) return;

            // If we ensure only one view in the viewable area, then this collection should always have just one item
            var currentViewIndexPath = indexPathsForVisibleItems[0];

            // Disable the button if the next subview is the last subview so that the button cannot be clicked.
            //ButtonLeft.Enabled = (currentViewIndexPath.Row - 1) != 0;

            var previousViewIndexPath = NSIndexPath.FromRowSection(currentViewIndexPath.Row - 1, currentViewIndexPath.Section);
            CollectionView.ScrollToItem(previousViewIndexPath, UICollectionViewScrollPosition.Right, true);

            //ButtonRight.Enabled = true;
        }
	}
}

