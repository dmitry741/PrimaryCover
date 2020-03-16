using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDPrimaryNumbers.Base;
using PDPrimaryNumbers;

namespace UnitTestPrimaryNum
{
    [TestClass]
    public class UnitTest1
    {

        IPrimary PrimaryInterface => new PrimaryNum();

        [TestMethod]
        public void TestMethod1()
        {
            IPrimary iprimary = PrimaryInterface;

            Assert.IsTrue(iprimary.IsPrimary(2));
            Assert.IsTrue(iprimary.IsPrimary(5));
            Assert.IsTrue(iprimary.IsPrimary(11));
            Assert.IsTrue(iprimary.IsPrimary(101));
            Assert.IsTrue(iprimary.IsPrimary(991));
            Assert.IsTrue(iprimary.IsPrimary(4337));
            Assert.IsTrue(iprimary.IsPrimary(995009));
            Assert.IsTrue(iprimary.IsPrimary(1004987));
            Assert.IsTrue(iprimary.IsPrimary(10000019));
        }

        [TestMethod]
        public void TestMethod2()
        {
            IPrimary iprimary = PrimaryInterface;

            Assert.IsFalse(iprimary.IsPrimary(6));
            Assert.IsFalse(iprimary.IsPrimary(15));
            Assert.IsFalse(iprimary.IsPrimary(33));
            Assert.IsFalse(iprimary.IsPrimary(111));
            Assert.IsFalse(iprimary.IsPrimary(9969));
            Assert.IsFalse(iprimary.IsPrimary(999985));
            Assert.IsFalse(iprimary.IsPrimary(1000007));
            Assert.IsFalse(iprimary.IsPrimary(10000023));
        }

        [TestMethod]
        public void TestMethod3()
        {
            IPrimary iprimary = PrimaryInterface;

            Assert.IsTrue(iprimary.NextPrimary(4) == 5);
            Assert.IsTrue(iprimary.NextPrimary(5) == 7);
            Assert.IsTrue(iprimary.NextPrimary(10) == 11);
            Assert.IsTrue(iprimary.NextPrimary(812) == 821);
        }

        [TestMethod]
        public void TestMethod4()
        {
            IPrimary iprimary = PrimaryInterface;

            Assert.IsFalse(iprimary.NextPrimary(4) == 7);
            Assert.IsFalse(iprimary.NextPrimary(812) == 823);
        }

        [TestMethod]
        public void TestMethod5()
        {
            IPrimary iprimary = PrimaryInterface;

            Assert.IsTrue(iprimary.Pi(10) == 4);
            Assert.IsTrue(iprimary.Pi(100) == 25);
            Assert.IsTrue(iprimary.Pi(1000) == 168);
            Assert.IsTrue(iprimary.Pi(10000) == 1229);
            Assert.IsTrue(iprimary.Pi(100000) == 9592);
        }

        [TestMethod]
        public void TestMethod6()
        {
            ICascadePrime iprimary = new CascadePrime();

            Assert.IsTrue(iprimary.Next() == 2);
            Assert.IsTrue(iprimary.Next() == 3);
            Assert.IsTrue(iprimary.Next() == 5);
            Assert.IsTrue(iprimary.Next() == 7);
            Assert.IsTrue(iprimary.Next() == 11);
            Assert.IsTrue(iprimary.Next() == 13);
            Assert.IsTrue(iprimary.Next() == 17);
            Assert.IsTrue(iprimary.Next() == 19);
            Assert.IsTrue(iprimary.Next() == 23);
        }

        [TestMethod]
        public void TestMethod7()
        {
            IPrimary iprimary = PrimaryInterface;
            int P = 1;

            for (int i = 0; i < 10000; i++)
            {
                P = iprimary.NextPrimary(P);
            }

            Assert.IsTrue(iprimary.IsPrimary(P));
        }
    }
}
