using System.Configuration;
using Heroi.Comum.Interfaces;
using Heroi.Comum.Enums;

namespace Heroi.Comum
{
    public class ServicoConnectionString : IServicoConnectionString
    {
        public string Key;

        public ServicoConnectionString()
        {
            Key = "herois";
        }

        public IResultado<string> Ler()
        {
            return new Resultado<string>(string.Empty, StatusResultado.Sucesso, ConfigurationManager.ConnectionStrings[Key]?.ConnectionString ?? string.Empty);
        } 
    }
}
