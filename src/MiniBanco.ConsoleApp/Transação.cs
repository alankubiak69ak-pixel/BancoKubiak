using System;
public class Transacao
{
    public string Descricao{ get;}
    public string Tipo {get;}
    public decimal Valor {get;}

    public Transacao(string descricao, string tipo, decimal valor)
    {
        if(valor <=0)
        {
            throw new ArgumentException("O valor de transação deve ser maior que zero.");
        }// como as palavras Descricao e descricao são diferentes, poderia ser feito sem o "this." correto? --Perguntar ao Proff.
        this.Descricao = descricao;
        this.Tipo = tipo;
        this.Valor = valor;
    }
}
