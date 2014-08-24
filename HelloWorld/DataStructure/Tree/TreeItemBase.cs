// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeItemBase.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld.DataStructure.Tree
{
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public class TreeItemBase<T>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeItemBase{T}"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public TreeItemBase(T data)
        {
            this.Data = data;
            this.Children = new List<TreeItemBase<T>>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        public List<TreeItemBase<T>> Children { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T Data { get; set; }

        #endregion
    }
}