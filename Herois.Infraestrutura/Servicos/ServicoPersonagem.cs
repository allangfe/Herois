using Herois.Infraestrutura.Modelos;
using Herois.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using Heroi.Comum.Interfaces;
using System.Data.SqlClient;
using Heroi.Comum;
using Heroi.Comum.Enums;
using System.Text;
using Dapper;
using System.Linq;
using System.Data;

namespace Herois.Infraestrutura.Servicos
{
    public class ServicoPersonagem : IServicoPersonagem
    {
        private readonly IServicoConnectionString _servicoConnectionString;

        public ServicoPersonagem(IServicoConnectionString servicoConnectionString)
        {
            _servicoConnectionString = servicoConnectionString;
        }

        public IResultado<Personagem> PesquisarPorId(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_servicoConnectionString.Ler().Valor))
                {
                    return new Resultado<Personagem>(string.Empty, StatusResultado.Sucesso, RetornarPersonagemPorId(id, conn));
                }
            }
            catch (Exception ex)
            {
                return new Resultado<Personagem>($"Mensagem: {ex.Message}; InnerException: {ex.InnerException?.Message}; StackTrace: {ex.StackTrace}", StatusResultado.Erro, new Personagem());
            }
        }

        private static Personagem RetornarPersonagemPorId(int id, IDbConnection conn)
        {
            var habilidades = RetornarHabilidades(id, conn);

            var sqlPersonagem = new StringBuilder();

            sqlPersonagem.AppendLine("Select Pe.Cod_Personagem as Id, Pe.Codinome, Pe.Nome, Pe.Descricao as DescricaoPersonagem, Ni.Descricao as DescricaoNivel, Ha.Caracteristica as CaracteristicaHabilidade, Ha.Descricao as DescricaoHabilidade ");
            sqlPersonagem.AppendLine("from Personagem Pe ");
            sqlPersonagem.AppendLine("inner join Nivel Ni on Ni.Cod_Nivel = Pe.Cod_Nivel ");
            sqlPersonagem.AppendLine("inner join Personagem_Habilidade PH on PH.Cod_Personagem = Pe.Cod_Personagem ");
            sqlPersonagem.AppendLine("inner join Habilidade Ha on Ha.Cod_Habilidade = PH.Cod_Habilidade ");
            sqlPersonagem.AppendLine("where Pe.Cod_Personagem = @id");

            var personagens = conn.Query<Personagem>(sqlPersonagem.ToString(), new { id }).FirstOrDefault();

            personagens.Habilidades = habilidades;

            return personagens;
        }

        private static IEnumerable<Habilidade> RetornarHabilidades(int id, IDbConnection conn)
        {
            var sqlHabilidades = new StringBuilder();
            sqlHabilidades.AppendLine("Select Ha.Cod_Habilidade as Id, Ha.Caracteristica, Ha.Descricao ");
            sqlHabilidades.AppendLine("from Personagem Pe ");
            sqlHabilidades.AppendLine("inner join Personagem_Habilidade PH on PH.Cod_Personagem = Pe.Cod_Personagem ");
            sqlHabilidades.AppendLine("inner join Habilidade Ha on Ha.Cod_Habilidade = PH.Cod_Habilidade ");
            sqlHabilidades.AppendLine("where Pe.Cod_Personagem = @id");

            return conn.Query<Habilidade>(sqlHabilidades.ToString(), new { id });
        }
    }
}
