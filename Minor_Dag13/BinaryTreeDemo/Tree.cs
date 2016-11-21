using System;

namespace BinaryTreeDemo
{
    public abstract class Tree<T>
        where T : IComparable
    {
        public abstract int Depth { get; }
        public abstract int Count { get; }

        public static Tree<T> Create()
        {
            return EmptyTree<T>.Instance;
        }

        public abstract Tree<T> Add(T value);

        public abstract bool Contains(T value);

        public abstract T Find(T value);
    }
}