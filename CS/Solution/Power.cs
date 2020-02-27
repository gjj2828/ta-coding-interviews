using System;

// 数学 数值的整数次方
namespace Power
{
    class Solution
    {
        public double Power(double thebase, int exponent)
        {
            // write code here
            //if (exponent == 0) return 1.0;
            int a = Math.Abs(exponent);
            double result = 1.0;
            double times = thebase;
            while(a > 0)
            {
                if((a & 0x1) != 0)
                {
                    result *= times;
                }
                a >>= 1;
                times *= times;
            }
            if(exponent < 0)
            {
                result = 1.0 / result;
            }
            return result;
        }
    }

    class Test: TestBase
    {
        private Solution mS = new Solution();
        private Random mRnd= new Random();
        public override bool Run()
        {
            for (int i = 0; i < 10; i++)
            {
                if (!PowerCheck(RndBase(), RndExp())) return false;
            }
            if (!PowerCheck(RndBase(), 0)) return false;
            if (!PowerCheck(0, RndExp())) return false;
            return true;
        }

        private int RndSign()
        {
            if (mRnd.Next(100) < 50) return -1;
            return 1;
        }

        private double RndBase()
        {
            return RndSign() * mRnd.NextDouble() * 100.0;
        }

        private int RndExp()
        {
            return RndSign() * mRnd.Next(100);
        }

        private bool PowerCheck(double thebase, int exp)
        {
            double r1 = mS.Power(thebase, exp);
            double r2 = Math.Pow(thebase, exp);
            double precision = Math.Abs(r2 * 0.0001);
            if (Math.Abs(r1 - r2) > precision)
            {
                Console.WriteLine("{0}'s power {1} should be {2}, not {3}"
                    , thebase, exp, r2, r1);
                return false;
            }
            return true;
        }
    }
}