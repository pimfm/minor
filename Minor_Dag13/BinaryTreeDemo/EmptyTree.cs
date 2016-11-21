using System;
using System.Collections.Generic;

namespace BinaryTreeDemo
{
    internal class EmptyTree<T> : Tree<T>
        where T : IComparable
    {
        private static Tree<T> _instance = new EmptyTree<T>();

        public static Tree<T> Instance
        {
            get { return _instance; }
        }

        public override int Count
        {
            get { return 0; }
        } 

        public override int Depth
        {
            get { return 0; }
        }
        
        public static Tree<T> GetInstance()
        {
            return _instance;
        }

        public override Tree<T> Add(T value)
        {
            return new Branch<T>(value);
        }

        public override bool Contains(T value)
        {
            return false;
        }
    }
}
