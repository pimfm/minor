using System;
using System.Collections.Generic;

public class Bank
{
    private Dictionary<WisselkoersKoppel, decimal> _wisselkoersen;

    public Bank()
    {
        _wisselkoersen = new Dictionary<WisselkoersKoppel, decimal>();
    }

    public void VoegWisselkoersToe(GeldSoort van, GeldSoort naar, decimal koers)
    {
        WisselkoersKoppel koppel = new WisselkoersKoppel(van, naar);

        _wisselkoersen.Add(koppel, koers);
    }

    public Valuta Converteer(Valuta valuta, GeldSoort geldSoort)
    {
        WisselkoersKoppel teGebruikenKoers = new WisselkoersKoppel(valuta.GeldSoort(), geldSoort);
        decimal koers = 0.0M;

        _wisselkoersen.TryGetValue(teGebruikenKoers, out koers);

        return valuta.Times(koers, geldSoort);
    }
}