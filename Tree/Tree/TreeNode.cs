using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public delegate int Comparator<T>(T a, T b);
    public class TreeNode<T>
    {
        List<TreeNode<T>> _children = new List<TreeNode<T>>();
        public T item;
        private WeakReference<TreeNode<T>>? _parent;
        public delegate void Visitor(TreeNode<T> n);

        public int ChildCount
        {
            get { return _children.Count; }
        }
        public TreeNode<T>? Parent
        {
            get { return GetParent(); }
            set { SetParent(value); }
        }

        

        public TreeNode()
        {
        }

        public TreeNode(TreeNode<T> parent, List<TreeNode<T>> children, T item)
        {
            _parent = new WeakReference<TreeNode<T>>(parent);
            _children = children;
            this.item = item;
        }


        TreeNode<T>? GetParent()
        {
            if (_parent == null)
                return null;
            TreeNode<T>? result;
            _parent.TryGetTarget(out result);
            return result;
        }

        public void SetParent(TreeNode<T>? newParent)
        {
            Unlink();
            if (newParent != null)
                newParent.AddChild(this);
        }
        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
                return;
            child._parent = new WeakReference<TreeNode<T>>(this);
            _children.Add(child);
        }

        public void Unlink()
        {
            var p = GetParent();
            if (p == null)
                return;

            int index = GetIndexOf(this);
            p._children.RemoveAt(index);
            _parent = null;
        }

        int GetIndexOf(TreeNode<T> value)
        {
            for(int i = 0; i < _children.Count; i++)
            {
                if (value == _children[i])
                    return i;
            }
            return -1;
        }
        public TreeNode<T> GetRoot()
        {
            var p = Parent;
            if (p == null)
                return this;
            return p.GetRoot();
        }

        

        public void Visit(Visitor visitor)
        {
            visitor(this);

            foreach(TreeNode<T> n in _children)
            {
                n.Visit(visitor);
            }
        }

        public TreeNode<T>? FindNodeWithItem(T value, Comparator<T> c)
        {
            if (c(item, value) == 0)
                return this;
            
            foreach(var child in _children)
            {
                var ch = child.FindNodeWithItem(value, c);
                if (ch != null)
                    return ch;
            }

            return null;
        }

        public bool Contains(T value, Comparator<T> comp)
        {
            return FindNodeWithItem(value, comp) != null;
        }
    }
}
