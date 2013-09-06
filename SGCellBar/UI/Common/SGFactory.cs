using System;
using System.Collections.Generic;
using Cirrious.CrossCore;
using SGCellBar.Core.Interfaces;
using SGCellBar.Core.ViewModels;
using SGCellBar.UI.Views;
using SGCellBar.UI.Views.Cells;

namespace SGCellBar.UI.Common
{
    /// <summary>
    /// Factory class that creates various objects.
    /// </summary>
    public class SGFactory : ISGFactory
    {
        private static readonly IDictionary<Type, Type> _association = new Dictionary<Type, Type>
        {
            {typeof(IBarCollectionCellView), typeof(BarCollectionCell)},
            {typeof(IBarCollectionViewModel), typeof(BarCollectionViewModel)},
            {typeof(IBarViewModel), typeof(BarViewModel)},
            {typeof(IBarCellView), typeof(BarCell)},
            {typeof(ISubViewModelOne), typeof(SubViewModelOne)},
            {typeof(ISubViewOne), typeof(SubviewOne)},
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
        ///   <typeparamref name="TVM" />
        /// </returns>
        /// <exception cref="System.Exception"> If types are not registered.
        /// </exception>
        public TVM Create<TVM, TV>() where TVM : class, IViewModel<TV> where TV : class, IView<TVM>
        {
            if (!Mvx.CanResolve<TVM>())
                throw new Exception(string.Format("ViewModel Type {0} is not registered. Please register it before calling this method.", typeof(TVM)));

            if (!Mvx.CanResolve<TV>())
                throw new Exception(string.Format("View Type {0} is not registered. Please register it before calling this method.", typeof(TV)));

            var viewModel = Mvx.Create<TVM>();
            var view = Mvx.Create<TV>();

            viewModel.View = view;
            view.ViewModel = viewModel;

            // Do other initialization here i.e. vm.init();

            return viewModel;
        }
    }
}
