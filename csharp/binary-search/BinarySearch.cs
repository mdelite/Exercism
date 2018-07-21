using System;
using System.Linq;

public class BinarySearch
{
    private int[] _searchArray;
    private int loc = 0;

    public BinarySearch(int[] input)
    {
        _searchArray = input;  
    }

    public int Find(int value) => Search(value, 0, _searchArray.Length - 1);

    private int Search(int value, int min, int max)
    {
        if(max < min) return -1;

        var i = (min + max) / 2;

        if (value > _searchArray[i]) return Search(value, i + 1, max);
        if (value < _searchArray[i]) return Search(value, min, i - 1);
        return i;
    }
}