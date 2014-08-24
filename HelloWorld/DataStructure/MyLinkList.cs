// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyLinkList.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld.DataStructure
{
    using System;
    using System.Text;

    /// <summary>
    ///     Link type
    /// </summary>
    [Flags]
    public enum LinkListType
    {
        /// <summary>
        /// </summary>
        SingleLink = 1, 

        /// <summary>
        /// </summary>
        DoubleLink = 2, 

        /// <summary>
        /// </summary>
        Circulate = 4, 

        /// <summary>
        /// </summary>
        Default = SingleLink, 
    }

    /// <summary>
    ///     use for multi-type link list
    /// </summary>
    public class MyLinkList
    {
        #region Fields

        /// <summary>
        ///     current list size
        /// </summary>
        internal int _count = 0;

        /// <summary>
        ///     this linkedlist's type
        /// </summary>
        internal LinkListType _listType = LinkListType.Default;

        /// <summary>
        ///     list head
        /// </summary>
        internal LinkListNode head = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyLinkList"/> class.
        /// </summary>
        public MyLinkList()
        {
            this.CreatSingleLink();
        }

        /// <summary>
        ///     Create a new list
        /// </summary>
        /// <param name="type">list type</param>
        public MyLinkList(LinkListType type)
        {
            this._listType = type;
            if ((int)type == 1)
            {
                this.CreatSingleLink();
            }
            else if ((int)type == 2)
            {
                this.CreatDoubleLink();
            }
            else if ((int)type == 5)
            {
                this.CreatSingleLink();
                this.CreatCirculateLink(this.head);
            }
            else if ((int)type == 6)
            {
                this.CreatDoubleLink();
                this.CreatCirculateLink(this.head);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count
        {
            get
            {
                return this._count;
            }

            set
            {
                this._count = value;
            }
        }

        /// <summary>
        /// Gets or sets the list type.
        /// </summary>
        public LinkListType ListType
        {
            get
            {
                return this._listType;
            }

            set
            {
                this._listType = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Merge two same type list
        /// </summary>
        /// <param name="list1">input list 1</param>
        /// <param name="list2">input list 2</param>
        public static void Merge(MyLinkList list1, MyLinkList list2)
        {
            if (list1.ListType != list2.ListType)
            {
                return;
            }

            LinkListNode node = list1.head;
            for (int i = 0; i < list1.Count; i++)
            {
                node = node.Next;
            }

            node._next = list2.head.Next;
            list1.Count += list2.Count;

            if ((list1.ListType & LinkListType.DoubleLink) == LinkListType.DoubleLink)
            {
                list2.head._next._previous = node;
            }
            else if ((list1.ListType & LinkListType.Circulate) == LinkListType.Circulate)
            {
                LinkListNode tmp = list2.head;
                for (int i = 0; i < list2.Count; i++)
                {
                    tmp = tmp.Next;
                }

                tmp._next = list1.head._next;
            }
        }

        /// <summary>
        ///     reverse the list
        /// </summary>
        /// <param name="list">import list</param>
        public static void Reverse(MyLinkList list)
        {
            if (list.Count == 0 || list.Count == 1)
            {
                return;
            }

            LinkListNode nodeNow = list.head.Next;
            LinkListNode nodePre = null;
            LinkListNode nodeNext = list.head.Next;
            int count = list.Count;
            while (nodeNext != null && count != 0)
            {
                nodeNow = nodeNext;
                nodeNext = nodeNow.Next;
                nodeNow._next = nodePre;
                nodePre = nodeNow;
                count--;
            }

            if ((list.ListType & LinkListType.Circulate) == LinkListType.Circulate)
            {
                list.head._next._next = nodeNow;
            }

            list.head._next = nodeNow;
        }

        /// <summary>
        ///     add a new item
        /// </summary>
        /// <param name="item">new item</param>
        public void Add(LinkListNode item)
        {
            this.AddNewItem(item, this.Count);
        }

        /// <summary>
        ///     add a new item after kth item
        /// </summary>
        /// <param name="item">new item</param>
        /// <param name="index">index of k</param>
        public void Add(LinkListNode item, int index)
        {
            this.AddNewItem(item, index);
        }

        /// <summary>
        ///     delete an item at index k
        /// </summary>
        /// <param name="index">index k</param>
        public void Delete(int index)
        {
            this.RemoveAt(index);
        }

        /// <summary>
        ///     remove the node after this
        /// </summary>
        /// <param name="node">this node</param>
        public void Delete(LinkListNode node)
        {
            this.RemoveNextNode(node);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            LinkListNode node = this.head.Next;
            var sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                if (node != null)
                {
                    sb.Append("No." + (i + 1) + "\tValue: " + node.Data + "\n");
                    node = node.Next;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        ///     get item at index k
        /// </summary>
        /// <param name="index">index k</param>
        /// <returns></returns>
        public LinkListNode ValueAt(int index)
        {
            LinkListNode curNode = this.GetNode(index);
            return curNode;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     add a new item after index k
        /// </summary>
        /// <param name="send">new item</param>
        /// <param name="index">index k</param>
        private void AddNewItem(LinkListNode send, int index)
        {
            if (index > this.Count)
            {
                index = index % (this.Count + 1) + 1;
            }

            var item = new LinkListNode(this, send.Data);
            LinkListNode node = this.head;
            for (int i = 0; i < index; i++)
            {
                if (node == null)
                {
                    return;
                }

                node = node.Next;
            }

            LinkListNode originalNext = node.Next;
            node._next = item;
            item._next = originalNext;

            if ((this._listType & LinkListType.DoubleLink) == LinkListType.DoubleLink)
            {
                item._previous = node;
                if (originalNext != null)
                {
                    originalNext._previous = item;
                }
            }

            this.Count++;
        }

        /// <summary>
        ///     CreatCirculateLink
        /// </summary>
        /// <param name="head">turn head item type</param>
        private void CreatCirculateLink(LinkListNode head)
        {
            head._listType = this._listType;
            head._next = head;
            head._previous = head;
        }

        /// <summary>
        ///     CreatDoubleLink
        /// </summary>
        private void CreatDoubleLink()
        {
            this.head = new LinkListNode(this, -1);
        }

        /// <summary>
        ///     CreatSingleLink
        /// </summary>
        private void CreatSingleLink()
        {
            this.head = new LinkListNode(this, -1);
        }

        /// <summary>
        ///     get the index item
        /// </summary>
        /// <param name="index">index k</param>
        /// <returns></returns>
        private LinkListNode GetNode(int index)
        {
            index = index % (this.Count + 1);

            LinkListNode node = this.head;
            for (int i = 0; i < index; i++)
            {
                if (node == null)
                {
                    return node;
                }

                node = node.Next;
            }

            return node;
        }

        /// <summary>
        ///     delete the index item
        /// </summary>
        /// <param name="index">index k</param>
        private void RemoveAt(int index)
        {
            if (index > this.Count)
            {
                index = index % (this.Count + 1) + 1;
            }

            LinkListNode node = this.head;
            for (int i = 0; i < index - 1; i++)
            {
                if (node == null)
                {
                    return;
                }

                node = node.Next;
            }

            LinkListNode removeItem = node.Next;
            LinkListNode newNext = removeItem.Next;

            node._next = newNext;
            if ((this._listType & LinkListType.DoubleLink) == LinkListType.DoubleLink)
            {
                newNext._previous = node;
            }

            this.Count--;
        }

        /// <summary>
        ///     remove the next node after this
        /// </summary>
        /// <param name="node">node</param>
        private void RemoveNextNode(LinkListNode node)
        {
            if (node.Next == node.List.head.Next)
            {
                node.List.head._next = node.Next.Next;
            }

            node._next = node.Next.Next;
            if ((node.ListType & LinkListType.DoubleLink) == LinkListType.DoubleLink)
            {
                node.Next._previous = node;
            }

            this.Count--;
        }

        #endregion
    }

    /// <summary>
    ///     use for link node
    ///     data type int
    /// </summary>
    public class LinkListNode
    {
        #region Fields

        /// <summary>
        ///     Get the node belong to which list
        /// </summary>
        internal MyLinkList _list = null;

        /// <summary>
        ///     Get or Set LinkListType.
        /// </summary>
        internal LinkListType _listType = LinkListType.Default;

        /// <summary>
        ///     Get the next node.
        /// </summary>
        internal LinkListNode _next = null;

        /// <summary>
        ///     Get the before node.
        /// </summary>
        internal LinkListNode _previous = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     A default type node
        /// </summary>
        /// <param name="data">data value</param>
        public LinkListNode(int data)
        {
            this.Data = data;
        }

        /// <summary>
        ///     appoint list node
        /// </summary>
        /// <param name="list">belong to list</param>
        /// <param name="data">data value</param>
        public LinkListNode(MyLinkList list, int data)
        {
            this._list = list;
            this._listType = list.ListType;
            this.Data = data;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public int Data { get; set; }

        /// <summary>
        /// Gets the list.
        /// </summary>
        public MyLinkList List
        {
            get
            {
                return this._list;
            }
        }

        /// <summary>
        /// Gets or sets the list type.
        /// </summary>
        public LinkListType ListType
        {
            get
            {
                return this._listType;
            }

            set
            {
                this._listType = value;
            }
        }

        /// <summary>
        /// Gets the next.
        /// </summary>
        public LinkListNode Next
        {
            get
            {
                if (this._next == this._list.head)
                {
                    return this._next._next;
                }

                return this._next;
            }
        }

        /// <summary>
        /// Gets the previous.
        /// </summary>
        public LinkListNode Previous
        {
            get
            {
                if (this._previous == this._list.head)
                {
                    return this._previous._previous;
                }

                return this._previous;
            }
        }

        #endregion
    }
}