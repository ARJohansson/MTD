using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class BoneYard
    {
        private List<Domino> boneyard;

        public BoneYard(int maxDots)
        {
            boneyard = new List<Domino>();
            for (int side1 = 0; side1 <= maxDots; side1++)
            {
                for (int side2 = side1; side2 <= maxDots; side2++)
                {
                    boneyard.Add(new Domino(side1, side2));
                }
            }
        }

        
        public void Shuffle()
        {
            Random gen = new Random();
            for (int i = 0; i < DominosRemaining; i++)
            {
                int rNum = gen.Next(i, DominosRemaining);
                Domino d = boneyard[rNum];
                boneyard[rNum] = boneyard[i];
                boneyard[i] = d;
            }
        }

        public bool IsEmpty()
        {
            if (boneyard.Count == 0)
                return true;
            else
                return false;
        }

        public int DominosRemaining
        {
            get
            {
                return boneyard.Count;
            }
        }
        
        public Domino Draw()
        {
            if (IsEmpty() == false)
            {
                Domino d = boneyard[0];
                boneyard.RemoveAt(0);
                return d;
            }
            else
            {
                throw new Exception("BoneYard is Empty.");
            }
        }

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
