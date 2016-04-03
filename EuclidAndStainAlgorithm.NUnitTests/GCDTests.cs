using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuclidAndStainAlgorithm;
using NUnit.Framework;

namespace EuclidAndStainAlgorithm.NUnitTests
{
    public class GCDTests
    {
        public IEnumerable<TestCaseData> TestEuclidAndStain
        {
            get
            {
                yield return new TestCaseData(null).Throws(typeof(NullReferenceException));
                yield return new TestCaseData(2, 4).Returns(2);
                yield return new TestCaseData(-4, -36).Returns(4);
                yield return new TestCaseData(0, 11).Returns(11);
            }
        }

        [Test, TestCaseSource(nameof(TestEuclidAndStain))]
        public int CountGCD_EuclidWithYield(int a, int b)
        {
            double time;
            return GCD.CountGCD(a, b, out time, GCD.EuclidAlgorithm);
        }

        [Test, TestCaseSource(nameof(TestEuclidAndStain))]
        public int CountGCD_StainWithYield(int a, int b)
        {
            double time;
            return GCD.CountGCD(a, b, out time);
        }

    }
}
