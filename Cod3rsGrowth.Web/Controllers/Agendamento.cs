using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Agendamento : ControllerBase
    {
        private readonly ServicoAgendamento _servicoAgendamento;

        public Agendamento(ServicoAgendamento servicoAgendamento)
        {
            _servicoAgendamento = servicoAgendamento;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromBody] FiltroAgendamento filtro)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult ObtertPorId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Adicionar([FromBody] Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public IActionResult Atualizar([FromBody] Agendamento agendamento)
        {
            throw new NotImplementedException();
        }
    }
}
