﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDTests
{
        /// <summary>
        /// Tests all MexicanTrain methods and base Train methods
        /// </summary>
    [TestFixture]
    class PlayerTrainTests
    {
        // Instance Variables
        PlayerTrain p12;
        PlayerTrain p04;
        Domino d12_4;
        Domino d04;
        Hand h;
        Hand h2;

        // Instantiates all of the instance variables before any of the tests run
        // runs and resets the variables every time a test finishes
        [SetUp]
        public void SetUpAllTests()
        {
            h = new Hand();
            h2 = new Hand();

            p12 = new PlayerTrain(h, 12);
            p04 = new PlayerTrain(h, 0);

            d12_4 = new Domino(12, 4);
            d04 = new Domino(0, 4);


            p04.Add(d04);
            p04.Open();
        }

        [Test]
        public void ConstructorTest()
        {
            // Tests the PlayerTrain Constructor
            PlayerTrain p = new PlayerTrain(h, 3);
            //The engine value should be three, there should not
            // be three dominos in the train
            Assert.AreEqual(3, p.EngineValue);
            Assert.AreNotEqual(3, p.Count);
        }

        [Test]
        public void IsOpenTest()
        {
            // Tests the boolean IsOpen property, all 
            // playertrains should be closed at start
            Assert.False(p12.IsOpen);
            Assert.True(p04.IsOpen);
        }
        
        [Test]
        public void OpenTest()
        {
            // Tests the open method which sets the 
            // playertrain to open when called
            Assert.False(p12.IsOpen);
            p12.Open();
            Assert.True(p12.IsOpen);
        }

        [Test]
        public void CloseTest()
        {
            // Tests the close method which sets the 
            // playertrain to closed when called
            Assert.True(p04.IsOpen);
            p04.Close();
            Assert.False(p04.IsOpen);
        }

        [Test]
        public void IsPlayable1()
        {
            // Tests the boolean IsPlayable method, it should pass
            // even though p12 isn't open because it is our hand
            bool mustFlip = false;
            Assert.True(p12.IsPlayable(h, d12_4, out mustFlip));
        }

        [Test]
        public void IsPlayable2()
        {
            // Tests the boolean IsPlayable method, it should pass
            // even though the hand is different because p12 is open
            p12.Open();
            bool mustFlip = false;
            Assert.True(p12.IsPlayable(h2, d12_4, out mustFlip));
        }

        [Test]
        public void IsPlayable3()
        {
            // Tests the boolean IsPlayable method, it should not pass
            // because the train is closed and the hand is not ours
            bool mustFlip = false;
            Assert.False(p12.IsPlayable(h2, d12_4, out mustFlip));
        }
    }
}
