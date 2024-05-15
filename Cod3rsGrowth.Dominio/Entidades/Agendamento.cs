using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Agendamento
    {
        //Declarando as propriedades da classe
        public int Id { get; set; }
        public string NomeResponsavelDoAgendamento { get; set; }
        public string CpfResponsavelDoAgendamento { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeOnly HorasDoAluguel { get; set; }
        public decimal ValorTotal { get; set; }
        public EstiloMusical EstiloMusical { get; set; }
        public int EstudioId { get; set; }
    }
}
