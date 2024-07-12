using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(20240710132200)]
    public class _20240710132200_AdicionarAgendamento : Migration
    {
        public override void Up()
        {
            Create.Table("Agendamento")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("NomeResponsavel").AsString().NotNullable()
                .WithColumn("CpfResponsavel").AsString().NotNullable()
                .WithColumn("DataEHoraDeEntrada").AsDateTime().NotNullable()
                .WithColumn("DataEHoraDeSaida").AsDateTime().NotNullable()
                .WithColumn("ValorTotal").AsDecimal().NotNullable()
                .WithColumn("EstiloMusical").AsInt32()
                .WithColumn("IdEstudio").AsInt64().ForeignKey("EstudioMusical", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Agendamento");
        }
    }
}