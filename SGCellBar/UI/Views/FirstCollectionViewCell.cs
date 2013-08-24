using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SGCellBar.UI.Views
{
	public class FirstCollectionViewCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString ("FirstCollectionViewCell");

		[Export ("initWithFrame:")]
		public FirstCollectionViewCell (RectangleF frame) : base (frame)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			BackgroundColor = UIColor.Cyan;
		}
	}
}

