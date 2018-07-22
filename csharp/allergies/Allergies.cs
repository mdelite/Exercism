using System;
using System.Collections.Generic;

[Flags]
public enum Allergen
{
    Eggs = 0x1,
    Peanuts = 0x2,
    Shellfish = 0x4,
    Strawberries = 0x8,
    Tomatoes = 0x10,
    Chocolate = 0x20,
    Pollen = 0x40,
    Cats = 0x80
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

        for(var i = 0x0001; i <= 0x0080; i <<= 1 )
        {
            if(_allergen.HasFlag((Allergen)i)) found.Add((Allergen)i);
        }

        return found.ToArray();
    }
}