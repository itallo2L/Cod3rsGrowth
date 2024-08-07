﻿using Cod3rsGrowth.Dominio.Entidades;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Singleton
{
    public sealed class AgendamentoSingleton : List<Agendamento>
    {
        private AgendamentoSingleton() { }
        private static AgendamentoSingleton? _instanciaAgendamento;
        public static AgendamentoSingleton InstanciaAgendamento
        {
            get
            {
                lock (typeof(AgendamentoSingleton))
                {
                    if (_instanciaAgendamento == null)
                        _instanciaAgendamento = new AgendamentoSingleton();
                }
                return _instanciaAgendamento;
            }
        }
    }
}