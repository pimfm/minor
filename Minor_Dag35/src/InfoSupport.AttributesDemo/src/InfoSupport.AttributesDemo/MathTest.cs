
using System;

namespace InfoSupport.AttributesDemo
{
    public class MathTest
    {
        [Test(0, ExpectedOutput=1)]
        [Test(3, ExpectedOutput=4)]
        [Test(-25, ExpectedException="ArgumentOutOfRangeException")]
        [Test(-26, ExpectedException = "ChaosMonkeyException")]
        public int PlusEen(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return n + 1;
        }

        [Test(1, ExpectedOutput = 2.1)]
        [Test(3.4, ExpectedOutput = 4.5)]
        [Test(2.5, ExpectedOutput = 17.0)]
        public double PlusEenEnEenBeetje(double n)
        {
            return n + 1.1;
        }

        [Test(1, 2, ExpectedOutput = 1.5)]
        [Test(3.4, 3.7, ExpectedOutput = 3.55)]
        [Test(2.5, 18.3, ExpectedOutput = 17.0)]
        public double Gemiddelde(double n, double x)
        {
            return (n + x) / 2;
        }
    }
}
