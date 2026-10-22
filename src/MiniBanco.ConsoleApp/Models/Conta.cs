using MiniBanco.ConsoleApp.Exceptions;

public abstract class Conta
{
    public string Titular { get; }
    public int Numero { get; }

    public decimal Saldo { get; protected set; }

    public Conta(string titular, int numero, decimal saldoInicial)
    {
        this.Titular = titular;
        this.Numero = numero;
        this.Saldo = saldoInicial;
    }

    public List<Transacao> Extrato { get; } = new List<Transacao>();
    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor de depósito deve ser maior que zero.");
        }
        Saldo += valor;
        RegistrarTransacao(descricao: "Depósito", tipo: "Crédito", valor: valor);
    }
    public virtual void Sacar(decimal valor)
    {
        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para realizar o saque.");
        }
        Saldo -= valor;
        RegistrarTransacao(descricao: "Saque",tipo: "Débito", valor: valor);

    }

    public void RegistrarTransacao(string descricao, string tipo, decimal valor)
    {
        Extrato.Add(new Transacao(descricao: descricao, tipo: tipo, valor: valor));
    }
    public virtual void AplicarFechamentoMensal()
    {

    }
}