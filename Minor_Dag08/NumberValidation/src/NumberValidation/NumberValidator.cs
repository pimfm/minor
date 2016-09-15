using System;
using System.Text.RegularExpressions;

public class NumberValidator
{
    public Regex pattern = new Regex(@"^-?\d{1,3}(,\d{3})*\.\d{2}$");

    public bool Validate(string number)
    {
        return pattern.IsMatch(number);
    }
}