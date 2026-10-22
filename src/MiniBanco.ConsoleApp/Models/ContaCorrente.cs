using MiniBanco.ConsoleApp.Exceptions;

public class ContaCorrente : Conta
{
    public ContaCorrente(string titular, int numero, decimal saldoInicial)
        : base(titular, numero, saldoInicial)
    {
    }
    public decimal LimiteChequeEspecial { get;} =500m;
     public override void Sacar(decimal valor)
    {
        if (valor >Saldo + LimiteChequeEspecial)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para realizar o saque.");
        }
        Saldo -=valor;
        RegistrarTransacao(descricao: "Saque", tipo: "Débito", valor: valor);
    }
    public override void AplicarFechamentoMensal()
    { // Implementação específica para conta corrente
        Saldo -=10m;
        RegistrarTransacao(descricao:"Tarifa", tipo: "Débito", valor: 10m);
    }
}