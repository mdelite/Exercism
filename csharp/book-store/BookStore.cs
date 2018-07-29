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

        while(inCart > 0)
        {
            var distinct = cart.Distinct().ToList();
            var count = distinct.Count();

            foreach(var d in distinct)
            {
                cart.Remove(d);
            }

            inCart = cart.Count();

            total += count * Cost * GetDiscount(count);
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