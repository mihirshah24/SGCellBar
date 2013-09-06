namespace SGCellBar.Core.Interfaces
{
    /// <summary>
    /// Base ViewModel interface
    /// </summary>
    /// <typeparam name="TV">The type of View.</typeparam>
    public interface IViewModel<TV>
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        TV View { get; set; }
    }
}
