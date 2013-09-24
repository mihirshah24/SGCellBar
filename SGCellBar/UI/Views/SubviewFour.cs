using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SGCellBar.Core.Impl.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.UI.Common;

namespace SGCellBar.UI.Views
{
    public partial class SubviewFour : AbstractViewController<ISubViewModelOne, SubViewModelOne>, ISubViewOne
    {
        public static readonly UINib Nib = UINib.FromName("SubviewFour", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("SubviewFour");
		public SubviewFour () : base ("SubviewFour", null)
		{
		}
	}
}

