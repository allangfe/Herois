using Heroi.Comum;
using Heroi.Comum.Interfaces;
using Herois.Infraestrutura.Interfaces;
using Herois.Infraestrutura.Servicos;
using SimpleInjector;

namespace Herois.Servico.SimpleInjector
{
    public class IoC
    {
        public static void ConfigurarInjecao(Container container)
        {
            container.Register<IServicoConnectionString, ServicoConnectionString>();
            container.Register<IServicoPersonagem, ServicoPersonagem>();
        }
    }
}