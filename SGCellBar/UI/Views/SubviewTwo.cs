using Cirrious.MvvmCross.Touch.Views;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.UI.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SubviewTwo : MvxViewController, ISubViewTwo
	{
        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public new ISubViewModelTwo ViewModel { get; set; }

        public SubviewTwo()
            : base("SubviewTwo", null)
        {
        }

        public void AddSubView(IView subView)
        {
            // Not Supported
        }
        
	}
}

