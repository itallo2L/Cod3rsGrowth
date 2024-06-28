using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using System;

namespace Cod3rsGrowth.Dominio.Filtros
{
    public class FiltroAgendamento
    {
        public string? NomeResponsavel { get; set; }
        public DateTime? DataEHoraDeEntrada { get; set; }
        public decimal? ValorTotal { get; set; }
        public EstiloMusical EstiloMusical { get; set; }
    }
}