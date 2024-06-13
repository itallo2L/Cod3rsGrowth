﻿using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacoes
{
    public class ValidadorEstudioMusical : AbstractValidator<EstudioMusical>
    {
        public ValidadorEstudioMusical()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(EstudioMusical => EstudioMusical.Nome)
                .NotEmpty().WithMessage("O campo Nome do Estúdio é obrigatório, por favor insira o nome do estúdio.")
                .MaximumLength(25).WithMessage("O nome do estúdio excedeu o limite de 25 caracteres, digite um nome menor.");

            RuleFor(EstudioMusical => EstudioMusical.EstaAberto)
                .NotNull().WithMessage("Por favor informe se o estúdio está aberto ou não.");
        }
    }
}