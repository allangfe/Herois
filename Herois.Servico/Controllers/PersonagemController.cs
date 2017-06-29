using Heroi.Comum.Enums;
using Herois.Infraestrutura.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Herois.Servico.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonagemController : ApiController
    {
        private readonly IServicoPersonagem _servicoPersonagem;

        public PersonagemController(IServicoPersonagem servicoPersonagem)
        {
            _servicoPersonagem = servicoPersonagem;
        }

        [Route("api/herois/personagem/{id}")]
        public HttpResponseMessage GetPersonagens(int id)
        {
            var resultado = _servicoPersonagem.PesquisarPorId(id);

            if(resultado.Status == StatusResultado.Erro)
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

            return Request.CreateResponse(HttpStatusCode.OK, resultado.Valor);
        }
    }
}
