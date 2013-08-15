using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using SGCellBar.Core.ViewModels;

namespace SGCellBar.UI.Views.Cells
{
    /// <summary>
    /// Corresponds to each cell of collection view. Inherits <see cref="MvxCollectionViewCell"/>
    /// </summary>
	public partial class BarCollectionCell : MvxCollectionViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("BarCollectionCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("BarCollectionCell");

        /// <summary>
        /// Initializes a new instance of the <see cref="BarCollectionCell"/> class.
        /// </summary>
        /// <param name="handle">The handle.</param>
		public BarCollectionCell (IntPtr handle) : base (handle)
		{
			this.DelayBind(() => {
				var set = this.CreateBindingSet<BarCollectionCell, BarCollectionViewModel>();
				set.Bind(LabelHeader).To(p => p.Header);
				set.Apply();
			});
		}

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns><see cref="BarCollectionCell"/></returns>
		public static BarCollectionCell Create ()
		{
			return (BarCollectionCell)Nib.Instantiate (null, null) [0];
		}
	}
}

