using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;

namespace SGCellBar.Core.Interfaces.ViewModels.Common
{
    public interface IViewModel : IMvxViewModel
    {
        IMvxView MyView { get; set; }
        ISGFactory Factory { get; set; }
    }

    /// <summary>
    /// Base MyViewModel interface
    /// </summary>
    /// <typeparam name="TV">The type of MyView.</typeparam>
    public interface IViewModel<TV> : IViewModel
        where TV : class, IMvxView
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        new TV MyView { get; set; }
    }
}
