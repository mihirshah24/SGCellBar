// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SGCellBar.UI.Views.Cells
{
	[Register ("BarCell2")]
	partial class BarCell2
	{
		[Outlet]
		MonoTouch.UIKit.UICollectionView CollectionView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView View { get; set; }

		[Action ("HandleButtonAddBarCellTouchUpInside:")]
		partial void HandleButtonAddBarCellTouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonAddSubView1TouchUpInside:")]
		partial void HandleButtonAddSubView1TouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonAddSubView2TouchUpInside:")]
		partial void HandleButtonAddSubView2TouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonLeftTouchUpInside:")]
		partial void HandleButtonLeftTouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonRightTouchUpInside:")]
		partial void HandleButtonRightTouchUpInside (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (CollectionView != null) {
				CollectionView.Dispose ();
				CollectionView = null;
			}

			if (View != null) {
				View.Dispose ();
				View = null;
			}
		}
	}
}
