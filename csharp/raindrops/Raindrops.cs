using System;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var numberString = "";

        if(number % 3 == 0) numberString += "Pling";
        if(number % 5 == 0) numberString += "Plang";
        if(number % 7 == 0) numberString += "Plong";

        if(numberString == "") numberString = number.ToString();

        return numberString;
    }
}