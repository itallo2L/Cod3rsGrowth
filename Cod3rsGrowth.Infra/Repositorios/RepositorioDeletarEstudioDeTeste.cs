using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioDeletarEstudioDeTeste
    {
        public static void DeletarEstudioAdicionadoEmTeste(BdCod3rsGrowth bancoDeDadosTestes)
        {
            const int numeroDeEstudiosEsperado = 30052;
            bancoDeDadosTestes.EstudioMusical
                .Delete(estudio => estudio.Id > numeroDeEstudiosEsperado);
        }
    }
}