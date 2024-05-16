using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240509
{
    public class Conta
    {
        public string numero;
        public double saldo;
        public double limite;
        public bool status;
        public List<Transacao> transacoes;

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
                transacoes[transacoes.Count - 1].duplicata = destino.transacoes[destino.transacoes.Count - 1];
                destino.transacoes[destino.transacoes.Count - 1].duplicata = transacoes[transacoes.Count - 1];
                return true;
            }
            return false;
        }

        public string ConsultarExtrato()
        {
            string extrato = "\nTipo\tValor\tDuplicata\n";
            foreach (Transacao t in transacoes)
            {
                extrato += t.tipo + "\t" + t.valor;
                if (t.duplicata != null)
                    extrato += "\t" + t.duplicata.valor + "\n";
                else
                    extrato += "\t-\n";
            }
            return extrato;
        }
    }
}