using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using SGCellBar.Core;
using SGCellBar.Core.Impl.ViewModels;
using SGCellBar.Core.Interfaces.Views.Common;
using SGCellBar.UI.Views.Cells;

namespace SGCellBar
{
	[Register("SecondView")]
	public partial class SecondView : MvxViewController
	{
		public SecondView () : base ("SecondView", null)
		{
		}
		
		public new BarHolderViewModel ViewModel
		{
			get { return (BarHolderViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}
		
		public void AddSubView(IView subView)
		{
			// Not Supported
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

			//MainCollectionView.RegisterNibForCell (BaseViewCell.Nib, BaseViewCell.Key);
			//var source = new MvxCollectionViewSource (MainCollectionView, BaseViewCell.Key);
			//MainCollectionView.Source = source;

            //MainCollectionView.RegisterNibForCell(BarCell2.Nib, BarCell2.Key);
            //var source = new MvxCollectionViewSource(MainCollectionView, BarCell2.Key);
            //MainCollectionView.Source = source;
			//MainCollectionView.ReloadData ();
            ViewModel.Factory = App.SGFactory;
            var subViewModel = ViewModel.Initialize();
		    var mvxViewController = subViewModel.MyView as UIViewController;
			if (mvxViewController != null)
			{                           
				mvxViewController.View.ClipsToBounds = true;
				mvxViewController.View.Hidden = false;
				mvxViewController.View.Frame = new RectangleF(0, 0, 320, 400);
                
                //base.AddChildViewController(mvxViewController);
                //this.AddChildViewController(mvxViewController);
                //AddChildViewController(mvxViewController);
                ScrollView.AddSubview(mvxViewController.View);
                //Add(mvxViewController.MyView);
				//MainCollectionView.AddSubview(mvxViewController.MyView);
				//MainCollectionView.BringSubviewToFront(mvxViewController.MyView);
			}

            //var set = this.CreateBindingSet<SecondView, BarHolderViewModel>();
            //set.Bind(source).To(vm => vm.Bars);
            //set.Apply();

            //MainCollectionView.ReloadData();
            ScrollView.ReloadInputViews();
		}
	}
}

