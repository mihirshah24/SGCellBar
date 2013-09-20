using MonoTouch.UIKit;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.UI.Views
{
	public partial class SubviewThree : UIViewController
	{
		public SubviewThree () : base ("SubviewThree", null)
		{
		}

        public void AddSubView(IView subView)
        {
            // Not Supported
        }
	}
}

