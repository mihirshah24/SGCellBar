namespace SGCellBar.Core.Interfaces
{
    /// <summary>
    /// Base View interface.
    /// </summary>
    /// <typeparam name="TVM">The type of the ViewModel</typeparam>
    public interface IView<TVM>
    {
        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        TVM ViewModel { get; set; }
    }
}
