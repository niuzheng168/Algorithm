// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeBase.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld.DataStructure.Tree
{
    using System;

    /// <summary>
    /// </summary>
    public class TreeBase<T>
    {
        #region Delegates

        /// <summary>
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        public delegate void DfsTreeNodeHitHandler(DfsHitNodeArgs<T> node);

        #endregion

        #region Public Events

        /// <summary>
        /// </summary>
        public event DfsTreeNodeHitHandler OnDfsTreeNodeHitEvent;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the root.
        /// </summary>
        public TreeItemBase<T> Root { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        protected virtual void BFS()
        {
        }

        /// <summary>
        /// </summary>
        protected virtual void DFS(TreeItemBase<T> root)
        {
            if (root == null)
            {
                return;
            }

            TreeItemBase<T> curNode = root;

            foreach (var child in curNode.Children)
            {
                this.DfsVisitNode(child);

                this.DFS(child);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="curNode">
        ///     The cur node.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        protected virtual void DfsVisitNode(TreeItemBase<T> curNode)
        {
            if (this.OnDfsTreeNodeHitEvent != null)
            {
                this.OnDfsTreeNodeHitEvent(new DfsHitNodeArgs<T>(curNode));
            }
        }

        #endregion
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class DfsHitNodeArgs<T>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DfsHitNodeArgs{T}"/> class.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        public DfsHitNodeArgs(TreeItemBase<T> node)
        {
            this.Node = node;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Gets or sets the node.
        /// </summary>
        public TreeItemBase<T> Node { get; set; }

        #endregion
    }
}