// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyQueue.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld.BasicDataStructure
{
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class MyQueue<T>
    {
        #region Fields

        /// <summary>
        /// </summary>
        protected int _count;

        /// <summary>
        /// </summary>
        protected int _head;

        /// <summary>
        /// </summary>
        protected int _size;

        /// <summary>
        /// </summary>
        protected int _tail;

        /// <summary>
        /// </summary>
        private readonly List<T> _queue;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyQueue{T}"/> class.
        /// </summary>
        public MyQueue()
        {
            this._queue = new List<T>();
            this._count = 0;
            this._head = 0;
            this._tail = 0;
            this._size = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyQueue{T}"/> class.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        public MyQueue(int size)
        {
            if (size < 0)
            {
                Helper.ThrowArgumentOutOfRangeException(
                    ExceptionArgument.capacity, 
                    ExceptionResource.ArgumentOutOfRange_NeedNonNegNumRequired);
            }

            this._queue = new List<T>(size);
            this._count = 0;
            this._head = 0;
            this._tail = 0;
            this._size = size;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count
        {
            get
            {
                return this._count;
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public int Size
        {
            get
            {
                return this._size;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public T Pop()
        {
            T item = this._queue[this._head];
            this._queue[this._head] = default(T);
            if (this._size != -1)
            {
                this._head++;
            }
            else
            {
                this._head = (this._head + 1) % this._count;
            }

            this._count--;

            return item;
        }

        /// <summary>
        /// </summary>
        /// <param name="itme">
        /// The itme.
        /// </param>
        public void Push(T itme)
        {
            if (this._size != -1)
            {
                this._queue[this._tail] = itme;
                this._tail++;
                this._count++;
            }
            else
            {
                if (this._tail == this._head)
                {
                    Helper.ThrowArgumentCapacityIsFull(
                        ExceptionArgument.capacity, 
                        ExceptionResource.Capacity_CapacityIsFull);
                }

                this._queue[this._tail] = itme;
                this._tail = (this._tail + 1) % this._size;
                this._count++;
                if (this._count > this._size)
                {
                    this._count = this._size;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public List<T> ToList()
        {
            var targetList = new List<T>();
            if (this._head < this._tail)
            {
                for (int i = this._head; i < this._tail; i++)
                {
                    targetList.Add(this._queue[i]);
                }

                return targetList;
            }

            for (int i = this._head; i < this._size; i++)
            {
                targetList.Add(this._queue[i]);
            }

            for (int i = 0; i < this._tail; i++)
            {
                targetList.Add(this._queue[i]);
            }

            return targetList;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public T Top()
        {
            T item = this._queue[this._head];
            return item;
        }

        #endregion
    }
}