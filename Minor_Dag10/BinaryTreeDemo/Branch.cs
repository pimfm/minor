using System;

namespace BinaryTreeDemo
{
    internal class Branch<GenericType> : BinaryTree<GenericType>
        where GenericType : IComparable
    {
        public GenericType value;
        public BinaryTree<GenericType> leftBranch;
        public BinaryTree<GenericType> rightBranch;

        public Branch(GenericType value)
        {
            this.value = value;
            leftBranch = PlantNewTree();
            rightBranch = PlantNewTree();
        }

        public override BinaryTree<GenericType> Add(GenericType value)
        {
            int compared = this.value.CompareTo(value);

            if (compared < 0)
            {
                rightBranch = rightBranch.Add(value);
            } 
            else if (compared > 0)
            {
                leftBranch = leftBranch.Add(value);
            }

            return this;
        }

        public override int AmountOfBranchesAndLeaves()
        {
            int amountLeft = leftBranch.AmountOfBranchesAndLeaves();
            int amountRight = rightBranch.AmountOfBranchesAndLeaves();

            return amountLeft + 1 + amountRight;
        }

        public override int DistanceToFurthestLeave()
        {
            int furthestLeft = 1 + leftBranch.DistanceToFurthestLeave();
            int furthestRight = 1 + rightBranch.DistanceToFurthestLeave();

            return furthestLeft >= furthestRight ? furthestLeft : furthestRight;
        }
    }
}
