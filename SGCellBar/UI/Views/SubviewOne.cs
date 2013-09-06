using Cirrious.MvvmCross.Binding.Touch.Views;
using SGCellBar.Core.Interfaces;

namespace SGCellBar.UI.Views
{
    
    public partial class SubviewOne : MvxView, ISubViewOne
	{

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ISubViewModelOne ViewModel { get; set; }


        //public SubviewOne () : base ("SubviewOne", null)
        //{
        //}

        //public override void DidReceiveMemoryWarning ()
        //{
        //    // Releases the view if it doesn't have a superview.
        //    base.DidReceiveMemoryWarning ();
			
        //    // Release any cached data, images, etc that aren't in use.
        //}

        //public override void ViewDidLoad ()
        //{
        //    base.ViewDidLoad ();
			
        //    // Perform any additional setup after loading the view, typically from a nib.
        //}

        //public class TableViewSource : MvxTableViewSource
        //{
        //    public TableViewSource(UITableView tableView)
        //        : base(tableView)
        //    {
        //        tableView.RegisterNibForCellReuse(UINib.FromName("TwitterCell", NSBundle.MainBundle), TwitterCell.CellIdentifier);
        //    }

        //    public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        //    {
        //        var item = GetItemAt(indexPath);
        //        return TwitterCell.CellHeight(item);
        //    }

        //    protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        //    {
        //        var cellName = TwitterCell.CellIdentifier;
        //        return (UITableViewCell)tableView.DequeueReusableCell(cellName, indexPath);
        //    }
        //}
        

	}
}

