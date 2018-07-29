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
        var cartCount = cart.Count();
        var groups = new List<int>();

        while(cartCount > 0)
        {
            // find max group of distinct books
            var distinct = cart.Distinct().ToList();
            var c = distinct.Count();

            // if we find a group of 3 and we have previously
            // found a group of 5, remove the 5 group and add
            // two groups of 4 as it is a better deal. 
            if(c == 3 && groups.Contains(5))
            {
                groups.Remove(5);
                groups.AddRange( new int[] {4,4});
            }
            else
            {
                groups.Add(c);
            }

            // remove the distinct books that we found from the cart.
            foreach(var d in distinct)
            {
                cart.Remove(d);
            }

            // update the cart count
            cartCount = cart.Count();

        }

        // sum up our total.
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
            case 5:
                return 0.75;
            default:
                throw new ArgumentException();
        }
    }
}