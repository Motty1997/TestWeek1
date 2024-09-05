using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1.Models
{
    internal class BSTree
    {
        public TreeNode Root { get; set; }


        public void Insert(DefenceModel value)
        {
            Root = InsertRecursive(Root, value);
        }


        private TreeNode? InsertRecursive(TreeNode? node, DefenceModel value)
        {
            if (node == null)
            {
                return new TreeNode() { Value = value };
            }

            if (value == node.Value)
            {
                return node;
            }
            if (value.MinSeverity < node.Value.MinSeverity)
            {
                node.Left = InsertRecursive(node.Left, value);
            }
            else
            {
                node.Right = InsertRecursive(node.Right, value);
            }
            return node;
        }


        public List<string> PreOrderTraversal() => PreOrderTraversalHelper(Root);

        private List<string> PreOrderTraversalHelper(TreeNode? node)
        {
            if (node == null) { return []; }

            var currentNodeList = new List<string> { node.Value.Defenses.Aggregate(string.Empty, (str, next) => str + ", " + next) };

            var leftSubtreeList = PreOrderTraversalHelper(node.Left);

            var rightSubtreeList = PreOrderTraversalHelper(node.Right);

            return [.. currentNodeList, .. leftSubtreeList, .. rightSubtreeList];
        }

        public string Search(Threat value)
        {
            return SearchRecursive(Root, value);
        }

        private string SearchRecursive(TreeNode? node, Threat value)
        {
            if(node == null)
                {
                    return "Attack severity is below the threshold Attack is ignored.";
                }

            if (value.SeverityCalculation() < node.Value.MinSeverity)
            {
                return SearchRecursive(node.Left, value);
            }
            else if(value.SeverityCalculation() >= node.Value.MinSeverity && value.SeverityCalculation() <= node.Value.MaxSeverity)
            {

                return $"================\n\n defenses for attack is: {string.Join(", ", node.Value.Defenses!)} \n";
            }
            else
            {
                return SearchRecursive(node.Right, value);
            }
        }

        public void PrintTree()
        {
            PrintTreeRec(Root, "", true, "Root");
        }
        private void PrintTreeRec(TreeNode node, string indent, bool last, string position)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("└──");
                    indent += " ";
                }
                else
                {
                    Console.Write("├──");
                    indent += "| ";
                }
                Console.WriteLine($"{position}: [{node.Value.MinSeverity}-{node.Value.MaxSeverity}] Defenses: {string.Join(", ", node.Value.Defenses)}");
                PrintTreeRec(node.Left, indent, false, "Left Child");
                PrintTreeRec(node.Right, indent, true, "Right Child");
            }
        }
    }
}
