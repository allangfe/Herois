using Heroi.Comum.Interfaces;
using Herois.Infraestrutura.Modelos;

namespace Herois.Infraestrutura.Interfaces
{
    public interface IServicoPersonagem
    {
        IResultado<Personagem> PesquisarPorId(int id);
    }
}
