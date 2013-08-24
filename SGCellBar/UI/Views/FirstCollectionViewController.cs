using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SGCellBar.Core.ViewModels;
using SGCellBar.UI.Views.Cells;

namespace SGCellBar.UI.Views
{
    public class FirstCollectionViewController : MvxCollectionViewController
	{
		public FirstCollectionViewController () : base(new UICollectionViewFlowLayout
            {
                ItemSize = new SizeF(320, 240),
                ScrollDirection = UICollectionViewScrollDirection.Vertical
            })
        {
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

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Register any custom UICollectionViewCell classes
			//CollectionView.RegisterClassForCell (typeof(FirstCollectionViewCell), FirstCollectionViewCell.Key);


            CollectionView.RegisterNibForCell(BarCell.Nib, BarCell.Key);
            var source = new MvxCollectionViewSource(CollectionView, BarCell.Key);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<FirstCollectionViewController, BarHolderViewModel>();
            set.Bind(source).To(vm => vm.Bars);
            set.Apply();

            CollectionView.ReloadData();

			// Note: If you use one of the Collection View Cell templates to create a new cell type,
			// you can register it using the RegisterNibForCell() method like this:
			//
			// CollectionView.RegisterNibForCell (MyCollectionViewCell.Nib, MyCollectionViewCell.Key);
		}

		public override int NumberOfSections (UICollectionView collectionView)
		{
			// TODO: return the actual number of sections
			return 0;
		}

		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			// TODO: return the actual number of items in the section
			return 1;
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
            var cell = collectionView.DequeueReusableCell(BarCell.Key, indexPath) as BarCell;
			
			// TODO: populate the cell with the appropriate data based on the indexPath
			
			return cell;
		}
	}
}

