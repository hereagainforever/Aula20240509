using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240509
{
    public class Transacao
    {
        private double valor;
        private char tipo;
        private Transacao? duplicata;
        private Conta? conta;


        public double Valor { get => this.valor; }

        public char Tipo { get => this.tipo; }

        public Transacao? Duplicata
        {
            get => this.duplicata;
            set {
                if (value != null)
                    this.duplicata = value;
            }
        }

        public Conta? Conta { get => this.conta; }


        public Transacao(double valor, char tipo, Conta conta)
        {
            this.valor = valor;
            this.tipo = tipo;
            this.conta = conta;
        }
    }
}
