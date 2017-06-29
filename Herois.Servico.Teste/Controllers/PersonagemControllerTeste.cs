using Heroi.Comum;
using Heroi.Comum.Enums;
using Herois.Infraestrutura.Interfaces;
using Herois.Infraestrutura.Modelos;
using Herois.Infraestrutura.Servicos;
using Herois.Servico.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Herois.Servico.Teste.Controllers
{
    [TestClass]
    public class PersonagemControllerTeste
    {
        [TestMethod]
        public void Deve_Consultar_Personagem_Por_Id()
        {
            var personagem = RetornarPersonagem();

            var mockServicoPersonagem = new Mock<IServicoPersonagem>();
            mockServicoPersonagem.Setup(x => x.PesquisarPorId(1))
                .Returns(new Resultado<Personagem>(string.Empty, StatusResultado.Sucesso, personagem));

            var personagemController = new PersonagemController(mockServicoPersonagem.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var resposta = personagemController.GetPersonagens(1);

            Assert.AreEqual(HttpStatusCode.OK, resposta.StatusCode);
        }

        [TestMethod]
        public void Deve_Tratar_Erro_Ao_Retornar_Personagem_Por_Id()
        {
            var servicoConnectionString = new ServicoConnectionString { Key = "Teste" };

            var servicoPersonagem = new ServicoPersonagem(servicoConnectionString);

            var personagemController = new PersonagemController(servicoPersonagem)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var resposta = personagemController.GetPersonagens(1);

            Assert.AreEqual(HttpStatusCode.InternalServerError, resposta.StatusCode);
        }

        private static Personagem RetornarPersonagem()
        {
            var habilidade = new Habilidade
            {
                Id = 1,
                Caracteristica = "Estrategista",
                Descricao = "Capacidade de planejar cada passo, prever movimentos fisicos e extrafisicos, preparação de terreno. Alto nivel diversos tipos de inteligencia"
            };

            var personagem = new Personagem
            {
                Id = 1,
                Codinome = "Batman",
                Nome = "Bruce Wayne",
                DescricaoPersonagem = "Bruce Wayne criou o Batman para causar medo no submundo de Gotham e para defender os inocentes. O uniforme e a maneira como age quando o usa tem o objetivo de intimidar seus adversários. Enquanto Bruce Wayne é despreocupado e irresponsável, Batman é frio, determinado e implacável.",
                DescricaoNivel = "A",
                Habilidades = new List<Habilidade> { habilidade }
            };

            return personagem;
        }
    }
}
