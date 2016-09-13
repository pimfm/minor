using System;
using System.Collections.Generic;

public class VIPMicroKaart
{
    private decimal huidigeKortingsPercentage;
    private decimal huidigeSaldo;

    public VIPMicroKaart(decimal kortingsPercentage)
    {
        this.huidigeSaldo = 0.0M;
        this.huidigeKortingsPercentage = kortingsPercentage;
    }

    public decimal HuidigeKortingsPercentage()
    {
        return this.huidigeKortingsPercentage;
    }

    public void Betaal(decimal kostenHorloge)
    {
        decimal teBetalenPercentage = (100M - this.huidigeKortingsPercentage) / 100;
        decimal kosten = kostenHorloge * teBetalenPercentage;

        this.huidigeSaldo -= kosten;
    }

    public decimal HuidigeSaldo()
    {
        return this.huidigeSaldo;
    }
}