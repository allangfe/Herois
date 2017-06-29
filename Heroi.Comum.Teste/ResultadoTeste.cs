using Heroi.Comum;
using Heroi.Comum.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heroi.Comum.Teste
{
    [TestClass]
    public class ResultadoTeste
    {
        [TestMethod]
        public void Deve_Obter_Um_Resultado()
        {
            var mensagem = "";
            var status = StatusResultado.Sucesso;

            var resultado = new Resultado(mensagem, status);

            Assert.AreEqual(string.Empty, resultado.Mensagem);
            Assert.AreEqual(StatusResultado.Sucesso, resultado.Status);
        }

        [TestMethod]
        public void Deve_Obter_Um_Resultado_Tipado()
        {
            var mensagem = "";
            var status = StatusResultado.Sucesso;
            var teste = "bla";

            var resultado = new Resultado<string>(mensagem, status, teste);

            Assert.AreEqual(string.Empty, resultado.Mensagem);
            Assert.AreEqual(StatusResultado.Sucesso, resultado.Status);
            Assert.AreEqual("bla", resultado.Valor);
        }
    }
}
