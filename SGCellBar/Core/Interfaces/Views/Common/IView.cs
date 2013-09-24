using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;

namespace SGCellBar.Core.Interfaces.Views.Common
{
    public interface IView : IMvxView
    {
        void AddSubView(IView subView);
    }

    /// <summary>
    /// Base MyView interface.
    /// </summary>
    /// <typeparam name="TVM">The type of the MyViewModel</typeparam>
    public interface IView<TVM> : IView
        where TVM : class, IMvxViewModel
    {
        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        TVM MyViewModel { get; set; }
    }
}
