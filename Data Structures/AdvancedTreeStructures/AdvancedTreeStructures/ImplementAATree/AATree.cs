using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementAATree
{
    public class AATree<T>
        where T : IComparable
    {
        private TreeNode<T> root;

        public bool Add(T element)
        {
            var newNode = new TreeNode<T>(element);

            if (this.root == null)
            {
                this.root = newNode;
                return true;
            }

            return this.AddToNode(this.root, newNode);
        }

        public bool Delete(T element)
        {
            return this.DeleteFromTree(element, this.root);
        }

        public void PrintToConsole()
        {
            if (this.root != null)
            {
                this.root.Print();
            }
        }

        private bool AddToNode(TreeNode<T> node, TreeNode<T> newNode)
        {
            bool isAdded = false;

            if (node == null)
            {
                node = newNode;
                isAdded = true;
            }
            else if (node.Value.Equals(newNode.Value))
            {
                isAdded = true;
                return false;
            }
            else if (newNode.Value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = newNode;
                    newNode.Parent = node;
                    isAdded = true;
                }
                else
                {
                    isAdded = this.AddToNode(node.Left, newNode);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = newNode;
                    newNode.Parent = node;
                    isAdded = true;
                }
                else
                {
                    isAdded = this.AddToNode(node.Right, newNode);
                }
            }

            this.Skew(node);
            this.Split(node);

            return isAdded;
        }  
        
        private bool DeleteFromTree(T element, TreeNode<T> node)
        {
            bool result = false;

            if (node == null)
            {
                result = false;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                result = this.DeleteFromTree(element, node.Left);
            }
            else if ( element.CompareTo(node.Value) > 0)
            {
                result = this.DeleteFromTree(element, node.Right);
            }
            else
            {
                result = true;

                if (node.Left == null && node.Right == null)
                {
                    if (node.Parent == null)
                    {
                        this.root = null;
                    }
                    else if (node.Parent.Left == node)
                    {
                        node.Parent.Left = null;
                    }
                    else if (node.Parent.Right == node)
                    {
                        node.Parent.Right = null;
                    }

                    node = null;
                }
                else if (node.Left == null)
                {
                    node.Value = node.Right.Value;
                    this.DeleteFromTree(node.Right.Value, node.Right);
                }
                else
                {
                    node.Value = node.Left.Value;
                    this.DeleteFromTree(node.Left.Value, node.Left);
                }
            }

            this.DecreaseLevel(node);
            this.Skew(node);
            if (node != null)
            {
                this.Skew(node.Right);
            }

            if (node != null && node.Right != null)
            {
                this.Skew(node.Right.Right);
            }

            this.Split(node);
            if (node != null)
            {
                this.Split(node.Right);
            }

            return result;
        }

        private void DecreaseLevel(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            int expectedLevel;

            if (node.Left == null && node.Right == null)
            {
                expectedLevel = 1;
            }
            else if (node.Left != null && node.Right == null)
            {
                expectedLevel = node.Left.Level + 1;
            }
            else if (node.Left == null && node.Right != null)
            {
                expectedLevel = node.Right.Level + 1;
            }
            else
            {
                expectedLevel = Math.Min(node.Left.Level, node.Right.Level) + 1;
            }

            if (expectedLevel < node.Level)
            {
                node.Level = expectedLevel;

                if (node.Right != null && expectedLevel < node.Right.Level)
                {
                    node.Right.Level = expectedLevel;
                }
            }
        }
        
        private void Skew(TreeNode<T> node)
        {
            if (node == null || node.Left == null)
            {
                return;
            }

            if (node.Level == node.Left.Level)
            {
                var left = node.Left;

                node.Left = left.Right;
                if (node.Left != null)
                {
                    node.Left.Parent = node;
                }

                left.Right = null;

                var parent = node.Parent;
                left.Parent = parent;
                if (parent != null)
                {
                    if (parent.Left == node)
                    {
                        parent.Left = left;
                    }
                    else if (parent.Right == node)
                    {
                        parent.Right = left;
                    }
                    else
                    {
                        throw new InvalidOperationException(
                          "An error in tree structure occured");
                    }
                }

                node.Parent = left;

                left.Right = node;

                if (this.root == node)
                {
                    this.root = left;
                }
            }
        }

        private void Split(TreeNode<T> node)
        {
            if (node == null || node.Right == null || node.Right.Right == null)
            {
                return;
            }

            if (node.Level == node.Right.Right.Level)
            {
                var middle = node.Right;
                var parent = node.Parent;

                middle.Parent = parent;
                if (parent != null)
                {
                    if (parent.Left == node)
                    {
                        parent.Left = middle;
                    }
                    else if (parent.Right == node)
                    {
                        parent.Right = middle;
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            "An error in tree structure occured");
                    }
                }

                var left = middle.Left;

                middle.Left = node;
                node.Parent = middle;

                node.Right = left;
                if (left != null)
                {
                    left.Parent = node;
                }

                middle.Level++;

                if (this.root == node)
                {
                    this.root = middle;
                }
            }
        }

        private class TreeNode<T>
        where T : IComparable
        {
            public TreeNode(T value)
            {
                this.Value = value;
                this.Level = 1;
            }

            public T Value { get; set; }

            public int Level { get; set; }

            public TreeNode<T> Left { get; set; }

            public TreeNode<T> Right { get; set; }

            public TreeNode<T> Parent { get; set; }

            public void Print(int indent = 0)
            {
                Console.Write(new string(' ', 2 * indent));
                Console.WriteLine(this.Value);
                if (this.Left != null)
                {
                    this.Left.Print(indent + 1);
                }

                if (this.Right != null)
                {
                    this.Right.Print(indent + 1);
                }
            }

        }
    }
}
