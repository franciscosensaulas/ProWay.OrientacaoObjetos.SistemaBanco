using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWay.OrientacaoObjetos.Models.ContaBancaria
{
    public abstract class Conta 
    {
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public int Codigo { get; set; }

        public abstract void Depositar(double valorDeposito);

        // Virtual permite a classe filha modificar o comportamento 
        // do método, ou seja, fazer o saque de forma diferente
        public virtual void Sacar(double valorSaque)
        {
            if(valorSaque <= Saldo)
            {
                Saldo -= valorSaque;
            }
            else
            {
                throw new Exception("Valor do saque é maior do que o saldo, não é possível realizar o saque");
            }
        }
        public override string ToString()
        {
            return $"Código: {Codigo} Nome: {Nome} Saldo: {Saldo}";
        }
    }
}
