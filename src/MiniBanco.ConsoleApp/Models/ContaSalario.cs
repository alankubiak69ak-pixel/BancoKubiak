using MiniBanco.ConsoleApp.Exceptions;

public class ContaSalario : Conta
{
    public string Empregador { get; }
    public int LimiteSaquesMensal { get; }



    public ContaSalario(string titular, int numero, decimal saldoInicial, string empregador, int limiteSaquesMensal)
    : base(titular, numero, saldoInicial)
    {
        this.Empregador = empregador;
        this.LimiteSaquesMensal = limiteSaquesMensal;



    }
    private int saquesRealizados = 0;
    public override void Sacar(decimal valor)
    {
        base.Sacar(valor);
        saquesRealizados++;

        if (saquesRealizados > LimiteSaquesMensal)
        {
            Saldo -= 5m;
            RegistrarTransacao(descricao: "Tarifa sobre saque excedido", tipo: "Tarifa", valor: 5m);
        }
    }
    public override void AplicarFechamentoMensal()
    {
        saquesRealizados=0;
    }

}