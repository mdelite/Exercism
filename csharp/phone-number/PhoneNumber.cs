using System;
using System.Linq;


public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var clean = new string(phoneNumber.Where(IsNumber).ToArray());

        if(clean.Length < 10 || clean.Length > 11)
            throw new ArgumentException("Valid phone number must be between 10 and 11 digits");
        
        

        if(clean.Length == 11)
        {
            if(!clean.StartsWith('1')) throw new ArgumentException();

            clean = clean.Substring(1);
        }

        if(clean.StartsWith('1') || clean.StartsWith('0')) throw new ArgumentException("Invalid area code");

        if(clean.Substring(3,1) == "0" || clean.Substring(3,1) == "1") throw new ArgumentException("Invalid exchange code");

        return clean;
    }

    private static bool IsNumber(char c) => (int)c >= 48 && (int)c <= 57;
}