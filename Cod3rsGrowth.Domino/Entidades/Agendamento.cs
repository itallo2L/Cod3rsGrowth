using Cod3rsGrowth.Dominio.EnumEstiloMusical;
using System;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string? NomeResponsavel { get; set; }
        public string? CpfResponsavel { get; set; }
        public DateTime DataEHoraDeEntrada { get; set; }
        public DateTime DataEHoraDeSaida { get; set; }
        public decimal ValorTotal { get; set; }
        public EstiloMusical EstiloMusical { get; set; }
        public int IdEstudio { get; set; }
    }
}
