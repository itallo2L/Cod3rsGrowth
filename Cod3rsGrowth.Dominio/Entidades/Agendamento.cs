﻿using Cod3rsGrowth.Dominio.EnumEstiloMusical;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string? NomeResponsavelDoAgendamento { get; set; }
        public string? CpfResponsavelDoAgendamento { get; set; }
        public DateTime DataEHoraDeEntrada { get; set; }
        public DateTime DataEHoraDeSaida { get; set; }
        public decimal ValorTotal { get; set; }
        public EstiloMusical EstiloMusical { get; set; }
        public int EstudioId { get; set; }
    }
}