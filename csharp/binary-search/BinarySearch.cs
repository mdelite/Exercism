using System;

public class BinarySearch
{
    private int[] _ary;

    public BinarySearch(int[] input)
    {
        _ary = input;  
    }

    public int Find(int value) => Search(value, 0, _ary.Length - 1);

    private int Search(int value, int min, int max)
    {
        if(max < min) return -1;

        var i = (min + max) / 2;

        if (value > _ary[i]) return Search(value, i + 1, max);
        if (value < _ary[i]) return Search(value, min, i - 1);
        return i;
    }
}