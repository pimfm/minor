using System;

public class OnvoldoendeSaldoException : Exception
{
    public OnvoldoendeSaldoException() : base("Je kunt niet betalen, omdat de betaling eindigt in een negatief saldo.")
    {

    }
}