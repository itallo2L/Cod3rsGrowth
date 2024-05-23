using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Singleton
{
    public sealed class EstudioMusicalSingleton : List<EstudioMusical>
    {
        private EstudioMusicalSingleton() { }
        private static EstudioMusicalSingleton? _instanciaEstudioMusical;
        public List<EstudioMusical> EstudioMusical;
        public static EstudioMusicalSingleton InstanciaEstudioMusical
        {
           get
            {
                if (_instanciaEstudioMusical == null)
                {
                    lock (typeof(EstudioMusicalSingleton))
                    {
                        if (_instanciaEstudioMusical == null)
                        {
                            _instanciaEstudioMusical = new EstudioMusicalSingleton();
                        }
                    }
                }
                return _instanciaEstudioMusical;
            }
        }
    }
}