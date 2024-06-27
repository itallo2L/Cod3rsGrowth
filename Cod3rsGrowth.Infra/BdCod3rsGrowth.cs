using Cod3rsGrowth.Dominio.Entidades;
using LinqToDB;

namespace Cod3rsGrowth.Infra
{
    public class BdCod3rsGrowth : LinqToDB.Data.DataConnection
    {
        public BdCod3rsGrowth(DataOptions<BdCod3rsGrowth> options) : base (options.Options) { }
        public ITable<Agendamento> Agendamento => this.GetTable<Agendamento>();
        public ITable<EstudioMusical> EstudioMusical => this.GetTable<EstudioMusical>();
    }
}