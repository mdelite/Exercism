using System;
using System.Collections.Generic;

[Flags]
public enum Allergen
{
    Eggs            = 0x0001,
    Peanuts         = 0x0002,
    Shellfish       = 0x0004,
    Strawberries    = 0x0008,
    Tomatoes        = 0x0010,
    Chocolate       = 0x0020,
    Pollen          = 0x0040,
    Cats            = 0x0080
}

public class Allergies
{
    private Allergen _allergen;
    public Allergies(int mask)
    {
        _allergen = (Allergen)mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return _allergen.HasFlag(allergen);
    }

    public Allergen[] List()
    {
        var found = new List<Allergen>();

        foreach(Allergen p in Enum.GetValues(typeof(Allergen)))
        {
            if(_allergen.HasFlag(p)) found.Add(p);
        }

        return found.ToArray();
    }
}