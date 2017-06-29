using System.Collections.Generic;

namespace Herois.Infraestrutura.Modelos
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Codinome { get; set; }
        public string Nome { get; set; }
        public string DescricaoPersonagem { get; set; }
        public string DescricaoNivel { get; set; }
        public IEnumerable<Habilidade> Habilidades { get; set; }
    }
}
