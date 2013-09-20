using Cirrious.MvvmCross.ViewModels;
using SGCellBar.Core.Impl.ViewModels;
using SGCellBar.Core.Interfaces;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels.Common;

namespace SGCellBar.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class App : MvxApplication
    {

        /// <summary>
        /// Gets or sets the <see cref="ISGFactory"/>
        /// </summary>
        public static ISGFactory SGFactory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            RegisterServices();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
		public override void Initialize()
		{
			RegisterAppStart<BarHolderViewModel>();
		}

        /// <summary>
        /// Registers the services.
        /// </summary>
        private void RegisterServices()
        {
            
        }
    }
}
