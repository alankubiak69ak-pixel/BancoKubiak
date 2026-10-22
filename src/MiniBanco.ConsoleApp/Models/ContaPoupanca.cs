public class ContaPoupanca : Conta
{
    public ContaPoupanca(string titular, int numero, decimal saldoInicial)
    :base(titular, numero, saldoInicial)
    {
        
    }
        public double TaxaRendimentoMensal {get;} = 0.5; // 0,5% de rendimento mensal
        public int DiaAniversario {get;} =10; // Dia do mês em que o rendimento é aplicado

    public override void AplicarFechamentoMensal()
    {
        decimal rendimento = Saldo * (decimal)(TaxaRendimentoMensal / 100);
        Saldo += rendimento;
        RegistrarTransacao (descricao: "Rendimento Mensal", tipo: "Depósito", valor : rendimento);
    }

    
}