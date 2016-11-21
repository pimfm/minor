using System;
using System.Collections.Generic;

namespace BinaryTreeDemo
{
    internal class Branch<T> : Tree<T>
        where T : IComparable
    {
        private T _value;
        private Tree<T> _leftBranch;
        private Tree<T> _rightBranch;

        public override int Count
        {
            get { return _leftBranch.Count + 1 + _rightBranch.Count; }
        }

        public override int Depth
        {
            get { return 1 + Math.Max(_leftBranch.Depth, _rightBranch.Depth); }
        }

        public Branch(T value)
        {
            _value = value;
            _leftBranch = Create();
            _rightBranch = Create();
        }

        public override Tree<T> Add(T value)
        {
            int compared = _value.CompareTo(value);

            if (compared < 0)
            {
                _rightBranch = _rightBranch.Add(value);
            } 
            else if (compared > 0)
            {
                _leftBranch = _leftBranch.Add(value);
            }

            return this;
        }

        public override bool Contains(T value)
        {
            int compared = _value.CompareTo(value);

            if (compared < 0)
            {
                return _rightBranch.Contains(value);
            }
            else if (compared > 0)
            {
                return _leftBranch.Contains(value);
            }

            return compared == 0;
        }

        public override T Find(T value)
        {
            int compared = _value.CompareTo(value);

            if (compared < 0)
            {
                return _rightBranch.Find(value);
            }
            else if (compared > 0)
            {
                return _leftBranch.Find(value);
            }

            return _value;
        }
    }
}
