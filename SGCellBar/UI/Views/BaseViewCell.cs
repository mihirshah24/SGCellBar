using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace SGCellBar
{
	public partial class BaseViewCell : MvxCollectionViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("BaseViewCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("BaseViewCell");

		public BaseViewCell (IntPtr handle) : base (handle)
		{
		}

		public static BaseViewCell Create ()
		{
			return (BaseViewCell)Nib.Instantiate (null, null) [0];
		}
	}
}

