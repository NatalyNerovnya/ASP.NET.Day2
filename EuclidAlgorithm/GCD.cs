using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidAndStainAlgorithm
{
    public class GCD
    {
        public static int CountGCDEuclid(ref TimeSpan time, int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();
            if (a < b)
                Swap(a, b);

            int rem = -1;
            while (rem != 0)
            {
                rem = a % b;
                a = b;
                b = rem; 
            }

            return rem;
        }

        private static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
