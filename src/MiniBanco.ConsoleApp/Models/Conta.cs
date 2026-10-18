public abstract class Conta
{
    public string Titular { get; set; }
    public int Numero { get; set; }

    public  decimal Saldo { get; protected set; }

    public Conta(string titular, int numero, decimal saldoInicial)
    {
        this.Titular =titular;
        this.Numero = numero;
        this.Saldo = saldoInicial;
    }

}