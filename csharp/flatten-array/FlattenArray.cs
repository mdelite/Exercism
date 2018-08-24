using System;
using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach(var item in input)
        {
            var collection = item as IEnumerable;
            if(collection != null)
            {
                foreach(var colItem in Flatten(collection))
                {
                    yield return colItem;
                }
            } 
            else if(item != null)
            {
                yield return item;
            } 
        }
    }
}