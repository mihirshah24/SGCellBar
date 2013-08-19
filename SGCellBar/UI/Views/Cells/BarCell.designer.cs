// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace SGCellBar.UI.Views.Cells
{
	partial class BarCell
	{
		[Outlet]
		MonoTouch.UIKit.UIButton ButtonLeft { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ButtonRight { get; set; }

		[Outlet]
		MonoTouch.UIKit.UICollectionView CollectionView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UILabelHeader { get; set; }

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

			if (UILabelHeader != null) {
				UILabelHeader.Dispose ();
				UILabelHeader = null;
			}
		}
	}
}
