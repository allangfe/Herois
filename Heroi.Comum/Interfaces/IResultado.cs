using Heroi.Comum.Enums;

namespace Heroi.Comum.Interfaces
{
    public interface IResultado
    {
        string Mensagem { get; }
        StatusResultado Status { get; }
    }

    public interface IResultado<T> : IResultado
    {
        T Valor { get; }
    }
}
