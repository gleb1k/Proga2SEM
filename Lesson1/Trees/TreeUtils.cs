using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Trees
{
    public static class TreeUtils<T>
    {
        /// <summary>
        /// Обход дерева вроде
        /// </summary>
        /// <param name="root"></param>
        public static void BreadthFirstSearch(TreeNode<T> root)
        {
            List<TreeNode<T>> toVist = new List<TreeNode<T>>();
            toVist.Add(root);
            while (toVist.Any())
            {
                var current = toVist.First();
                toVist.RemoveAt(0);
                if (current.HasChild())
                    toVist.AddRange(current.ChildNodeList);
                Console.WriteLine(current.Value.ToString());
            }
        }
        /// <summary>
        /// Поиск высоты в бинарном дереве (для авл тоже работает)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int GetHeight(BinaryTreeNode<T> root)
        {
            if (root == null)
                return 0;
            else return 1 + Math.Max(
                GetHeight(root.LeftChild),
                GetHeight(root.RightChild));
        }
    }
}
