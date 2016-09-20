using System;

namespace BinaryTreeDemo
{
    public abstract class BinaryTree<GenericType>
        where GenericType : IComparable
    {
        public static BinaryTree<GenericType> PlantNewTree()
        {
            return new EmptyTree<GenericType>();
        }

        public abstract BinaryTree<GenericType> Add(GenericType value);
        public abstract int DistanceToFurthestLeave();
        public abstract int AmountOfBranchesAndLeaves();
    }
}