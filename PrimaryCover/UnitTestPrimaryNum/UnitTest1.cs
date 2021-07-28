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
        [Description("проверяем, что мы правильно определяем простоту чисел.")]
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
        [Description("проверяем, что мы правильно определяем то, что число является составным.")]
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
        [Description("проверяем, что мы правильно находим следующее простое число.")]
        public void TestMethod3()
        {
            IPrimary iprimary = PrimaryInterface;

            Assert.IsTrue(iprimary.Next(4) == 5);
            Assert.IsTrue(iprimary.Next(5) == 7);
            Assert.IsTrue(iprimary.Next(10) == 11);
            Assert.IsTrue(iprimary.Next(812) == 821);
        }

        [TestMethod]
        [Description("проверяем, что мы правильно находим следующее простое число.")]
        public void TestMethod4()
        {
            IPrimary iprimary = PrimaryInterface;

            Assert.IsFalse(iprimary.Next(4) == 7);
            Assert.IsFalse(iprimary.Next(812) == 823);
        }

        [TestMethod]
        [Description("проверяем, что мы правильно находим количество простых чисел меньших заданного.")]
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
        [Description("проверяем, что мы правильно находим следующее простое число.")]
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
    }
}
