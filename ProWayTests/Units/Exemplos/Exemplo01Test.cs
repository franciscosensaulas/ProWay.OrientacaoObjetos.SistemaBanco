using FluentAssertions;
using Xunit;

namespace ProWayTests.Units.Service.Services.Categorias
{
    public class Exemplo01Test
    {
        // Fact -> cenário de teste
        [Fact]
        public void Test_Same_Value()
        {
            // Arrange -> Preparar os dados para realizar o ato do teste
            var numero1 = 2;
            var numero2 = 10;

            // Act -> realizar o ato do teste
            var multiplicacao = numero1 * numero2;

            // Assert -> validar o que o teste executou/retornou.
            multiplicacao.Should().Be(20);
        }

        [Theory]
        [InlineData(2, 1, 2)] // cenário 1 => 2 x 1 => 2
        [InlineData(2, 2, 4)] // cenário 2 => 2 x 2 => 4
        [InlineData(2, 3, 6)] // cenário 3 => 2 x 3 => 6
        public void Test_Multiplicacao_Varios_Cenarios(
            int numero1, 
            int numero2, 
            int resultadoEsperado)
        {
            // Act
            var multiplicacao = numero1 * numero2;

            // Assert
            multiplicacao.Should().Be(resultadoEsperado);
        }
    }
}
