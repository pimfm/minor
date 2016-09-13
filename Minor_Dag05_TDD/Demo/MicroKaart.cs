using System;

public class MicroKaart
{
    private decimal huidigeSaldo;

    public MicroKaart(decimal initieelSaldo)
    {
        this.huidigeSaldo = initieelSaldo;
    }

    public decimal HuidigeSaldo()
    {
        return this.huidigeSaldo;
    }

    public void Betaal(decimal kosten)
    {
        if (huidigeSaldo - kosten < 0)
        {
            throw new OnvoldoendeSaldoException();
        }
        this.huidigeSaldo -= kosten;
    }
}