using Cirrious.CrossCore;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using SGCellBar.UI;

namespace SGCellBar
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		// class-level declarations
		UIWindow _window;
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			_window = new UIWindow(UIScreen.MainScreen.Bounds);

			var presenter = new MvxTouchViewPresenter(this, _window);
			var setup = new Setup(this, presenter);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			_window.MakeKeyAndVisible();

			return true;
            /*
			// create a new window instance based on the screen size
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            // If you have defined a view, add it here:
            // window.AddSubview (navigationController.MyView);
            var presenter = new MvxTouchViewPresenter(this, _window);
            var setup = new Setup(this, presenter);
            setup.Initialize();

			//var simpleStart = new MvxAppStart<BarHolderViewModel>();
            //simpleStart.Start();
			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();;

            // make the window visible
            _window.MakeKeyAndVisible();

            return true;*/
		}
	}
}

