using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class ServicoEstudioMusical : IServicoEstudioMusical
    {
        public List<EstudioMusical> ObterTodos()
        {
            var estudioMusical = new List<EstudioMusical>
            {
                new EstudioMusical { Id = 32, NomeEstudio = "Sonzeira", EstaAberto = false },
                new EstudioMusical { Id = 23, NomeEstudio = "MUSIK", EstaAberto = true }
            };
            return estudioMusical;
        }
    }
}
