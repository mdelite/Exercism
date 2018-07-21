using System;
using System.Linq;

public class BinarySearch
{
    private int[] _searchArray;
    private int loc = 0;

    public BinarySearch(int[] input)
    {
        _searchArray = new int[input.Length];
        Array.Copy(input, _searchArray, input.Length);  
    }

    public int Find(int value)
    {
        if(_searchArray.Length < 1) return -1;

        var mid = _searchArray.Length / 2;
        var val = _searchArray[mid];
      
        if(val == value)
        {
            return mid + loc;
        }
        else if(_searchArray.Length > 1 && value < val)
        {
            _searchArray = _searchArray.Take(mid).ToArray();
            return Find(value);
        } else if(_searchArray.Length > 1 && value > val)
        {
            _searchArray = _searchArray.Skip(mid).ToArray();
            loc += mid;
            return Find(value);
        } 
        return -1;
    }
}