using System.ComponentModel;
using System.Drawing;
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
	public partial class TestView : MvxCollectionViewController
	{
        private readonly bool _isInitialised;

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public new BarHolderViewModel ViewModel
        {
            get { return (BarHolderViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }


        public TestView() : base(new UICollectionViewFlowLayout
            {
                ItemSize = new SizeF(320, 240),
                ScrollDirection = UICollectionViewScrollDirection.Vertical
            })
        {
            _isInitialised = true;
            ViewDidLoad();
        }

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
            if (!_isInitialised)
                return;

			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
            //var source = new TableSource(TableView);

            //this.CreateBinding(source).To((BarHolderViewModel vm) => vm.Bars).Apply();

            //TableView.Source = source;
            //TableView.ReloadData();

            CollectionView.RegisterNibForCell(BarCell.Nib, BarCell.Key);
            var source = new MvxCollectionViewSource(CollectionView, BarCell.Key);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<TestView, BarHolderViewModel>();
            set.Bind(source).To(vm => vm.Bars);
            set.Apply();

            CollectionView.ReloadData();
		    VerticalCollectionView = CollectionView;

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


        // Do NOT remove this handler even if ReSharper cannot find it's usage. It is referred in TestView.designer.cs file by its name. That's how Xamarin is linking the event on the button.
        partial void HandleButtonAddBarClicked(NSObject sender)
        {
            ViewModel.AddBarCommand.Execute(null);
        }

	}
}

