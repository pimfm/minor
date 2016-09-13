using System;

public class EpicMath
{
    public EpicMath()
    {
    }

    public int Fact(int n)
    {
        if (n <= 1)
        {
            return 1;
        }
        return n * Fact(n-1);
    }

    public double findStrangeDouble()
    {
        double x = 0;

        while(true)
        {
            if (x == ++x)
            {
                return x;
            }
        }
    }
}