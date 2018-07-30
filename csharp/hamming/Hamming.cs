using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if(firstStrand.Length != secondStrand.Length) throw new ArgumentException("Strands must be the same length");

        return firstStrand.Zip(secondStrand,(x, y) => x == y ? 0 : 1).Sum();
    }
}