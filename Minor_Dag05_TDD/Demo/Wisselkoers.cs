public struct Wisselkoers
{
    private WisselkoersKoppel koppel;
    private decimal koers;

    public Wisselkoers(GeldSoort van, GeldSoort naar, decimal koers)
    {
        this.koppel = new WisselkoersKoppel(van, naar);
        this.koers = koers;
    }

    public WisselkoersKoppel ValutaKoppel()
    {
        return this.koppel;
    }

    public decimal Koers()
    {
        return this.koers;
    }
}