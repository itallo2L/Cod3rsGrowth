using LinqToDB;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioDeletarEstudioDeTeste
    {
        public static void DeletarEstudioAdicionadoEmTeste(BdCod3rsGrowth bancoDeDadosTestes)
        {
            const string estudioASerDeletado = "Estudio Vinte e Seis";

            bancoDeDadosTestes.EstudioMusical
                .Delete(estudio => estudio.Nome == estudioASerDeletado);
        }
    }
}