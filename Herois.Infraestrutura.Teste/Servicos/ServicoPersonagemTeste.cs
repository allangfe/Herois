using Heroi.Comum;
using Heroi.Comum.Enums;
using Herois.Infraestrutura.Modelos;
using Herois.Infraestrutura.Servicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Herois.Infraestrutura.Teste.Servicos
{
    [TestClass]
    public class ServicoPersonagemTeste
    {
        [TestMethod]
        public void Deve_Pesquisar_Personagem_Por_Id()
        {
            var idPersonagem = 1;

            var servicoPersonagem = new ServicoPersonagem(new ServicoConnectionString());

            var habilidade1 = new Habilidade
            {
                Id = 1,
                Caracteristica = "Estrategista",
                Descricao = "Capacidade de planejar cada passo, prever movimentos físicos e extrafísicos, preparação de terreno. Alto nível e diversos tipos de inteligência."
            };

            var habilidade2 = new Habilidade
            {
                Id = 2,
                Caracteristica = "Investigador",
                Descricao = "Capacidade de investigar e analisar as menores evidências possíveis para chegar a verdade de um crime ou algum objetivo investigativo."
            };

            var personagemEsperado = new Personagem
            {
                Id = idPersonagem,
                Codinome = "Batman",
                Nome = "Bruce Wayne",
                DescricaoPersonagem = "Bruce Wayne criou o Batman para causar medo no submundo de Gotham e para defender os inocentes. O uniforme e a maneira como age quando o usa tem o objetivo de intimidar seus adversários. Enquanto Bruce Wayne é despreocupado e irresponsável, Batman é frio, determinado e implacável.",
                DescricaoNivel = "A",
                Habilidades = new List<Habilidade>
                {
                    habilidade1,
                    habilidade2
                }
            };

            var retorno = servicoPersonagem.PesquisarPorId(idPersonagem);

            Assert.AreEqual(StatusResultado.Sucesso, retorno.Status);
            Assert.AreEqual(personagemEsperado.Id, retorno.Valor.Id);
            Assert.AreEqual(personagemEsperado.Codinome, retorno.Valor.Codinome);
            Assert.AreEqual(personagemEsperado.Nome, retorno.Valor.Nome);
            Assert.AreEqual(personagemEsperado.DescricaoPersonagem, retorno.Valor.DescricaoPersonagem);
            Assert.AreEqual(personagemEsperado.DescricaoNivel, retorno.Valor.DescricaoNivel);
            Assert.AreEqual(habilidade1.Id, retorno.Valor.Habilidades.FirstOrDefault().Id);
            Assert.AreEqual(habilidade1.Caracteristica, retorno.Valor.Habilidades.FirstOrDefault().Caracteristica);
            Assert.AreEqual(habilidade1.Descricao, retorno.Valor.Habilidades.FirstOrDefault().Descricao);
            Assert.AreEqual(habilidade2.Id, retorno.Valor.Habilidades.LastOrDefault().Id);
            Assert.AreEqual(habilidade2.Caracteristica, retorno.Valor.Habilidades.LastOrDefault().Caracteristica);
            Assert.AreEqual(habilidade2.Descricao, retorno.Valor.Habilidades.LastOrDefault().Descricao);
        }

        [TestMethod]
        public void Deve_Retornar_Resultado_De_Erro_Em_Caso_De_Nao_Conectividade_Com_O_Banco_De_Dados_Ao_PesquisarPorId()
        {
            var servicoConnectionString = new ServicoConnectionString
            {
                Key = "Teste"
            };

            var servicoPersonagem = new ServicoPersonagem(servicoConnectionString);

            var IdPersonagem = 1;

            var retorno = servicoPersonagem.PesquisarPorId(IdPersonagem);

            Assert.IsTrue(retorno.Mensagem.Length > 0);
            Assert.AreEqual(StatusResultado.Erro, retorno.Status);
        }
    }
}
