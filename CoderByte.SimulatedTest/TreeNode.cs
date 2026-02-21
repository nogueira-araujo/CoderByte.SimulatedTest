using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;

namespace CoderByte.SimulatedTest
{

    public class TreeNode
    {
        private TreeNode parent;
        private int value;
        private List<TreeNode> children;

        public TreeNode Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        public int Value { get => value; set => this.value = value; }
        public List<TreeNode> Children { get => children; set => children = value; }

        public TreeNode(int value)
        {
            this.Children = new List<TreeNode>();
            this.parent = null;
            this.Value = value;
        }
        public TreeNode(TreeNode parent, int value) : this(value)
        {
            this.parent = parent;
            this.parent.children.Add(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is TreeNode other)
            {
                return this.Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static void ReadTreeFromAboveToBelow(TreeNode node, int level = 0)
        {
            if (node != null)
            {
                Console.WriteLine(new string(' ', level * 2) + node.Value);
                foreach (var child in node.Children)
                {
                    ReadTreeFromAboveToBelow(child, level + 1);
                }
            }
        }

        public static void ReadTreeFromBelowToAbove(TreeNode node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                if (node.Parent != null)
                {
                    ReadTreeFromBelowToAbove(node.Parent);
                }
            }
        }
    }
}
