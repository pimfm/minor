using System;
using System.Collections.Generic;

public class GeldSoortFormatter
{
    private Dictionary<string, string> _formats;

    public GeldSoortFormatter()
    {
        _formats = new Dictionary<string, string>(); 
    }

    public void addFormat(GeldSoort geldSoort, string format)
    {
        _formats.Add(geldSoort.ToString(), format);
    }

    public string getFormat(GeldSoort geldSoort)
    {
        string format = "";

        _formats.TryGetValue(geldSoort.ToString(), out format);

        return format;
    }
}