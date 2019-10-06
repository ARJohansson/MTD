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
    public class DominoTests
    {
        // Instantiates four different domino objects
        Domino def;
        Domino d12;
        Domino d21;
        Domino d33;

        // This method starts before any test so that all tests  may use
        // the unadulterated domino objects
        [SetUp]
        public void SetUpAllTests()
        {
            def = new Domino();
            d12 = new Domino(1, 2);
            d21 = new Domino(2, 1);
            d33 = new Domino(3, 3);
        }

        // Tests the AreEqual() method before anything else
        [Test]
        public void TestSimpleAddition()
        {
            int answer = 1 + 2;
            Assert.AreEqual(3, answer);
        }

        // Checks to see if the overloaded constructor correctly creates the d12 object
        // the way it is defined in the SetUpAllTests() method
        [Test]
        public void TestOverloadedConstructor()
        {
            Assert.AreEqual(1, d12.Side1);
            Assert.AreEqual(2, d12.Side2);
        }

        // Tests the Getters for the two domino side properties (Side1 and Side2)
        [Test]
        public void TestGetters()
        {
            Assert.AreEqual(1, d12.Side1);
            Assert.AreEqual(2, d12.Side2);
        }

        // Tests the Setters for the two domino side properties
        [Test]
        public void TestSettersValid()
        {
            // instantiates a new domino 
            Domino d = new Domino(3, 2);
            Assert.AreEqual(3, d.Side1);
            Assert.AreEqual(2, d.Side2);
            // sets the two domino sides to new integers
            d.Side1 = 1;
            d.Side2 = 12;
            // verifies that the sides were set correctly
            Assert.AreEqual(1, d.Side1);
            Assert.AreEqual(12, d.Side2);
        }

        // Tests the ArgumentException thrown in the two Domino setter properties using a try/catch format
        // The values should be between 0 and 12
        [Test]
        public void TestSettersInValidTry()
        {
            // instantiates a new domino with both sides equal to 0, testing the default constructor
            Domino d = new Domino();
            try
            {
                d.Side1 = -1;
                Assert.Fail("The setter should throw an exception for negative values.");
            }
            catch (ArgumentException)
            {
                Assert.Pass("The setter threw an exception for a negative value as expected");
            }
            try
            {
                d.Side1 = 15;
                Assert.Fail("The setter should throw an exception for a value > 13.");
            }
            catch (ArgumentException)
            {
                Assert.Pass("The setter threw an exception for a value of 15 as expected");
            }
            // proves that the default constructor sets the domino sides to 0
            Assert.AreEqual(0, d.Side1);
            Assert.AreEqual(0, d.Side2);
        }

        // Tests the ArgumentException is thrown using lambda expressions
        [Test]
        public void TestSettersInValidAssertThrows()
        {
            Domino d = new Domino();
            Assert.Throws<ArgumentException>(() => d.Side1 = -1);
            Assert.Throws<ArgumentException>(() => d.Side1 = 15);
            Assert.AreEqual(0, d.Side1);
            Assert.AreEqual(0, d.Side2);
        }

        // Tests that the Flip() method actually reverses the sides of a given domino
        // (e.g. 2:1 becomes 1:2 and vice versa)
        [Test]
        public void TestFlip()
        {
            d12.Flip();
            Assert.AreEqual(2, d12.Side1);
            Assert.AreEqual(1, d12.Side2);
        }

        // Tests that the Score() method correctly adds the two sides
        [Test]
        public void TestScore()
        {
            Assert.AreEqual(3, d12.Score);
            Assert.AreEqual(6, d33.Score);
        }

        // Tests the boolean IsDouble() method to see that it compares the two domino
        // sides correctly. Returning true if the sides match (e.g. 2:2) or do not (e.g. 1:2)
        [Test]
        public void TestIsDouble()
        {
            Assert.True(d33.IsDouble());
            Assert.False(d12.IsDouble());
        }
        
        // Tests that the overloaded Equals() method compares the two domino objects correctly
        // No GetHashCode test is required
        [Test]
        public void TestEquals()
        {
            Domino duplicate12 = new Domino(1, 2);
            Assert.True(d12.Equals(duplicate12));
            Assert.True(d12.Equals(d21));
            Assert.False(d12.Equals(d33));
        }
    }
}
