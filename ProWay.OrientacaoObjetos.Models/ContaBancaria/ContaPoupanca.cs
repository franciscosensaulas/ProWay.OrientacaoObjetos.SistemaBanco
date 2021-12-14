using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWay.OrientacaoObjetos.Models.ContaBancaria
{
    public class ContaPoupanca : Conta
    {
        // Construtor é uma forma de garantir que o objeto
        // é construído da forma correta, ou seja, neste
        // cenário para abrir uma conta poupança é obrigatório
        // ter nome e saldo da conta antes de conseguir abrir
        // efetivamente
        public ContaPoupanca(string nome, double saldo)
        {
            Nome = nome;
            Saldo = saldo;
        }
    }
}
