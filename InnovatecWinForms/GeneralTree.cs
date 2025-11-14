using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovatecWinForms
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; private set; }
        public TreeNode<T> Parent { get; private set; }

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
            Parent = null;
        }

        public void AddChild(TreeNode<T> child)
        {
            child.Parent = this;
            Children.Add(child);
        }
    }

    public class GeneralTree<T>
    {
        public TreeNode<T> Root { get; private set; }

        public GeneralTree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }

        public bool Insert(T parentValue, T newValue)
        {
            var parentNode = SearchNode(Root, parentValue);
            if (parentNode == null) return false;

            parentNode.AddChild(new TreeNode<T>(newValue));
            return true;
        }

        public TreeNode<T> SearchNode(TreeNode<T> node, T value)
        {
            if (node == null) return null;
            if (EqualityComparer<T>.Default.Equals(node.Value, value)) return node;

            foreach (var child in node.Children)
            {
                var found = SearchNode(child, value);
                if (found != null) return found;
            }

            return null;
        }

        
        public bool Contains(T value)
        {
            return SearchNode(Root, value) != null;
        }

        public int Count()
        {
            return CountNodes(Root);
        }

        private int CountNodes(TreeNode<T> node)
        {
            if (node == null) return 0;

            int total = 1;
            foreach (var child in node.Children)
            {
                total += CountNodes(child);
            }
            return total;
        }

        public int LevelOf(T value)
        {
            return FindLevel(Root, value, 0);
        }

        private int FindLevel(TreeNode<T> node, T value, int level)
        {
            if (node == null) return -1;
            if (EqualityComparer<T>.Default.Equals(node.Value, value)) return level;

            foreach (var child in node.Children)
            {
                int result = FindLevel(child, value, level + 1);
                if (result != -1) return result;
            }

            return -1;
        }
    }
}
