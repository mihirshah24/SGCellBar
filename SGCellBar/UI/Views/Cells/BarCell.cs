using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using SGCellBar.Core.ViewModels;

namespace SGCellBar.UI.Views.Cells
{
    /// <summary>
    /// Corresponds to each table cell that holds collectionview. Inherits <see cref="MvxTableViewCell"/>
    /// </summary>
	[Register("BarCell")]
	public partial class BarCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("BarCell", NSBundle.MainBundle);
		public static readonly NSString Identifier = new NSString("BarCell");


        /// <summary>
        /// Initializes a new instance of the <see cref="BarCell"/> class.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public BarCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<BarCell, BarViewModel>();
                set.Bind(UILabelHeader).To(p => p.Header);
                set.Apply();
            });
        }


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns><see cref="BarCell"/></returns>
	    public static BarCell Create ()
		{
			return (BarCell)Nib.Instantiate (null, null) [0];
		}


	}
}

