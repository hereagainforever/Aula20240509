using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240509
{
    public class Conta
    {
        protected string? numero;
        protected double saldo;
        protected double limite;
        protected bool status;
        protected List<Transacao> transacoes;


        public string? Numero
        {
            get => this.numero;
            set 
            {
                if (value != null)
                    this.numero = value;
            }
        }

        public double Saldo { get => this.saldo; }
        public double Limite
        {
            get => this.limite;
            set
            {
                if (value >= 0)
                    this.limite = value;
            }
        }

        public bool Status
        {
            get => this.status;
            set => this.status = value;
        }

        public List<Transacao> Transacoes { get => this.transacoes; }


        public Conta()
        {
            this.saldo = 0;
            this.status = true;
            transacoes = new List<Transacao>();
        }

        public Conta(string numero) : this()
        {
            this.numero = numero;
        }

        public bool Sacar(double valor)
        {
            if (saldo - valor > -limite && status)
            {
                saldo -= valor;
                transacoes.Add(new Transacao(valor, 'S', this));
                return true;
            }
            return false;
        }

        public bool Depositar(double valor)
        {
            if (valor > 0 && status)
            {
                saldo += valor;
                transacoes.Add(new Transacao(valor, 'D', this));
                return true;
            }
            return false;
        }

        public bool Transferir(Conta destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor))
            {
                transacoes[transacoes.Count - 1].Duplicata = destino.transacoes[destino.transacoes.Count - 1];
                destino.transacoes[destino.transacoes.Count - 1].Duplicata = transacoes[transacoes.Count - 1];
                return true;
            }
            return false;
        }

        public string ConsultarExtrato()
        {
            string extrato = "\nTipo\tValor\tDuplicata\n";
            foreach (Transacao t in transacoes)
            {
                extrato += t.Tipo + "\t" + t.Valor;
                if (t.Duplicata != null && t.Duplicata.Conta != null)
                    extrato += "\t" + t.Duplicata.Conta.Numero + "\n";
                else
                    extrato += "\t-\n";
            }
            return extrato;
        }
    }
}