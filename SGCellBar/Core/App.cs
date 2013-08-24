using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace SGCellBar.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            RegisterServices();
        }

		public override void Initialize()
		{
			RegisterAppStart<ViewModels.BarHolderViewModel>();
		}       

        private void RegisterServices()
        {
            
        }
    }
}
