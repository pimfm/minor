using System;

namespace BinaryTreeDemo
{
    internal class EmptyTree<GenericType> : BinaryTree<GenericType>
        where GenericType : IComparable
    {
        public override BinaryTree<GenericType> Add(GenericType value)
        {
            return new Branch<GenericType>(value);
        }

        public override int AmountOfBranchesAndLeaves()
        {
            return 0;
        }

        public override int DistanceToFurthestLeave()
        {
            return 0;
        }
    }
}
