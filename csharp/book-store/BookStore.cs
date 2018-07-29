using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    public const int Cost = 8; // regular price of a book
    public static double Total(IEnumerable<int> books)
    {
        var total = 0.0;
        var cart = books.ToList();
        var inCart = cart.Count();
        var groups = new List<int>();

        while(inCart > 0)
        {
            var distinct = cart.Distinct().ToList();
            var c = distinct.Count();

            if(c == 3 && groups.Contains(5))
            {
                groups.Remove(5);
                groups.AddRange( new int[] {4,4});
            }
            else
            {
                groups.Add(c);
            }

            foreach(var d in distinct)
            {
                cart.Remove(d);
            }

            inCart = cart.Count();

        }

        foreach(var group in groups)
        {
            total += group * Cost * GetDiscount(group);
        }

        return total;
    }

    private static double GetDiscount(int count)
    {
        switch(count)
        {
            case 1:
                return 1.0;
            case 2:
                return 0.95;
            case 3:
                return 0.90;
            case 4:
                return 0.80;
            default:
                if(count >= 5) return 0.75;
                throw new ArgumentException();
        }
    }
}