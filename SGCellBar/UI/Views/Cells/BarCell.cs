using System;
using System.ComponentModel;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using SGCellBar.Core.Interfaces;
using SGCellBar.Core.ViewModels;
using System.Linq;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using SGCellBar.Core;

namespace SGCellBar.UI.Views.Cells
{

    /// <summary>
    /// Corresponds to each table cell that holds collectionview. Inherits <see cref="MvxTableViewCell"/>
    /// </summary>
	[Register("BarCell")]
    public partial class BarCell : MvxCollectionViewCell, IBarCellView
	{
		public static readonly UINib Nib = UINib.FromName ("BarCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString("BarCell");
        

        /// <summary>
        /// Initializes a new instance of the <see cref="BarCell"/> class.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public BarCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<BarCell, BarViewModel>();
                set.Bind(ButtonAdd).To(p => p.AddCommand);
				set.Bind(ButtonRight).To(p => p.NextCommand);
                set.Bind(ButtonLeft).To(p => p.PreviousCommand);
				set.Apply();
            });

        }

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        public new object DataContext
        {
            get
            {
                return base.DataContext;
            }
            set
            {
                base.DataContext = value;

                var barViewModel = value as IBarViewModel;
                if (barViewModel != null)
                {
                    ViewModel = barViewModel;
					((MvxViewModel)ViewModel).PropertyChanged += HandleBarViewModelPropertyChanged;
                }
            }
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public IBarViewModel ViewModel { get; set; }

        private int SubViewCount
        {
            get
            {
                if (CollectionView == null) return 0;
                var subviewsCount = CollectionView.Subviews.Count();
                return subviewsCount <= 0 ? 0 : subviewsCount;
            }
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns><see cref="BarCell"/></returns>
        public static BarCell Create()
        {
            return (BarCell)Nib.Instantiate(null, null)[0];
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

			CollectionView.RegisterNibForCell(BarCell.Nib, BarCell.Key);
			var source = new MvxCollectionViewSource(CollectionView, BarCell.Key);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<BarCell, BarViewModel>();
            set.Bind(source).To(vm => vm.Views);
            set.Apply();

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

        private int i = 0;
		// Do NOT remove this handler even if ReSharper cannot find it's usage. It is referred in BarCell.designer.cs file by its name. That's how Xamarin is linking the event on the button.
		partial void HandleButtonAddTouchUpInside (NSObject sender)
		{
			//if (ViewModel == null) return;
			//ViewModel.AddCommand.Execute(null);

		    switch (i)
		    {
                case 0:
                    var subViewModelOne = App.SGFactory.Create<ISubViewModelOne, ISubViewOne>();
                    if (subViewModelOne != null)
                    {
                        var subViewOne = subViewModelOne.View as SubviewOne;
                        if (subViewOne != null)
                        {
                            subViewOne.Hidden = false;
                            subViewOne.Frame = new RectangleF(0, 0, 320, 200);
                            CollectionView.AddSubview(subViewOne);
                        }
                    }

                    //var label = new UILabel();
                    //label.Text = "Test Label";
                    //label.Hidden = false;
                    //label.Frame = new RectangleF(0, 0, 320, 200);
                    //CollectionView.AddSubview(label);
                    
		            break;

                case 1:
                    var subViewModelTwo = App.SGFactory.Create<ISubViewModelTwo, ISubViewTwo>();
                    if (subViewModelTwo != null)
                    {
                        var subViewOne = subViewModelTwo.View as SubviewTwo;
                        if (subViewOne != null)
                        {
                            subViewOne.Hidden = false;
                            subViewOne.Frame = new RectangleF(0, 0, 320, 200);
                            CollectionView.AddSubview(subViewOne);
                        }
                    }
		            break;

                case 2:

		            break;
		    }

		    ++i;
		}

        // Do NOT remove this handler even if ReSharper cannot find it's usage. It is referred in BarCell.designer.cs file by its name. That's how Xamarin is linking the event on the button.
		partial void HandleButtonRightTouchUpInside (NSObject sender)
		{
			//GoToNextCollectionView();
		}

        private void GoToNextCollectionView()
        {
            if (CollectionView == null) return;

            NSIndexPath[] indexPathsForVisibleItems = CollectionView.IndexPathsForVisibleItems;
            if (indexPathsForVisibleItems == null || indexPathsForVisibleItems.Count() <= 0) return;

            // If we ensure only one view in the viewable area, then this collection should always have just one item
            var currentViewIndexPath = indexPathsForVisibleItems[0];

            // Disable the button if the next subview is the last subview so that the button cannot be clicked.
            ButtonRight.Enabled = (currentViewIndexPath.Row + 1) != (SubViewCount - 1);

            var nextViewIndexPath = NSIndexPath.FromRowSection(currentViewIndexPath.Row + 1, currentViewIndexPath.Section);
            CollectionView.ScrollToItem(nextViewIndexPath, UICollectionViewScrollPosition.Right, true);

            ButtonLeft.Enabled = true;
        }

        private void GoToPreviousCollectionView()
        {
            if (CollectionView == null) return;

            NSIndexPath[] indexPathsForVisibleItems = CollectionView.IndexPathsForVisibleItems;
            if (indexPathsForVisibleItems == null || indexPathsForVisibleItems.Count() <= 0) return;

            // If we ensure only one view in the viewable area, then this collection should always have just one item
            var currentViewIndexPath = indexPathsForVisibleItems[0];

            // Disable the button if the next subview is the last subview so that the button cannot be clicked.
            ButtonLeft.Enabled = (currentViewIndexPath.Row - 1) != 0;

            var previousViewIndexPath = NSIndexPath.FromRowSection(currentViewIndexPath.Row - 1, currentViewIndexPath.Section);
            CollectionView.ScrollToItem(previousViewIndexPath, UICollectionViewScrollPosition.Right, true);

            ButtonRight.Enabled = true;
        }
	}
}

