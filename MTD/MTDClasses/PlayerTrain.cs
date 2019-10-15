using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Represents the Player Train which inherits from the generic Train class
    /// </summary>
    public class PlayerTrain : Train
    {
        private Hand hand = new Hand();
        private bool isOpen;
        
        /// <summary>
        /// This is the most appropriate constructor for the class.
        /// </summary>
        /// <param name="h">Represents the Hand object to which the train belongs</param>
        /// <param name="engineValue">Represents the first playable value on the train</param>
        public PlayerTrain(Hand h, int engineValue) : base (engineValue)
        {
            hand = h;
            Close();
        }

        /// <summary>
        /// Returns whether or not the train is open.  An open train
        /// can be played upon by any player.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        /// <summary>
        /// Open the train
        /// </summary>
        public void Open()
        {
            isOpen = true;
        }

        /// <summary>
        /// Close the train
        /// </summary>
        public void Close()
        {
            isOpen = false;
        }

        /// <summary>
        /// Can the domino d be played by the hand h on this train?
        /// If it can be played, must it be flipped to do so?
        /// </summary>
        /// <param name="d"></param>
        /// <param name="mustFlip"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            if (IsOpen || hand == h)
            {
                // Uses the base method so long as the hand is ours
                // OR the train is open
                if (base.IsPlayable(d, out mustFlip))
                    return true;
                else
                    return false;
            }
            else {
                mustFlip = false;
                return false;
            }
        }
        
    }
}
