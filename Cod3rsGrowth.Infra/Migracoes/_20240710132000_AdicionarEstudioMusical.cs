using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migracoes
{
    [Migration(20240710132000)]
    public class _20240710132000_AdicionarEstudioMusical : Migration
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