using FluentMigrator;
using FluentMigrator.SqlServer;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240626080000)]
    public class _20240626080000_AdicionarAgendamento : Migration
    {
        public override void Up()
        {
            Create.Table("Agendamento")
                .WithColumn("ID").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome do Responsável").AsString().NotNullable()
                .WithColumn("CPF do Responsável").AsString().NotNullable()
                .WithColumn("Data e hora de entrada").AsDateTime().NotNullable()
                .WithColumn("Data e hora de saída").AsDateTime().NotNullable()
                .WithColumn("Valor Total").AsDecimal().NotNullable()
                .WithColumn("Estilo Musical").AsInt32()
                .WithColumn("ID Estudio Musical").AsInt64().ForeignKey();
        }

        public override void Down()
        {
            Delete.Table("Agendamento");
        }
    }
}