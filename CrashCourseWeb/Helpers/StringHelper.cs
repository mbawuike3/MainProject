using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CrashCourseWeb.Helpers;

public class StringHelper
{
    public static bool IsAlphabelts(string? input)
    {
        string pattern = "^[A-Za-z]+$";
        return Regex.IsMatch(input!, pattern);
    }

    public static bool IsNumbers(string? input)
    {
        string pattern = "^[0-9]+$";
        return Regex.IsMatch(input!, pattern);
    }

    public static bool IsValidEmail(string? input)
    {
        EmailAddressAttribute emailValidator = new();
        return emailValidator.IsValid(input);
    }
    public static bool isAlphaNumeric(string? input)
    {
        string pattern = "^[a-zA-Z0-9@#$%^&+=]*$";
        return Regex.IsMatch(input!, pattern);
    }
}
