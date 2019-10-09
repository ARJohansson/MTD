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
        Domino d12_4;
        Domino d04;
        Domino d48;

        
        // Instantiates all of the instance variables before any of the tests run
        // runs and resets the variables every time a test finishes
        [SetUp]
        public void SetUpAllTests()
        {
            m12 = new MexicanTrain(12);
            m0 = new MexicanTrain(0);
            m4 = new MexicanTrain(4);

            d12_4 = new Domino(12, 4);
            d04 = new Domino(0, 4);
            d48 = new Domino(4, 8);
        }

        // Tests the getters
        [Test]
        public void TestAllGetters()
        {
            // tests Count
            Assert.AreEqual(0, m12.Count);
            // tests EngineValue
            Assert.AreEqual(12, m12.EngineValue);
            // tests IsEmpty
            Assert.True(m0.IsEmpty);
            m0.Add(d04);
            Assert.False(m0.IsEmpty);
            // tests LastDomino
            Assert.Null(m12.LastDomino);
            Assert.AreEqual(d04, m0.LastDomino);
            // tests PlayableValue
            Assert.AreEqual(4, m0.PlayableValue);
            // tests Indexer
            m0.Add(d48);
            Assert.AreEqual(d48, m0[1]);
        }
    }
}
