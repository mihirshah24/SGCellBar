using Cirrious.MvvmCross.ViewModels;
using SGCellBar.Core.Interfaces;

namespace SGCellBar.Core.ViewModels
{
    public class SubViewModelTwo : MvxViewModel, ISubViewModelTwo
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public ISubViewTwo View { get; set; }

    }
}
