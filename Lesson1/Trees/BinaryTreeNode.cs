using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Trees
{
    /// <summary>
    /// Узел бинарного дерева
    /// </summary>
    public class BinaryTreeNode<T>
    {
        T Value;
        BinaryTreeNode<T> LeftChild;
        BinaryTreeNode<T> RightChild;
    }
}
