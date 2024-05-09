﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240509
{
    public class CPoupanca
    {
        public string numero;
        public double saldo;
        public bool status;
        public List<Transacao> transacoes;

        public CPoupanca()
        {
            this.saldo = 0;
            this.status = true;
            transacoes = new List<Transacao>();
        }

        public CPoupanca(string numero) : this()
        {
            this.numero = numero;
        }

        public bool Sacar(double valor)
        {
            if (saldo - valor > 0 && status)
            {
                saldo -= valor;
                transacoes.Add(new Transacao(valor, 'S'));
                return true;
            }
            return false;
        }

        public bool Depositar(double valor)
        {
            if (valor > 0 && status)
            {
                saldo += valor;
                transacoes.Add(new Transacao(valor, 'D'));
                return true;
            }
            return false;
        }

        public bool Transferir(CCorrente destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor))
            {
                transacoes[transacoes.Count - 1].duplicata = destino.transacoes[destino.transacoes.Count - 1];
                destino.transacoes[destino.transacoes.Count - 1].duplicata = transacoes[transacoes.Count - 1];
                return true;
            }
            return false;
        }

        public bool Transferir(CPoupanca destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor))
            {
                transacoes[transacoes.Count - 1].duplicata = destino.transacoes[destino.transacoes.Count - 1];
                destino.transacoes[destino.transacoes.Count - 1].duplicata = transacoes[transacoes.Count - 1];
                return true;
            }
            return false;
        }
    }
}