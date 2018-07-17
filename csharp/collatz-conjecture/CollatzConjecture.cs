using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        var steps = 0;
        if(number <= 0) throw new ArgumentException("number must be greater or equal to 1.");

        while(number > 1)
        {
            if(number % 2 == 1)
            {
                //odd
                number = number * 3 + 1;
            }
            else{
                //even
                number = number / 2;
            }
            steps++;
        }

        return steps;
    }
}