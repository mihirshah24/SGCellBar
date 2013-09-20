using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;

namespace SGCellBar.Core.Interfaces.ViewModels.Common
{
    public interface IViewModel : IMvxViewModel
    {
        IMvxView View { get; set; }
        ISGFactory Factory { get; set; }
    }

    /// <summary>
    /// Base ViewModel interface
    /// </summary>
    /// <typeparam name="TV">The type of View.</typeparam>
    public interface IViewModel<TV> : IViewModel
        where TV : class, IMvxView
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        new TV View { get; set; }
    }
}
