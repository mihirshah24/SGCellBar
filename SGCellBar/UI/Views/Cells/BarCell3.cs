using System.Collections.ObjectModel;
using System.Drawing;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using SGCellBar.Core.Impl.ViewModels;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.ViewModels;
using System.ComponentModel;
using System.Linq;
using SGCellBar.Core.Interfaces.Views.Common;
using SGCellBar.Core;
using SGCellBar.UI.Common;
using MonoTouch.CoreGraphics;

namespace SGCellBar.UI.Views.Cells
{
    public partial class BarCell3 : AbstractViewController<IBarViewModel, BarViewModel>, IBarCellView
	{
        public static readonly UINib Nib = UINib.FromName("BarCell3", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("BarCell3");
		
		private bool _viewDidLoad;
		public BarCell3 () : base ("BarCell3", null)
		{
		}


        ///// <summary>
        ///// Creates this instance.
        ///// </summary>
        ///// <returns><see cref="BarCell3"/></returns>
        //public static BarCell3 Create()
        //{
        //    return (BarCell3) Nib.Instantiate(null, null)[0];
        //}

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

        public override void ViewDidLoad()
        {
			_viewDidLoad = true;
            base.ViewDidLoad();
            MyViewModel.Factory = App.SGFactory;
            MyViewModel.MyView = this;

            //CollectionView.RegisterClassForCell(typeof(BaseViewCell), BaseViewCell.Key);
            CollectionView.RegisterNibForCell(BaseViewCell.Nib, BaseViewCell.Key);
            var source = new MvxCollectionViewSource(CollectionView, BaseViewCell.Key);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<BarCell3, BarViewModel>();
            set.Bind(source).To(vm => vm.Views);
            set.Apply();

            //CollectionView.CollectionViewLayout = new UICollectionViewFlowLayout
            //                                          {
            //                                              ItemSize = new SizeF(320, 400),
            //                                              ScrollDirection = UICollectionViewScrollDirection.Horizontal,
            //                                          };

            CollectionView.ReloadData();

            //CollectionView.RegisterClassForCell(typeof(BaseViewCell), BaseViewCell.Key);
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


	    public override void AddSubView(IView subView)
        {
			//CollectionView.deque
			var index = NSIndexPath.Create (new [] { 0, 0 });
            var cell = CollectionView.DequeueReusableCell(BaseViewCell.Key, index) as UICollectionViewCell;
            if (cell != null)
            {
                //var view = ((MvxViewController) subView).View;
                //view.Hidden = false;
                //view.Frame = new RectangleF(0, 0, 320, 320);
                //cell.ContentView.Add(view);

                var view = new UILabel();
                view.Text = "Content View";
                view.Hidden = false;
                view.Frame = new RectangleF(0, 0, 320, 50);
               
                cell.ContentView.AddSubview(view);
                cell.ContentView.BringSubviewToFront(view);

            }
           
            
            

            //var cell = CollectionView.Subviews[0];
            //var cell2 = cell as BaseViewCell;
            //var cell3 = cell as IBaseCellView;

            //var mvxViewController = subView as MvxViewController;
            //if (mvxViewController != null)
            //{
				//var viewToAdd = mvxViewController.View;
                //mvxViewController.View.ClipsToBounds = true;
                //mvxViewController.View.Hidden = false;
                //mvxViewController.View.Frame = new RectangleF(0, 0, 320, 200);

				//cell.Init();
				//cell.AddSubView (subView);

				//cell.ContentView.Transform = CGAffineTransform.MakeScale (0.8f, 0.8f);

				//viewToAdd.Center = cell.ContentView.Center;

                //cell.ContentView.AddSubview(mvxViewController.View);
				//cell.BringSubviewToFront (mvxViewController.View);
				//cell.AddSubview (mvxViewController.View);
				//cell.BringSubviewToFront (mvxViewController.View);

                //CollectionView.AddSubview(mvxViewController.View);
                //CollectionView.BringSubviewToFront(mvxViewController.View);
                //((BaseViewCell)cell).ContentView.AddSubview(mvxViewController.View);
                //new UICollectionViewCell()
                //CollectionView.AddSubview(mvxViewController.MyView);

                //var newCell = new UICollectionViewCell();
                //CollectionView.InsertItems(new NSIndexPath[0]);
                //var cell = CollectionView.CellForItem(new NSIndexPath());
                //CollectionView.AddSubview(mvxViewController.MyView);
                //CollectionView.BringSubviewToFront(mvxViewController.MyView);

                //BringSubviewToFront(mvxViewController.MyView);
            //}

			//CollectionView.ReloadItems (new[] { index });;
			CollectionView.ReloadData ();
        }

        partial void HandleButtonAddS1TouchUpInside(NSObject sender)
        {
            MyViewModel.AddSubViewOne();
        }


        partial void HandleButtonAddS2TouchUpInside(NSObject sender)
        {
            MyViewModel.AddSubViewTwo();
        }

        // Do NOT remove this handler even if ReSharper cannot find it's usage. It is referred in BarCell.designer.cs file by its name. That's how Xamarin is linking the event on the button.
        partial void HandleButtonAddBarTouchUpInside(NSObject sender)
        {
            MyViewModel.AddBarCell();
        }

        // Do NOT remove this handler even if ReSharper cannot find it's usage. It is referred in BarCell.designer.cs file by its name. That's how Xamarin is linking the event on the button.
        partial void HandleButtonRightTouchUpInside(NSObject sender)
        {
            var subViewModelTwo = App.SGFactory.Create<ISubViewModelTwo, ISubViewTwo>();
            if (subViewModelTwo != null)
            {
                var subViewTwo = subViewModelTwo.MyView as MvxViewController;
                if (subViewTwo != null)
                {
                    subViewTwo.View.Hidden = false;
                    subViewTwo.View.Frame = new RectangleF(0, 0, 320, 200);
                    CollectionView.AddSubview(subViewTwo.View);
                    //BringSubviewToFront(subViewTwo.MyView);
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

