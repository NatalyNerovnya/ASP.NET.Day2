using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EuclidAndStainAlgorithm;

namespace EuclidAndStainAlgorythm.Tests
{
    [TestClass]
    public class GCDTests
    {
#region Private field
        private double time;
#endregion

        #region Test algorythm
        [TestMethod]
        public void DCG_Euclid_TwoPositiveNumbers()
        {
            int a = 21, b = 49, expected = 7;

            int actual = GCD.CountGCD(a, b, out time, GCD.EuclidAlgorithm);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Euclid_OneNegative_OnePositive_Numbers()
        {
            int a = 21, b = -49, expected = 7;

            int actual = GCD.CountGCD(a, b, out time, GCD.EuclidAlgorithm);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Euclid_PositiveNumbers_Time()
        {
            int[] arr = new[] { 123, 11, 45, 434 };
            int expected = 1;

            int actual = GCD.CountGCD(out time, arr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Euclid_TwoNegativeNumbers()
        {
            int a = -21, b = -49, expected = 7;

            int actual = GCD.CountGCD(a, b, out time);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DCG_Stain_TwoPositiveNumbers()
        {
            int a = 21, b = 49, expected = 7;

            int actual = GCD.CountGCD(a, b, out time, GCD.SteinAlgorithm);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Stain_OneNegative_OnePositive_Numbers()
        {
            int a = 21, b = -49, expected = 7;

            int actual = GCD.CountGCD(a, b, out time, GCD.SteinAlgorithm);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Stain_TwoNegativeNumbers()
        {
            int a = -21, b = -49, expected = 7;

            int actual = GCD.CountGCD(a, b, out time, GCD.SteinAlgorithm);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DCG_Stain_PositiveNumbers()
        {
            int[] arr = new[] { 4, 11, 123, -43 };
            int expected = 1;

            int actual = GCD.CountGCD(out time, GCD.SteinAlgorithm, arr);

            Assert.AreEqual(expected, actual);
        }

        

        #endregion 

       }
}
