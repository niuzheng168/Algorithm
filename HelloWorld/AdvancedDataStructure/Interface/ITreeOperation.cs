// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITreeOperation.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace HelloWorld.AdvancedDataStructure.Interface
{
    /// <summary>
    /// </summary>
    public interface ITreeOperation<T>
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// </returns>
        bool Delete(object item);

        /// <summary>
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// </returns>
        T Find(object item);

        /// <summary>
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// </returns>
        T Insert(object item);

        #endregion
    }
}