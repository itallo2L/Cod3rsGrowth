using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240701123700)]
    public class _20240701123700_FormatandoOValorTotalDoAgendamento : Migration
    {
        public override void Up()
        {
            Alter.Table("Agendamento")
                .AlterColumn("ValorTotal").AsDecimal(6, 2).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Agendamento");
        }
    }
}