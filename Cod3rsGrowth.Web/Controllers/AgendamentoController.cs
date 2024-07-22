using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly ServicoAgendamento _servicoAgendamento;

        public AgendamentoController(ServicoAgendamento servicoAgendamento)
        {
            _servicoAgendamento = servicoAgendamento;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroAgendamento filtro)
        {
            return Ok(_servicoAgendamento.ObterTodos(filtro));
        }

        [HttpGet("{id}")]
        public IActionResult ObtertPorId(int id)
        {
            return Ok(_servicoAgendamento.ObterPorId(id));
        }

        [HttpPut]
        public IActionResult Adicionar([FromBody] Agendamento agendamento)
        {
            _servicoAgendamento.Adicionar(agendamento);
            return Ok();
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