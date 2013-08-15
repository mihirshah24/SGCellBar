// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace SGCellBar.UI.Views.Cells
{
	[Register ("BarCollectionCell")]
	partial class BarCollectionCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel LabelHeader { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LabelHeader != null) {
				LabelHeader.Dispose ();
				LabelHeader = null;
			}
		}
	}
}
