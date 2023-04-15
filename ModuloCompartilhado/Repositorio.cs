using System.Collections;

namespace ClubeDaLeitura.ModuloCompartilhado
{
    public class Repositorio
    {
        public ArrayList Lista { get; protected set; }

        public Repositorio()
        {
            Lista = new ArrayList();
        }

    }
}
