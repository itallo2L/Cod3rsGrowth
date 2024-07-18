using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioMusicalController : ControllerBase
    {
        private readonly ServicoEstudioMusical _servicoEstudioMusical;

        public EstudioMusicalController(ServicoEstudioMusical servicoEstudioMusical)
        {
            _servicoEstudioMusical = servicoEstudioMusical;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroEstudioMusical filtro)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Adicionar([FromBody] EstudioMusical estudioMusical)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult Atualizar([FromBody] EstudioMusical estudioMusical)
        {
            throw new NotImplementedException();
        }
    }
}