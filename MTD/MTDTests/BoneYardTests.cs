using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDTests
{
    [TestFixture]
    public class BoneYardTests
    {
        // Instantiates four BoneYard objects
        BoneYard b0;
        BoneYard b4;
        BoneYard b10;
        BoneYard b2;

        // This method starts before any test so that all tests  may use
        // the unadulterated boneyard objects
        [SetUp]
        public void SetUpAllTests()
        {
            b0 = new BoneYard(-1);
            b4 = new BoneYard(4);
            b10 = new BoneYard(10);
            b2 = new BoneYard(2);
        }

        // Tests the overloaded constructor to ensure that it instantiates
        // a BoneYard object correctly
        [Test]
        public void TestConstructor()
        {
            BoneYard b4 = new BoneYard(4);
            Assert.AreEqual(15, b4.DominosRemaining);
            Assert.AreEqual(new Domino(0, 0), b4[0]);
            Assert.AreEqual(new Domino(1, 3), b4[7]);
        }

        /* Tests the Shuffle() method to ensure it actually shuffles the deck
         * This will occasionally fail due to the possibility of the first or last
         * domino shuffling back into its original place
         */
        [Test]
        public void TestShuffle()
        {
            BoneYard bShuffle = new BoneYard(10);

            // Makes sure that the first and fifth dominos are the same in two
            // unshuffled BoneYards
            Assert.AreEqual(bShuffle[0], b10[0]);
            Assert.AreEqual(bShuffle[4], b4[4]);

            // Calls the Shuffle() method
            bShuffle.Shuffle();

            // Measures the first and last domino in the shuffled BoneYard to an
            // unshuffled BoneYard. They will usually be different.
            Assert.AreNotEqual(bShuffle[0], b10[0]);
            Assert.AreNotEqual(bShuffle[65], b10[65]);
        }
        
        // Tests the IsEmpty() Boolean method to ensure it returns the correct result
        [Test]
        public void TestIsEmpty()
        {
            //b0 is instantiated to hold 0 dominos
            Assert.True(b0.IsEmpty());
            // b10 is instantiated to hold 66 dominos (or a set of double 10s)
            Assert.False(b10.IsEmpty());
        }

        // Tests the DominosRemaining() method to see what the count is before and 
        // after drawing from the BoneYard
        [Test]
        public void TestDominosRemaining()
        {
            // An instantiated BoneYard of double 4s should have 15 dominos
            Assert.AreEqual(15, b4.DominosRemaining);
            // Removes three dominos from the BoneYard
            for (int i = 0; i <= 2; i++)
            {
                b4.Draw();
            }
            // There should only be 12 dominos remaining
            Assert.AreEqual(12, b4.DominosRemaining);
        }

        // Tests the Draw() method to ensure it draws the top domino and ensures
        // that an Exception is thrown if someone tries to draw from an empty BoneYard
        [Test]
        public void TestDraw()
        {
            Domino d1 = new Domino(0, 0);
            Assert.AreEqual(d1, b4.Draw());
            Assert.Throws<Exception>(() => b0.Draw());
        }

        // Tests the indexer and verifies that both the getter and setter work
        [Test]
        public void TestIndexer()
        {
            // Verifies that the domino at index 24 is equal to domino 2:5
            Domino d25 = new Domino(2, 5);
            Assert.AreEqual(d25, b10[24]);

            // Sets the domino at index 24 to the value of the domino at index 2
            b10[24] = b10[2];
            // Sets the domino at index 2 to the value of d25
            b10[2] = d25;
            Assert.AreNotEqual(d25, b10[24]);
            Assert.AreEqual(d25, b10[2]);
        }
    }
}
