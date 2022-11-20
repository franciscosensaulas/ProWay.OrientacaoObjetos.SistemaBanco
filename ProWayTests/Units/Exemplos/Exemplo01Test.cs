using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProwayTests.Units.Service.Services.Categorias
{
    public class Exemplo01Test

    {
        //Fact -> cenario de teste
        [Fact] 
        public void Test_Same_Value()
        {
            //Arraneg -> PReparar os dados para realizar o ato do teste
            var numero1 = 2;
            var numero2 = 10;

            //Acr -> Realizar o ato do teste
            var multiplicacao = numero1 * numero2;

            //Assert -> Validar o que o teste executou/retornou
            multiplicacao.Should().Be(20);
        }

        [Theory]
        [InlineData(2,1,2)]
        [InlineData(2,2,4)]
        [InlineData(2,3,6)]
        public void Test_Multiplicacao_Varios_Cenarios(int numero1, int numero2, int resultadoEsperado)
        {
            //Act -> Realizar o ato do teste
            var multiplicacao = numero1 * numero2;

            //Assert -> Validar o que o teste executou/retornou
            multiplicacao.Should().Be(resultadoEsperado);
        }

    }
}
