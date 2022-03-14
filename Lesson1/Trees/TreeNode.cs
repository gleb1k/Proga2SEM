using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Trees
{
    /// <summary>
    /// Узел дерева
    /// </summary>
    public class TreeNode<T>
    {
        T Value;
        List<T> ChildNodeList;
        public TreeNode(T value, List<T> child )
        {
            Value = value;
            ChildNodeList = child;
        }
    }
}
