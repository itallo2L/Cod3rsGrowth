using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240626091000)]
    public class _20240626091000_AdicionarEstudioMusical : Migration
    {
        public override void Up()
        {
            Create.Table("Estudio Musical")
                .WithColumn("ID").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Esta Aberto").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Estudio Musical");
        }
    }
}