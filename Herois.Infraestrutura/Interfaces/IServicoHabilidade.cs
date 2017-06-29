using Heroi.Comum.Interfaces;
using Herois.Infraestrutura.Modelos;
using System.Collections.Generic;

namespace Herois.Infraestrutura.Interfaces
{
    public interface IServicoHabilidade
    {
        IResultado<IEnumerable<Habilidade>> PesquisarPorIdPersonagem(int id);
    }
}
