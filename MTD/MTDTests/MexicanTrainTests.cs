using System;
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
    class MexicanTrainTests
    {
        // Instance Variables
        MexicanTrain m12;
        MexicanTrain m0;
        MexicanTrain m4;
        MexicanTrain m04;
        Domino d12_4;
        Domino d04;
        Domino d52;
        Domino d48;
        Hand h;

        // Instantiates all of the instance variables before any of the tests run
        // runs and resets the variables every time a test finishes
        [SetUp]
        public void SetUpAllTests()
        {
            m12 = new MexicanTrain(12);
            m0 = new MexicanTrain(0);
            m4 = new MexicanTrain(4);
            m04 = new MexicanTrain(0);

            d12_4 = new Domino(12, 4);
            d04 = new Domino(0, 4);
            d48 = new Domino(4, 8);
            d52 = new Domino(5, 2);

            h = new Hand();

            m04.Add(d04);
        }

        [Test]
        public void OverloadedConstructor()
        {
            // Tests the constructor, it should change the engine
            //  value to three, not add three dominos to the train
            MexicanTrain m = new MexicanTrain(3);
            Assert.AreEqual(m.EngineValue, 3);
            Assert.AreNotEqual(m.EngineValue, 10);
        }

        [Test]
        public void EngineValueTest()
        {
            // tests EngineValue of two mexican trains
            Assert.AreEqual(12, m12.EngineValue);
            Assert.AreNotEqual(3, m4.EngineValue);
        }

        [Test]
        public void CountTest()
        {
            // tests Count any new train should have a count of 0
            Assert.AreEqual(0, m12.Count);
            Assert.AreNotEqual(3, m0);
        }
        [Test]
        public void IsEmptyTest()
        {
            // tests IsEmpty
            Assert.True(m0.IsEmpty);
            Assert.False(m04.IsEmpty);
        }
        [Test]
        public void LastDominTest()
        {
            // tests the null return if an empty train is passed
            // to the LastDomino method
            Assert.Null(m12.LastDomino);
            //Test the LastDomino method with a non-empty train
            Assert.AreEqual(d04, m04.LastDomino);
            m04.Add(d52);
            Assert.AreNotEqual(d04, m04.LastDomino);
        }

        [Test]
        public void PlayableValueTest()
        {
            m4.Add(d04);
            m4.Add(d12_4);
            m4.Add(d48);
            // tests PlayableValue
            Assert.AreEqual(4, m04.PlayableValue);
            Assert.AreNotEqual(m04.PlayableValue, m4.PlayableValue);
            Assert.AreEqual(8, m4.PlayableValue);

        }

        [Test]
        public void AddTest()
        {
            //tests adding a domino to a train
            Assert.AreEqual(d04, m04.LastDomino);
            m04.Add(d12_4);
            Assert.AreNotEqual(d04, m04.LastDomino);
        }

        [Test]
        public void IndexerTest()
        {
            // tests Indexer
            m04.Add(d52);
            m4.Add(d52);
            Assert.AreEqual(d52, m04[1]);
            Assert.AreNotEqual(d04, m4[0]);
        }


        [Test]
        public void IsPlayableAbstractTest1()
        {
            bool mustFlip = false;

            // using enginevalue and is playable and no flip
            Assert.IsTrue(m4.IsPlayable(h, d48, out mustFlip));
            Assert.IsFalse(mustFlip);
        }


        [Test]
        public void IsPlayableAbstractTest2()
        {
            bool mustFlip = false;
            //using enginevalue and is not playable and no flip
            Assert.IsFalse(m4.IsPlayable(h, d52, out mustFlip));
            Assert.IsFalse(mustFlip);
        }


        [Test]
        public void IsPlayableAbstractTest3()
        {
            bool mustFlip = false;
            // using domino value and is playable and no flip
            Assert.IsTrue(m04.IsPlayable(h, d48, out mustFlip));
            Assert.IsFalse(mustFlip);
        }


        [Test]
        public void IsPlayableAbstractTes4t()
        {
            bool mustFlip = false;

            // using domino value and is not playable and no flip
            Assert.IsFalse(m04.IsPlayable(h, d52, out mustFlip));
            Assert.IsFalse(mustFlip);
        }

        [Test]
        public void IsPlayableAbstractTest5()
        {
            bool mustFlip = true;

            //using engine value and is playable and flip
            Assert.IsTrue(m4.IsPlayable(h, d12_4, out mustFlip));
            Assert.IsTrue(mustFlip);

        }

        [Test]
        public void IsPlayableAbstractTest6()
        {
            bool mustFlip = true;

            // using domino value and is playable and flip
            Assert.IsTrue(m04.IsPlayable(h, d12_4, out mustFlip));
            Assert.IsTrue(mustFlip);
        }

        [Test]
        public void PlayTest() {
            // Testing play by adding a domino whose side needs to flip
            Domino d06 = new Domino(0, 6);

            m4.Play(h, d04);

            Assert.AreEqual(m4.LastDomino.Side1, d04.Side1);
            Assert.AreEqual(m4.LastDomino.Side2, d04.Side2);
        }

        [Test]
        public void PlayTest2() {
            // Testing play by adding a domino whose side doesn't need to flip
            Domino d06 = new Domino(0, 6);
            m4.Play(h, d04);
            m4.Play(h, d06);

            Assert.AreEqual(m4.LastDomino.Side1, d06.Side1);
            Assert.AreEqual(m4.LastDomino.Side2, d06.Side2);
        }

        [Test]
        public void PlayTest3() { 
            // Testing play that throws an exception because the domino does not
            // have a playable value
            Assert.Throws<Exception>(() => m04.Play(h, new Domino(3, 5) ));
        }
    }
}
