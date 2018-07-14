using System;

public static class Bob
{
    public static string Response(string statement)
    {
        //remove all whitespace
        statement = statement.Trim();

        //nothing said
        if (statement.Length == 0) return "Fine. Be that way!";

        //is a question?
        if (statement.EndsWith('?'))
        {
            //are we yelling? 
            if (statement.IsUpper())
            {
                return "Calm down, I know what I'm doing!";
            }
            return "Sure.";
        }

        //are we yelling?
        if (statement.IsUpper()) return "Whoa, chill out!";

        return "Whatever.";
    }

}

static class Extensions
{
    public static bool IsUpper(this string p)
    {
        var hasLetter = false;

        for( var i = 0; i < p.Length; i++)
        {
            //set to true if one of the characters is a letter
            hasLetter = hasLetter || char.IsLetter(p, i);

            //if a lower case letter is found return false
            if(char.IsLower(p,i))
            {
                return false;
            }
        }
        return hasLetter;  //will return false if string contained no letters
    }

    public static bool IsLower(this string p)
    {
        var hasLetter = false;

        for (var i = 0; i < p.Length; i++)
        {
            //set to true if one of the characters is a letter
            hasLetter = hasLetter || char.IsLetter(p, i);

            //if a upper case letter is found return false
            if (char.IsUpper(p, i))
            {
                return false;
            }
        }
        return hasLetter;  //will return false if string contained no letters
    }
}