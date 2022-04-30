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
        /* Padr�o para teste (AAA)
            - Arrange -> prepara��o do ambiente(cen�rio) do m�todo que quero testar. Ex: quais objetos precisarei instanciar etc para testar.
            - Act -> m�todo que quero realmente testar
            - Assert -> verifica��o do resultado obtido com a execu��o daquele m�todo que foi executado
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

        [Fact/*(DisplayName = "Teste n� 1")*/]
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

        [Fact (Skip = "Teste ainda n�o implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichadeInformacaoDoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Jos� silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "asd-9999";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do ve�culo:", dados);
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
            );//tratar exce��es
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
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }
        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
