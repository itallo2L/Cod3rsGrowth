using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(20240705102200)]
    public class _20240705102200_AdicionarAgendamento : Migration
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
                .WithColumn("IdEstudio").AsInt64().ForeignKey();
        }

        public override void Down()
        {
            Delete.Table("Agendamento");
        }
    }
}