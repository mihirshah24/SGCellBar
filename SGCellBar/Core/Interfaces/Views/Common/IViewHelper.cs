namespace SGCellBar.Core.Interfaces.Views.Common
{
    /// <summary>
    /// Helper methods for the views.
    /// </summary>
    public interface IViewHelper
    {
        /// <summary>
        /// Adds the subview automatically.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="child">The child.</param>
        void AddToSubview(object parent, object child);
    }
}
