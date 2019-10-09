using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Represents the Mexican Train which inherits from the generic Train class
    /// </summary>
    public class MexicanTrain : Train
    {
        /// <summary>
        /// Overloaded Constructor that uses the base Train Class's constructor
        /// </summary>
        /// <param name="engineValue"></param>
        public MexicanTrain(int engineValue) : base(engineValue) { }

        /// <summary>
        /// Overrides the base Train class's IsPlayable() abstract method but utilizes
        /// the non-abstract IsPlayable() method
        /// </summary>
        /// <param name="h"></param>
        /// <param name="d"></param>
        /// <param name="mustFlip"></param>
        /// <returns></returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return base.IsPlayable(d, out mustFlip);
        }
    }
}
