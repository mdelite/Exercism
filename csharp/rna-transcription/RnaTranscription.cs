using System;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        var rna = "";

        foreach(var n in nucleotide)
        {
            rna += ConvertNucleotide(n);
        }

        return rna;
    }

    private static char ConvertNucleotide(char nucleotide)
    {
        switch(nucleotide)
        {
            case 'G' : return 'C';
            case 'C' : return 'G';
            case 'T' : return 'A';
            case 'A' : return 'U';
            default : throw new ArgumentException();
        }
    }
}