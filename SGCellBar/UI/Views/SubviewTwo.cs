using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SGCellBar.Core.Impl.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.UI.Common;

namespace SGCellBar.UI.Views
{
    /// <summary />
    public partial class SubviewTwo : AbstractViewController<ISubViewModelTwo, SubViewModelTwo>, ISubViewTwo
    {
        public static readonly UINib Nib = UINib.FromName("SubviewTwo", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("SubviewTwo");

        public SubviewTwo()
            : base("SubviewTwo", null)
        {
        }   
	}
}

