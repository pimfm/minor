public struct WisselkoersKoppel
{
    private GeldSoort naar;
    private GeldSoort van;

    public WisselkoersKoppel(GeldSoort van, GeldSoort naar)
    {
        this.van = van;
        this.naar = naar;
    }
}