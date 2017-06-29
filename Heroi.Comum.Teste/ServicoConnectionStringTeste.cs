using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heroi.Comum.Teste
{
    [TestClass]
    public class ServicoConnectionStringTeste
    {
        [TestMethod]
        public void Deve_Ler_ConnectionString()
        {
            const string stringConexaoEsperada = @"Data Source=.\SQLEXPRESS;Initial Catalog=Herois;Integrated Security=True";

            var servico = new ServicoConnectionString();

            var resultado = servico.Ler();

            Assert.AreEqual(stringConexaoEsperada, resultado.Valor);
        }

        [TestMethod]
        public void Deve_Retornar_ConnectionString_Vazia_Em_Caso_De_Nao_Existir()
        {
            var servico = new ServicoConnectionString()
            {
                Key = "Bla"
            };

            var resultado = servico.Ler();

            Assert.AreEqual(string.Empty, resultado.Valor);
        }
    }
}
