using System;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        var sum = Enumerable.Range(1, number - 1).Where(x => number % x == 0).Sum();

        if(sum > number)
        {
            return Classification.Abundant;
        }
        else if(sum < number)
        {
            return Classification.Deficient;
        }
        return Classification.Perfect;
    }
}
