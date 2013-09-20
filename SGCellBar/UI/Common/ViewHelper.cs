using MonoTouch.UIKit;
using SGCellBar.Core.Interfaces;
using SGCellBar.Core.Interfaces.Views;
using SGCellBar.Core.Interfaces.Views.Common;

namespace SGCellBar.UI.Common
{
    /// <summary>
    /// Helper methods for the views.
    /// </summary>
    public class ViewHelper : IViewHelper
    {

        /// <summary>
        /// Adds the subview automatically.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="child">The child.</param>
        public void AddToSubview(object parent, object child)
        {
            AddToSubview((UIView)parent, (UIView)child);
        }

        /// <summary>
        /// Adds the subview automatically.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="child">The child.</param>
        private static void AddToSubview(UIView parent, UIView child)
        {
            parent.AddSubview(child);
        }
    }
}
