namespace HelloWorld.Sort
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     The quick sort.
    /// </summary>
    public static class SortMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// The quick sort.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <param name="cmp">
        /// The cmp.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public static void QuickSort<T>(this IList<T> list, int left, int right, IComparer<T> cmp)
        {
            int i = left;
            int j = right;

            int pivotIndex = (left + right) / 2;
            T pivot = list[pivotIndex];

            while (i < j)
            {
                while (cmp.Compare(list[i], pivot) < 0)
                {
                    i++;
                }

                while (cmp.Compare(list[j], pivot) > 0)
                {
                    j--;
                }

                if (i < j)
                {
                    T tmp = list[i];
                    list[i] = list[j];
                    list[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(list, left, j, cmp);
            }

            if (j + 1 < right)
            {
                QuickSort(list, j + 1, right, cmp);
            }
        }

        /// <summary>
        /// The quick sort.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public static void QuickSort<T>(this IList<T> list, int left, int right) where T : IComparable<T>
        {
            int i = left;
            int j = right;

            int pivotIndex = (left + right) / 2;
            T pivot = list[pivotIndex];

            while (i < j)
            {
                while (list[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (list[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i < j)
                {
                    T tmp = list[i];
                    list[i] = list[j];
                    list[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(list, left, j);
            }

            if (j + 1 < right)
            {
                QuickSort(list, j + 1, right);
            }
        }

        /// <summary>
        /// The merge sort.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public static void MergeSort<T>(this IList<T> list) where T : IComparable<T>
        {
            if (list.Count <= 1)
            {
                return;
            }

            int mid = list.Count / 2;
            IList<T> LList = new List<T>();
            IList<T> RList = new List<T>();

            for (int i = 0; i < mid; i++)
            {
                LList.Add(list[i]);
            }

            for (int i = mid; i < list.Count; i++)
            {
                RList.Add(list[i]);
            }

            LList.MergeSort();
            RList.MergeSort();

            list.Clear();
            foreach (var item in MergeSort_MergeList(LList, RList))
            {
                list.Add(item);
            }
        }

        /// <summary>
        /// The merge sort_ merge list.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public static IList<T> MergeSort_MergeList<T>(IList<T> a, IList<T> b) where T : IComparable<T>
        {
            IList<T> list = new List<T>();

            int i, j;
            for (i = 0, j = 0; i < a.Count && j < b.Count;)
            {
                T item1 = a[i];
                T item2 = b[j];

                if (item1.CompareTo(item2) <= 0)
                {
                    list.Add(item1);
                    i++;
                }
                else
                {
                    list.Add(item2);
                    j++;
                }
            }

            if (i < a.Count)
            {
                for (; i < a.Count; i++)
                {
                    list.Add(a[i]);
                }
            }

            if (j < b.Count)
            {
                for (; j < b.Count; j++)
                {
                    list.Add(b[j]);
                }
            }

            return list;
        }

        #endregion
    }
}