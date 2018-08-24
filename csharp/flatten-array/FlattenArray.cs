using System;
using System.Collections;
using System.Linq;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input) => input
        .Cast<object>()
        .Where(x => x != null)
        .Select(y => y is IEnumerable ? Flatten(y as IEnumerable) : new object[] { y })
        .SelectMany(z => z.Cast<object>());
}