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
        BoneYard b0;
        BoneYard b4;
        BoneYard b10;
        BoneYard b2;

        [SetUp]
        public void SetUpAllTests()
        {
            b0 = new BoneYard(-1);
            b4 = new BoneYard(4);
            b10 = new BoneYard(10);
            b2 = new BoneYard(2);
        }

        [Test]
        public void TestConstructor()
        {
            BoneYard b4 = new BoneYard(4);
            Assert.AreEqual(15, b4.DominosRemaining);
            Assert.AreEqual(new Domino(0, 0), b4[0]);
            Assert.AreEqual(new Domino(1, 3), b4[7]);
        }

        [Test]
        public void TestShuffle()
        {
            BoneYard bShuffle = new BoneYard(10);

            Assert.AreEqual(bShuffle[0], b10[0]);
            Assert.AreEqual(bShuffle[4], b4[4]);

            bShuffle.Shuffle();

            Assert.AreNotEqual(bShuffle[0], b10[0]);
            Assert.AreNotEqual(bShuffle[65], b10[65]);
        }
        
        [Test]
        public void TestIsEmpty()
        {
            Assert.True(b0.IsEmpty());
            Assert.False(b10.IsEmpty());
        }

        [Test]
        public void TestDominosRemaining()
        {
            Assert.AreEqual(15, b4.DominosRemaining);
            for (int i = 0; i <= 2; i++)
            {
                b4.Draw();
            }
            Assert.AreEqual(12, b4.DominosRemaining);
        }

        [Test]
        public void TestDraw()
        {
            Domino d1 = new Domino(0, 0);
            Assert.AreEqual(d1, b4.Draw());
            Assert.Throws<Exception>(() => b0.Draw());
        }

        [Test]
        public void TestIndexer()
        {
            Domino d25 = new Domino(2, 5);
            Assert.AreEqual(d25, b10[24]);

            b10[24] = b10[2];
            b10[2] = d25;
            Assert.AreNotEqual(d25, b10[24]);
            Assert.AreEqual(d25, b10[2]);
        }
    }
}
