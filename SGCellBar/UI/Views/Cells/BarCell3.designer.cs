// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace SGCellBar.UI.Views.Cells
{
	[Register ("BarCell3")]
	partial class BarCell3
	{
		[Outlet]
		MonoTouch.UIKit.UIButton ButtonLeft { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ButtonRight { get; set; }

		[Outlet]
		MonoTouch.UIKit.UICollectionView CollectionView { get; set; }

		[Action ("HandleButtonAddBarTouchUpInside:")]
		partial void HandleButtonAddBarTouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonAddS1TouchUpInside:")]
		partial void HandleButtonAddS1TouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonAddS2TouchUpInside:")]
		partial void HandleButtonAddS2TouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonRightTouchUpInside:")]
		partial void HandleButtonRightTouchUpInside (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ButtonLeft != null) {
				ButtonLeft.Dispose ();
				ButtonLeft = null;
			}

			if (ButtonRight != null) {
				ButtonRight.Dispose ();
				ButtonRight = null;
			}

			if (CollectionView != null) {
				CollectionView.Dispose ();
				CollectionView = null;
			}
		}
	}
}
