using System;
using System.Collections;
using System.Linq;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        return input.Cast<object>()
            .Where(x => x != null)
            .Select(x => x is IEnumerable ? Flatten(x as IEnumerable) : new object[] { x })
            .SelectMany(s => s.Cast<object>());

        // foreach(var item in input)
        // {
        //     var collection = item as IEnumerable;
        //     if(collection != null)
        //     {
        //         foreach(var colItem in Flatten(collection))
        //         {
        //             yield return colItem;
        //         }
        //     } 
        //     else if(item != null)
        //     {
        //         yield return item;
        //     } ;
        // }
    }
}