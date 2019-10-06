using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Domino
    {
        private int side1;
        private int side2;

        // Default Constructor, sets the two sides of the domino to 0
        public Domino()
        {
            Side1 = 0;
            Side2 = 0;
        }

        // Overloaded constructor, accepts two integers and uses them to set the sides of the domino
        public Domino(int p1, int p2)
        {
            Side1 = p1;
            Side2 = p2;
        }

        // Side1 property gets and sets side1 of the domino
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

        // Side2 property sets and gets side2 of the domino
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

        // Reverses the two sides of the domino. A 1:2 domino becomes 2:1 and vice versa
        public void Flip()
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        // Read-only property uses the lamdba expression to add the two sides of the 
        // domino and returns a total integer score
        public int Score => side1 + side2;
        
        // Boolean method tests if the two sides are equal and returns a true/false result
        /*public bool IsDouble()
        {
           if (side1 == side2)
               return true;
           else
              return false;
        }*/
        
        // Boolean method using the lambda expression to compare and return the result
        public bool IsDouble() => (side1 == side2) ? true:false;
        
        // accesses the pictures matching the correct domino 
        public string Filename
        {
            get
            {
                return String.Format("d{0}{1}.png", side1, side2);
            }
        }
        
        // overrides the ToString() method to print the domino sides as a string
        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", side1, side2);
        }
        
        // overrides Equals so we can compare two domino objects directly
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

        //To override Equals() one must override GetHashCode()
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        
    }
}
