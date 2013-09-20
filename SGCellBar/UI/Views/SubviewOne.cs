using Cirrious.MvvmCross.Touch.Views;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.UI.Views
{
    
    public partial class SubviewOne : MvxViewController
	{

        ///// <summary>
        ///// Gets or sets the view model.
        ///// </summary>
        //public new ISubViewModelOne ViewModel { get; set; }


        public SubviewOne() : base("SubviewOne", null)
        {
        }

        public void AddSubView(IView subView)
        {
            // Not Supported
        }

	}
}

