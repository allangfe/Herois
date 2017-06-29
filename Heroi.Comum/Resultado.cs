using Heroi.Comum.Enums;
using Heroi.Comum.Interfaces;

namespace Heroi.Comum
{
    public class Resultado : IResultado
    {
        public string Mensagem { get; }
        public StatusResultado Status { get; }

        public Resultado(string mensagem, StatusResultado status)
        {
            Mensagem = mensagem;
            Status = status; 
        }
    }

    public class Resultado<T> : IResultado<T>
    {
        public string Mensagem { get; }
        public StatusResultado Status { get; }
        public T Valor { get; }

        public Resultado(string mensagem, StatusResultado status, T valor)
        {
            Mensagem = mensagem;
            Status = status;
            Valor = valor;
        }
    }
}
