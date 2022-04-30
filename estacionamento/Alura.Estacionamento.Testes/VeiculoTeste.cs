using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        #region
        /* Padrão para teste (AAA)
            - Arrange -> preparação do ambiente(cenário) do método que quero testar. Ex: quais objetos precisarei instanciar etc para testar.
            - Act -> método que quero realmente testar
            - Assert -> verificação do resultado obtido com a execução daquele método que foi executado
            */
        #endregion

        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact/*(DisplayName = "Teste nº 1")*/]
        //[Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Asset
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact (Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichadeInformacaoDoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "José silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "asd-9999";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do veículo:", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );//tratar exceções
        }

        [Fact]
        public void TestaMensagemDeExecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF0000";

            //Act
            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }
        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
