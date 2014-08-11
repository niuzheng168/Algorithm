// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyPriority_Queue.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld.AdvancedDataStructure
{
    using System;

    using HelloWorld.BasicDataStructure;

    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class MyPriorityQueue<T> : MyQueue<T>
    {
        #region Fields

        /// <summary>
        /// </summary>
        private readonly MyHeap<T> _heap;

        /// <summary>
        /// </summary>
        private Comparison<T> _cmp;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyPriorityQueue{T}"/> class.
        /// </summary>
        /// <param name="cmp">
        /// The cmp.
        /// </param>
        public MyPriorityQueue(Comparison<T> cmp)
        {
            this._cmp = cmp;
            this._heap = new MyHeap<T>(this._cmp);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the cmp.
        /// </summary>
        public Comparison<T> Cmp
        {
            set
            {
                this._cmp = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        #endregion
    }
}