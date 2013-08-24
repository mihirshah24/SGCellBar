// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace SGCellBar.UI.Views
{
	[Register ("TestView")]
	partial class TestView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton ButtonAddBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UICollectionView VerticalCollectionView { get; set; }

		[Action ("HandleButtonAddBarClicked:")]
		partial void HandleButtonAddBarClicked (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (VerticalCollectionView != null) {
				VerticalCollectionView.Dispose ();
				VerticalCollectionView = null;
			}

			if (ButtonAddBar != null) {
				ButtonAddBar.Dispose ();
				ButtonAddBar = null;
			}

			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
