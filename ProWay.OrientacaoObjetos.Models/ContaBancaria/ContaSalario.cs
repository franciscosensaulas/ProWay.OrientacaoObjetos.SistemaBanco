using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWay.OrientacaoObjetos.Models.ContaBancaria
{
    internal class ContaSalario
    {
        public string Nome { get; set; }
        public double Saldo { get; private set; }

        public void Depositar(double valor)
        {

        }
    }

        class B
        {
            void A()
            {
                ContaSalario conta = new ContaSalario();
                // Não é possível atribuir por ser private a atribuição(set)
                // conta.Saldo = 1000000;
            }
        }
    }
