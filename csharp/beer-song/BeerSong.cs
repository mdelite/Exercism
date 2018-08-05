using System;
using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var song = new StringBuilder();
        var bottles = startBottles;
        
        for(int i = 0; i < takeDown; i++)
        {
            var bottleText = BottleString(bottles);
            var bottlesLeft = BottleString(--bottles);
            song.Append(string.Format("{0} of beer on the wall, {1} of beer.\n", Char.ToUpper(bottleText[0]) + bottleText.Substring(1), bottleText ));

            if(bottles > -1)
            {
                song.Append(string.Format("Take {0} down and pass it around, {1} of beer on the wall.", bottles == 0 ? "it" : "one" , bottlesLeft));
            }
            else
            {
                song.Append(string.Format("Go to the store and buy some more, 99 bottles of beer on the wall."));
                bottles = 99;
            }

            // another bottle is a comin'!
            if(i < takeDown - 1) song.Append("\n\n");
        }

        return song.ToString();
    }

    private static string BottleString(int v)
    {
        if(v > 0)
        {
            return string.Format("{0} bottle{1}", v, v == 1 ? "" : "s" );
        }

        return "no more bottles";
    }
}