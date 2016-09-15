using System;

public struct Valuta : IEquatable<Valuta>
{
    private GeldSoort _geldSoort;
    private decimal _waarde;

    public Valuta(decimal waarde, GeldSoort geldSoort)
    {
        this._waarde = waarde;
        this._geldSoort = geldSoort;
    }

    public override string ToString()
    {
        return $"{_waarde:N2} {_geldSoort}";
    }

    public GeldSoort GeldSoort()
    {
        return _geldSoort;
    }

    public Valuta Times(decimal koers, GeldSoort geldSoort)
    {
        return new Valuta(_waarde * koers, geldSoort);
    }

    public string Format(GeldSoortFormatter formatter)
    {
        string geldSoortFormat = formatter.getFormat(_geldSoort);

        return $"{geldSoortFormat} {_waarde:N2}";
    }

    public bool Equals(Valuta other)
    {
        return base.Equals(other);
    }

    public static bool operator == (Valuta valuta, Valuta other)
    {
        return valuta.Equals(other);
    }

    public static bool operator != (Valuta valuta, Valuta other)
    {
        return !valuta.Equals(other);
    }
}