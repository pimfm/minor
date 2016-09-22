using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeDemo
{
    public abstract class Tree<T> : IEnumerable<T>
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

        public abstract T this[int index] { get; }

        public abstract T Find(T value);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}