using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// A list of dominos very much like a deck of cards
    /// </summary>
    public class BoneYard : IEnumerable<Domino>
    {
        /// <summary>
        /// private list field to create a new boneyard
        /// </summary>
        private List<Domino> boneyard;

        /// <summary>
        ///  overloaded BoneYard constructor, accepts a max number of dominos
        /// </summary>
        /// <param name="maxDots"></param>
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

        /// <summary>
        /// Shuffles through the BoneYard using a random generator
        /// this is more effective with a large deck, but still works with smaller decks
        /// </summary>
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

        /// <summary>
        ///Boolean method checks to see if the list is empty, returns true if it is.
        /// uses the lambda operator
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => (boneyard.Count == 0) ? true : false;

        /// <summary>
        /// Gets and returns the number of dominos in the boneyard using the lambda operator
        /// </summary>
        public int DominosRemaining => ( boneyard.Count);

        /// <summary>
        ///  Draws a domino from the top of the List
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        ///  The Indexer returns the domino based on a givne index entered or sets the 
        /// domino at a given position to the value entered
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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

        /// <summary>
        ///  Overrides the ToString() method to print the domino list
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < boneyard.Count; i++)
            {
                output += boneyard[i] + "\n";
            }
            return output;
        }

        /// <summary>
        /// Necessary method in order to allow a foreach loop in tests
        /// part ofthe IEnumerator interface
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Domino> GetEnumerator()
        {
            foreach (Domino d in boneyard)
                yield return d;
        }

        /// <summary>
        /// Necessary method for IEnumerator Interface, doesn't have to do anything
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
