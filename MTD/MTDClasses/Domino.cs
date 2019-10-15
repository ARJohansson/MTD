using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses 
{
    /// <summary>
    /// Domino class sets up domino objects for our domino game
    /// </summary>
    [Serializable()]
    public class Domino : IComparable<Domino>
    {
        /// <summary>
        ///  Private fields for the Domino object
        /// </summary>
        private int side1;
        private int side2;

        /// <summary>
        ///  Default Constructor, sets the two sides of the domino to 0
        /// </summary>
        public Domino()
        {
            Side1 = 0;
            Side2 = 0;
        }

        /// <summary>
        ///  Overloaded constructor, accepts two integers and uses them to set the sides of the domino
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Domino(int p1, int p2)
        {
            Side1 = p1;
            Side2 = p2;
        }

        /// <summary>
        ///  Side1 property gets and sets side1 of the domino
        /// </summary>
        public int Side1
        {
            get
            {
                return side1;
            }
            set
            {
                // Only sets the value if the integer is within acceptable parameters
                if (value >= 0 && value <= 12)
                    side1 = value;
                else
                    throw new ArgumentException("Side 1 must be between 0 and 12.");
            }
        }

        /// <summary>
        ///  Side2 property sets and gets side2 of the domino
        /// </summary>
        public int Side2
        {
            get
            {
                return side2;
            }
            set
            {
                // Only sets the value if the integer is within acceptable parameters
                if (value >= 0 && value <= 12)
                    side2 = value;
                else
                    throw new ArgumentException("Side2 must be between 0 and 12.");
            }
        }

        /// <summary>
        ///  Reverses the two sides of the domino. A 1:2 domino becomes 2:1 and vice versa
        /// </summary>
        public void Flip()
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        /// <summary>
        ///  Read-only property uses the lamdba expression to add the two sides of the 
        /// domino and returns a total integer score
        /// </summary>
        public int Score => side1 + side2;

        // Boolean method tests if the two sides are equal and returns a true/false result
        /*public bool IsDouble()
        {
           if (side1 == side2)
               return true;
           else
              return false;
        }*/

        /// <summary>
        ///  Boolean method using the lambda expression to compare and return the result
        /// </summary>
        /// <returns></returns>
        public bool IsDouble() => (side1 == side2) ? true:false;

        /// <summary>
        ///  accesses the pictures matching the correct domino 
        /// </summary>
        public string Filename
        {
            get
            {
                return String.Format("d{0}{1}.png", side1, side2);
            }
        }

        /// <summary>
        ///  overrides the ToString() method to print the domino sides as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", side1, side2);
        }

        /// <summary>
        ///  overrides the Equals method that's defined by the Object class
        /// so we can compare two domino objects directly
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                Domino d = (Domino)obj;
                // Allows opposite dominos to match ie, 2:1 and 1:2
                if (d.Side1 == this.Side1 && d.Side2 == this.Side2 ||
                    d.Side1 == this.Side2 && d.Side2 == this.Side1)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        ///  The GetHashCode mthod must be overriden because it needs to return the same 
        /// hash code for any two instances that are considered equal by the Equals method
        /// the GetHashCode method is also defined by the Object class
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Required method for the IComparable Interface, allows two domino objects to be compared
        /// in order to use the Array.Sort() method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Domino other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}
