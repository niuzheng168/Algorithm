// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnionFindSet.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld.DataStructure
{
    using System;

    /// <summary>
    /// </summary>
    public class UnionFindSet<T>
        where T : IEquatable<T>
    {
        /// <summary>
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void MakeSet(UnionFindSetItem<T> item)
        {
            item.Parent = item;
            item.Rank = 1;
        }

        /// <summary>
        /// </summary>
        /// <param name="item1">
        /// The item 1.
        /// </param>
        /// <param name="item2">
        /// The item 2.
        /// </param>
        public void Union(UnionFindSetItem<T> item1, UnionFindSetItem<T> item2)
        {
            var parent1 = this.Find(item1);
            var parent2 = this.Find(item2);
            if (parent1.Equals(parent2))
            {
                return;
            }

            if (item1.Rank < item2.Rank)
            {
                item1.Parent = item2;
            }
            else if (item1.Rank > item2.Rank)
            {
                item2.Parent = item1;
            }
            else
            {
                item2.Parent = item1;
                item1.Rank++;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// </returns>
        public UnionFindSetItem<T> Find(UnionFindSetItem<T> item)
        {
            UnionFindSetItem<T> res = item;
            if (!res.Parent.Equals(res))
            {
                res.Parent = this.Find(res.Parent);
            }

            return res;
        }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnionFindSetItem<T>
        where T : IEquatable<T>
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the parent.
        /// </summary>
        public UnionFindSetItem<T> Parent { get; set; }

        /// <summary>
        ///     Gets or sets the rank.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        ///     Gets or sets the item.
        /// </summary>
        public T Item { get; set; }

        #endregion
    }
}