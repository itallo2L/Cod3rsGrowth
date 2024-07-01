using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(202406271241000)]
    public class _20240626091000_AdicionarEstudioMusical : Migration
    {
        public override void Up()
        {
            Create.Table("EstudioMusical")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("EstaAberto").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("EstudioMusical");
        }
    }
}