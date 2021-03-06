using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using SGCellBar.Core.Impl.ViewModels;
using SGCellBar.Core.Interfaces;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.Views;

namespace SGCellBar.UI.Views.Cells
{
    /// <summary>
    /// Corresponds to each cell of collection view. Inherits <see cref="MvxCollectionViewCell"/>
    /// </summary>
    public partial class BarCollectionCell : MvxCollectionViewCell, IBarCollectionCellView
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
        /// Gets or sets the view model.
        /// </summary>
        public IBarCollectionViewModel ViewModel { get; set; }

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

