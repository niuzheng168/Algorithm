// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrieTree.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace HelloWorld.AdvancedDataStructure.Tree.TrieTree
{
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public class TrieTree
    {
        #region Constants

        /// <summary>
        /// </summary>
        public const int RootFloorValue = -1;

        #endregion

        #region Fields

        /// <summary>
        /// </summary>
        private readonly TrieTreeItem _root;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TrieTree" /> class.
        /// </summary>
        public TrieTree()
            : this(false)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TrieTree" /> class.
        /// </summary>
        /// <param name="isCaseSensitive">
        ///     The is case sensitive.
        /// </param>
        public TrieTree(bool isCaseSensitive)
        {
            this._root = new TrieTreeItem('#', null, RootFloorValue, false);
            this.IsCaseSensitive = false;
            this.TreeItemCount = 0;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets a value indicating whether is case sensitive.
        /// </summary>
        public bool IsCaseSensitive { get; set; }

        /// <summary>
        ///     Gets or sets the tree item count.
        /// </summary>
        public int TreeItemCount { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="item">
        ///     The item.
        /// </param>
        /// <returns>
        /// </returns>
        public bool Delete(string word)
        {
            if (this.IsCaseSensitive)
            {
                word = word.ToLower();
            }

            TrieTreeItem findResult = this.IsInTree(word, false);

            if (findResult == null)
            {
                return false;
            }

            TrieTreeItem curNode = findResult;

            while (curNode != null)
            {
                TrieTreeItem curFather = curNode.Father;

                if (curNode.IsTerminal && curNode.Children.Count == 0)
                {
                    curFather.Children.Remove(curNode.Ch);
                }
                else if (curNode.IsTerminal && curNode.Children.Count != 0)
                {
                    if (curNode.Floor == findResult.Floor)
                    {
                        curNode.IsTerminal = false;
                    }
                }
                else if (!curNode.IsTerminal && curNode.Children.Count != 0)
                {
                    continue;
                    ;
                }
                else if (!curNode.IsTerminal && curNode.Children.Count == 0)
                {
                    curFather.Children.Remove(curNode.Ch);
                }

                curNode = curFather;
            }

            this.TreeItemCount--;

            return true;

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="str">
        ///     The str.
        /// </param>
        /// <returns>
        /// </returns>
        public TrieTreeItem Find(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return null;
            }

            if (this.IsCaseSensitive)
            {
                word = word.ToLower();
            }

            TrieTreeItem result = this.IsInTree(word, true);

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="item">
        ///     The item.
        /// </param>
        /// <returns>
        /// </returns>
        public TrieTreeItem Insert(string word)
        {
            if (this.IsCaseSensitive)
            {
                word = word.ToLower();
            }

            TrieTreeItem result = this.IsInTree(word, true);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public List<string> ToList()
        {
            var wordList = new List<string>();

            this.ParseNode(this._root, wordList);

            return wordList;
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="str">
        ///     The str.
        /// </param>
        /// <param name="isInsert">
        ///     The is insert.
        /// </param>
        /// <returns>
        /// </returns>
        private TrieTreeItem IsInTree(string str, bool isInsert)
        {
            int floor = RootFloorValue + 1;
            int start = floor;
            int end = str.Length - 1;

            TrieTreeItem curRoot = this._root;
            bool isFound = true;
            for (int i = 0; i < end; i++)
            {
                string curChar = str[i].ToString();
                isFound = curRoot.Children.ContainsKey(curChar);
                if (isFound)
                {
                    floor++;
                    curRoot = curRoot.Children[curChar];
                }
                else
                {
                    break;
                }
            }

            // check last is terminal
            if (isFound)
            {
                string curChar = str[end].ToString();
                isFound = curRoot.Children.ContainsKey(curChar) && curRoot.Children[curChar].IsTerminal;
            }

            if (isFound)
            {
                return curRoot;
            }

            if (isInsert)
            {
                start = floor;
                for (int j = start; j < end; j++)
                {
                    char curChar = str[j];
                    var treeItem = new TrieTreeItem(curChar, curRoot, floor, false);
                    curRoot.Children.Add(curChar.ToString(), treeItem);
                    curRoot = treeItem;
                    floor++;
                }

                // insert last char as terminal node
                char lastChar = str[end];
                if (curRoot.Children.ContainsKey(lastChar.ToString()))
                {
                    curRoot.Children[lastChar.ToString()].IsTerminal = true;
                    return curRoot.Children[lastChar.ToString()];
                }

                var terminalTreeItem = new TrieTreeItem(lastChar, curRoot, floor, true);
                curRoot.Children.Add(lastChar.ToString(), terminalTreeItem);
                return terminalTreeItem;
            }

            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="root">
        /// The root.
        /// </param>
        /// <param name="wordList">
        /// The word list.
        /// </param>
        private void ParseNode(TrieTreeItem root, List<string> wordList)
        {
            foreach (var pair in root.Children)
            {
                if (pair.Value.IsTerminal)
                {
                    wordList.Add(pair.Value.Word);
                }

                this.ParseNode(pair.Value, wordList);
            }
        }

        #endregion
    }
}