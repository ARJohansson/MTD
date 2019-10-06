using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class BoneYard
    {
        // private list field to create a new boneyard
        private List<Domino> boneyard;

        // overloaded BoneYard constructor, accepts a max number of dominos
        public BoneYard(int maxDots)
        {
            // instantiates the new list
            boneyard = new List<Domino>();
            // loops through the dominos starting at 0 and ending at the number of 
            // max dominos
            for (int side1 = 0; side1 <= maxDots; side1++)
            {
                for (int side2 = side1; side2 <= maxDots; side2++)
                {
                    // Adds the new domino to the BoneYard list
                    boneyard.Add(new Domino(side1, side2));
                }
            }
        }

        // Shuffles through the BoneYard using a random generator
        // this is more effective with a large deck, but still works with smaller decks
        public void Shuffle()
        {
            // instantiates the random generator
            Random gen = new Random();
            // loops through the list of dominos shuffling them "randomly"
            for (int i = 0; i < DominosRemaining; i++)
            {
                int rNum = gen.Next(i, DominosRemaining);
                Domino d = boneyard[rNum];
                boneyard[rNum] = boneyard[i];
                boneyard[i] = d;
            }
        }

        // Boolean method checks to see if the list is empty, returns true if it is.
        // uses the lambda operator
        public bool IsEmpty() => (boneyard.Count == 0) ? true : false;

        // Gets and returns the number of dominos in the boneyard using the lambda operator
        public int DominosRemaining => ( boneyard.Count);
        
        // Draws a domino from the top of the List
        public Domino Draw()
        {
            // Only draws from the list if there are dominos in it
            if (IsEmpty() == false)
            {
                Domino d = boneyard[0];
                boneyard.RemoveAt(0);
                return d;
            }
            else
            {
                // if there are no dominos an exception is thrown
                throw new Exception("BoneYard is Empty.");
            }
        }

        // The Indexer returns the position of the domino entered or sets the domino at
        // a given position to the value entered
        public Domino this[int index]
        {
            get
            {
                return boneyard[index];
            }
            set
            {
                boneyard[index] = value;
            }
        }

        // Overrides the ToString() method to print the domino list
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < boneyard.Count; i++)
            {
                output += boneyard[i] + "\n";
            }
            return output;
        }
    }
}
