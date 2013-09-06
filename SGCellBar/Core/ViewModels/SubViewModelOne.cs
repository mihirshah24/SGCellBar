using Cirrious.MvvmCross.ViewModels;
using SGCellBar.Core.Interfaces;

namespace SGCellBar.Core.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class SubViewModelOne : MvxViewModel, ISubViewModelOne
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public ISubViewOne View { get; set; }
    }
}
