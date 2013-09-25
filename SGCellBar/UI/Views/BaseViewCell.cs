using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SGCellBar.Core.Impl.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.UI.Views
{
	public partial class BaseViewCell : MvxCollectionViewCell, IBaseCellView
	{
		public static readonly UINib Nib = UINib.FromName ("BaseViewCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("BaseViewCell");

		public BaseViewCell (IntPtr handle) : base (handle)
		{
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<BaseViewCell, BaseCellViewModel>();
                //set.Bind(ButtonAdd).To(p => p.AddCommand);
                //set.Bind(ButtonRight).To(p => p.NextCommand);
                //set.Bind(ButtonLeft).To(p => p.PreviousCommand);
                set.Apply();
            });

            //BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

            //SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };

            //ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
            //ContentView.Layer.BorderWidth = 2.0f;
            //ContentView.BackgroundColor = UIColor.White;
            //ContentView.Transform = CGAffineTransform.MakeScale(0.8f, 0.8f);

            //BackgroundView = new UIView { BackgroundColor = UIColor.Orange };
			//SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Red };
			//ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
			//ContentView.Layer.BorderWidth = 2.0f;
			//ContentView.BackgroundColor = UIColor.Green;
		}


        //public static BaseViewCell Create ()
        //{
        //    var cell = (BaseViewCell)Nib.Instantiate (null, null) [0];
        //    return cell;
        //}

		public IMvxViewModel ViewModel { get; set; }
		
		public IBaseCellViewModel MyViewModel
		{
			get
			{
			    return (IBaseCellViewModel)ViewModel;
			}
			set
			{
			    ViewModel = value;
			}
		}
        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        public new object DataContext
        {
            get
            {
                return base.DataContext;
            }
            set
            {
                base.DataContext = value;

                var baseCellViewModel = value as IBaseCellViewModel;
                if (baseCellViewModel != null)
                {
                    ViewModel = baseCellViewModel;
					baseCellViewModel.MyView = this;
					//((MvxViewModel)ViewModel).PropertyChanged += HandleBarViewModelPropertyChanged;
                }
            }
        }

	    public void AddSubView(IView subView)
		{
			
			//BackgroundView = new UIView { BackgroundColor = UIColor.Orange };
			//SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Red };
			//ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
			//ContentView.Layer.BorderWidth = 2.0f;
			//ContentView.BackgroundColor = UIColor.Green;
			//this.
			//var uiView = ((UIViewController)subView).View;
			//ContentView.AddSubview (uiView);

			//ContentView.BringSubviewToFront (uiView);

	    }

        
	}
}

