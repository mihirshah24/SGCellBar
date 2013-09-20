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
	partial class BarCell
	{
		[Outlet]
		MonoTouch.UIKit.UIButton ButtonAdd { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ButtonLeft { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ButtonRight { get; set; }

		[Outlet]
		MonoTouch.UIKit.UICollectionView CollectionView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel UILabelHeader { get; set; }

		[Action ("HandleButtonAddSubOneTouchUpInside:")]
		partial void HandleButtonAddSubOneTouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonAddSubTwoTouchUpInside:")]
		partial void HandleButtonAddSubTwoTouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonAddTouchUpInside:")]
		partial void HandleButtonAddTouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("HandleButtonRightTouchUpInside:")]
		partial void HandleButtonRightTouchUpInside (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ButtonAdd != null) {
				ButtonAdd.Dispose ();
				ButtonAdd = null;
			}

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
