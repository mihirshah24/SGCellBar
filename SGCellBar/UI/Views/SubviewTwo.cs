using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using SGCellBar.Core.Interfaces;

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

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }
        
	}
}

