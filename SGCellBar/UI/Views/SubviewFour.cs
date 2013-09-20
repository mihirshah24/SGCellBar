using Cirrious.MvvmCross.Touch.Views;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.UI.Views
{
    public partial class SubviewFour : MvxViewController, ISubViewOne
	{
		public SubviewFour () : base ("SubviewFour", null)
		{
		}

		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		public new ISubViewModelOne ViewModel { get; set; }

        public void AddSubView(IView subView)
        {
            // Not Supported
        }
	}
}

