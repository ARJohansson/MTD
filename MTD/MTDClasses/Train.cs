using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Represents a generic Train for MTD
    /// </summary>
    public abstract class Train
    {

        /// <summary>
        /// Fields for the Train Class
        /// </summary>
        protected List<Domino> dominos = new List<Domino>();
        /// <summary>
        /// Second field for the Train Class
        /// </summary>
        protected int engineValue;

        /// <summary>
        /// Overloaded Constructor takes integer and sets the engineValue
        /// </summary>
        /// <param name="engValue"></param>
        public Train(int engValue)
        {
            engineValue = engValue;
        }

        /// <summary>
        /// The number of dominos in the train
        /// </summary>
        public int Count
        {
            get
            {
               return dominos.Count();
            }
        }

        /// <summary>
        /// The first domino value that must be played on a train
        /// </summary>
        public int EngineValue
        {
            get
            {
                return engineValue;
            }
        }

        /// <summary>
        /// Property that checks if the train is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (dominos.Count() != 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// returns the last domino in the train
        /// </summary>
        public Domino LastDomino
        {
            get
            {
                if (IsEmpty)
                    return null;
                else
                {
                    Domino d;
                    int index = dominos.Count() - 1;
                    d = dominos[index];
                    return d;
                }
            }
        }

        /// <summary>
        /// Side2 of the last domino in the train.  It's the value of the next domino that can be played.
        /// </summary>
        public int PlayableValue
        {
            get
            {
                if (LastDomino != null)
                {
                    Domino d = LastDomino;
                    return d.Side2;
                }
                else
                    return EngineValue;
            }
        }

        /// <summary>
        /// adds a domino to the train
        /// </summary>
        /// <param name="d"></param>
        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        /// <summary>
        /// finds and returns a domino based on the index passed in
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Domino this[int index]
        {
            get
            {
                Domino d = dominos[index];
                return d;
            }
        }

        /// <summary>
        /// Determines whether a hand can play a specific domino on this train and if the domino must be flipped.
        /// Because the rules for playing are different for Mexican and Player trains, this method is abstract.
        /// </summary>
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        /// <summary>
        /// A helper method that determines whether a specific domino can be played on this train.
        /// It can be called in the Mexican and Player train class implementations of the abstract method
        /// </summary>
        protected bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (IsEmpty)
            {
                if (EngineValue == d.Side1)
                {
                    mustFlip = false;
                    return true;
                }
                else if (EngineValue == d.Side2)
                {
                    mustFlip = true;
                    return true;
                }
                else
                {
                    mustFlip = false;
                    return false;
                }
            }
            else
            {
                if (PlayableValue == d.Side1)
                {
                    mustFlip = false;
                    return true;
                }
                else if (PlayableValue == d.Side2)
                {
                    mustFlip = true;
                    return true;
                }
                else
                {
                    mustFlip = false;
                    return false;
                }
            }
        }

        /// <summary>
        ///assumes the domino has already been removed from the hand
        /// </summary>
        public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;
            if (IsPlayable(h, d, out mustFlip))
            {
                if (mustFlip)
                {
                    // need to raise an event here
                    d.Flip();
                }
                Add(d);
            }
            else
                throw new Exception("Domino " + d.ToString() + " does not match last domino in the train and cannot be played.");
        }

        /// <summary>
        /// Overriden ToString that uses the dominos ToString method to create a 
        /// string of dominos in a train
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            output += dominos.ToString();
            return output;
        }
        
    }
}