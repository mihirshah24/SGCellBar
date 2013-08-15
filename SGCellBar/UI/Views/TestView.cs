using System;
using System.ComponentModel;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SGCellBar.Core.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using SGCellBar.UI.Views.Cells;

namespace SGCellBar.UI.Views
{
    /// <summary>
    /// 
    /// </summary>
	public partial class TestView : MvxViewController
	{

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
		public new BarHolderViewModel ViewModel
		{
			get { return (BarHolderViewModel) base.ViewModel; }
			set { base.ViewModel = value; }
		}


		public TestView () : base ("TestView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
            var source = new TableSource(TableView);

			this.CreateBinding(source).To((BarHolderViewModel vm) => vm.Bars).Apply();

            TableView.Source = source;
            TableView.ReloadData();
		    ViewModel.PropertyChanged += HandleViewModelPropertyChanged;
		}

	    private void HandleViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
	        if (e.PropertyName == "IsAddBarClicked")
	        {
				if (ViewModel.Bars.Count > 2)
	            	ViewModel.Bars.RemoveAt(0);
	        }
	    }


        /// <summary>
        /// Data Source for the Table View.
        /// </summary>
	    public class TableSource : MvxTableViewSource
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TableSource"/> class.
            /// </summary>
            /// <param name="tableView">The table view.</param>
            public TableSource(UITableView tableView) : base(tableView)
            {
                UseAnimations = true;
                AddAnimation = UITableViewRowAnimation.Top;
                RemoveAnimation = UITableViewRowAnimation.Middle;

                tableView.RegisterNibForCellReuse(BarCell.Nib, BarCell.Identifier);

            }

            /// <summary>
            /// Gets the height for row.
            /// </summary>
            /// <param name="tableView">The table view.</param>
            /// <param name="indexPath">The index path.</param>
            /// <returns></returns>
            public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                return 40.0f;
            }

            /// <summary>
            /// Gets the or create cell for.
            /// </summary>
            /// <param name="tableView">The table view.</param>
            /// <param name="indexPath">The index path.</param>
            /// <param name="item">The item.</param>
            /// <returns></returns>
            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
            {                
                UITableViewCell cell;
                try
                {
                    cell = tableView.DequeueReusableCell(BarCell.Identifier, indexPath);
                }
                catch (Exception e)
                {
                    throw e;
                }

                return cell;
            }
        }

        // Do NOT remove this handler even if ReSharper cannot find it's usage. It is referred in TestView.designer.cs file by its name. That's how Xamarin is linking the event on the button.
        partial void HandleButtonAddBarClicked(NSObject sender)
        {
            ViewModel.AddBarCommand.Execute(null);
        }

	}
}

