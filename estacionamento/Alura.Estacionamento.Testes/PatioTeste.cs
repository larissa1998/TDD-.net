using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste : IDisposable
    {
        #region
        //Fact -> métodos de teste simples, onde não há necessidade de passar parâmetros etc.
        #endregion
        private Veiculo veiculo;
        private Operador Operador;
        public ITestOutputHelper saidaConsoleTeste;


        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();

            Operador = new Operador();
            Operador.Nome = "Pedro Fagundes";
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            /*Operador operador = new Operador();
            operador.Nome = "Pedro Fagundes";*/

            estacionamento.OperadorPatio = Operador;

            veiculo.Proprietario = "André silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        #region
        //Teory -> permite trabalhar com um conjunto maior de dados.
        //InlineData -> passa os parametros que vão ser usados no método de teste.
        #endregion

        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        [InlineData("José Silva", "POL-9242", "cinza", "Fusca")]
        [InlineData("Maria Silva", "GDR-6524", "Azul", "Opala")]
        
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = Operador;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = Operador;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Asserts
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            estacionamento.OperadorPatio = Operador;
            veiculo.Proprietario = "José silva";
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Verde"; //alterado
            veiculoAlterado.Modelo = "Opala";


            //Act
            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
