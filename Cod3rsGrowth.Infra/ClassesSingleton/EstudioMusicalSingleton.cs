using Cod3rsGrowth.Dominio.Entidades;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Singleton
{
    public sealed class EstudioMusicalSingleton : List<EstudioMusical>
    {
        private EstudioMusicalSingleton() { }
        private static EstudioMusicalSingleton? _instanciaEstudioMusical;
        public static EstudioMusicalSingleton InstanciaEstudioMusical
        {
           get
            {
                    lock (typeof(EstudioMusicalSingleton))
                    {
                        if (_instanciaEstudioMusical == null)
                        {
                            _instanciaEstudioMusical = new EstudioMusicalSingleton();
                        }
                    }
                return _instanciaEstudioMusical;
            }
        }
    }
}