using System;
using System.Collections.Generic;
using Cirrious.CrossCore;
using SGCellBar.Core.Impl.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels;
using SGCellBar.Core.Interfaces.ViewModels.Common;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.Views.Common;
using SGCellBar.UI.Views;
using SGCellBar.UI.Views.Cells;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.Touch.Views;

namespace SGCellBar.UI.Common
{
    /// <summary>
    /// Factory class that creates various objects.
    /// </summary>
    public class SGFactory : 
		ISGFactory, 
		IMvxCanCreateTouchView
    {
        private static readonly IDictionary<Type, Type> _association = new Dictionary<Type, Type>
        {
            //{typeof(IBarCollectionCellView), typeof(BarCollectionCell)},
            //{typeof(IBarCollectionViewModel), typeof(BarCollectionViewModel)},
            {typeof(IBarViewModel), typeof(BarViewModel)},
            {typeof(IBarCellView), typeof(BarCell)},
            {typeof(ISubViewModelOne), typeof(SubViewModelOne)},
            {typeof(ISubViewOne), typeof(SubviewFour)},
            {typeof(ISubViewModelTwo), typeof(SubViewModelTwo)},
            {typeof(ISubViewTwo), typeof(SubviewTwo)},

        };
        
        /// <summary>
        /// Initializes the <see cref="SGFactory"/> class.
        /// </summary>
        static SGFactory()
        {
            foreach (var x in _association)
            {
                Mvx.RegisterType(x.Key, x.Value);
            }
        }

        /// <summary>
        /// Creates a new instance of <typeparamref name="TVM" /> assuming it is already registered.
        /// </summary>
        /// <typeparam name="TVM">The type of the vm.</typeparam>
        /// <typeparam name="TV">The type of the average.</typeparam>
        /// <returns>
		///   <typeparamref name="TVM" />var viewModel = Mvx.Create<TVM>();
        /// </returns>
        /// <exception cref="System.Exception"> If types are not registered.
        /// </exception>
        public TVM Create<TVM, TV>() 
			where TVM : class, IViewModel<TV>, IMvxViewModel
			where TV : class, IView<TVM>

        {
            if (!Mvx.CanResolve<TVM>())
                throw new Exception(string.Format("ViewModel Type {0} is not registered. Please register it before calling this method.", typeof(TVM)));

            if (!Mvx.CanResolve<TV>())
                throw new Exception(string.Format("View Type {0} is not registered. Please register it before calling this method.", typeof(TV)));

			var vc = Mvx.Resolve<IMvxViewsContainer> ();
			vc.Add (typeof(TVM), SGFactory._association [typeof(TV)]);

			var view = this.CreateViewControllerFor<TVM> ((object)null);
			var viewModel = Mvx.Create<TVM> ();
            viewModel.Factory = this;
			view.ViewModel = viewModel;
			viewModel.View = (TV)view;

            // Do other initialization here i.e. vm.init();

            return viewModel;
        }
    }
}
