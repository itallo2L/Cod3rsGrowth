using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(2024062513180)]
    internal class _20240625131800_AdicionarEstudioMusical : Migration
    {
        public override void Up()
        {
            Create.Table("Estudio Musical")
                .WithColumn("ID").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable();
                //.WithColumn("Esta Aberto".AsBoolean();
        }

        public override void Down()
        {
            Delete.Table("Estudio Musical");
        }
    }
}