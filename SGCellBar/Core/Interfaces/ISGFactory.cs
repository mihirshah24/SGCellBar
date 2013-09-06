namespace SGCellBar.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISGFactory
    {
        /// <summary>
        /// Creates a new instance of <typeparamref name="TVM" /> assuming it has been registered.
        /// </summary>
        /// <typeparam name="TVM">The type of the vm.</typeparam>
        /// <typeparam name="TV">The type of the average.</typeparam>
        /// <returns>
        ///   <typeparamref name="TVM" />
        /// </returns>
        /// <exception cref="System.Exception"> If types are not registered.
        /// </exception>
        TVM Create<TVM, TV>()
            where TV : class, IView<TVM>
            where TVM : class, IViewModel<TV>;
    }
}
