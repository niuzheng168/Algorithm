// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyHeap.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld.DataStructure
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class MyHeap<T>
    {
        #region Fields

        /// <summary>
        /// </summary>
        private readonly Comparison<T> _cmp;

        /// <summary>
        /// </summary>
        private readonly List<T> _list;

        /// <summary>
        /// </summary>
        private int _count;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyHeap{T}"/> class.
        /// </summary>
        /// <param name="cmp">
        /// The cmp.
        /// </param>
        public MyHeap(Comparison<T> cmp)
        {
            this._cmp = cmp;
            this._list = new List<T>();
            this._count = 0;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the items.
        /// </summary>
        public List<T> Items
        {
            get
            {
                return this._list;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Insert(T item)
        {
            int targetIndex = this._count;
            int fatheIndex = (this._count - 1) / 2;
            while (targetIndex > 0 && this._cmp(item, this._list[fatheIndex]) == 1)
            {
                this._list[targetIndex] = this._list[fatheIndex];
                targetIndex = fatheIndex;
                fatheIndex = (targetIndex - 1) / 2;
            }

            this._list[targetIndex] = item;
            this._count++;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public T Pop()
        {
            T item = default(T);
            if (this._count != 0)
            {
                item = this._list[0];
                this._list[0] = this._list[this._count - 1];
                this._count--;
                this.AdjustHeap(0, this._count);
            }
            else
            {
                Helper.ThorwArgumentCurrentSize(
                    ExceptionArgument.CollectionCurrentSize, 
                    ExceptionResource.CurrentSizeIsZero);
            }

            return item;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public T Top()
        {
            T item = default(T);
            if (this._count != 0)
            {
                item = this._list[0];
            }
            else
            {
                Helper.ThorwArgumentCurrentSize(
                    ExceptionArgument.CollectionCurrentSize, 
                    ExceptionResource.CurrentSizeIsZero);
            }

            return item;
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="n">
        /// The n.
        /// </param>
        /// <param name="total">
        /// The total.
        /// </param>
        private void AdjustHeap(int n, int total)
        {
            T tmp;
            tmp = this._list[n];
            int lt = n * 2 + 1;
            while (lt < total)
            {
                int rt = lt + 1;
                int selected = lt;
                if (rt > total)
                {
                    selected = lt;
                }
                else
                {
                    int cmpResult = this._cmp(this._list[lt], this._list[rt]);
                    if (cmpResult > 0)
                    {
                        selected = lt;
                    }
                    else
                    {
                        selected = rt;
                    }
                }

                this._list[n] = this._list[selected];
                n = selected;
                lt = n * 2 + 1;
            }

            this._list[n] = tmp;
        }

        /// <summary>
        /// </summary>
        private void BuildHeap()
        {
        }

        #endregion
    }
}