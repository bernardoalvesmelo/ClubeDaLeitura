using ClubeDaLeitura.ModuloCompartilhado;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class Caixa : Entidade
    {
        static private int id = 0;

        public string Cor { get; set; }
        public string Etiqueta { get; set; }

        public Caixa()
        {
            obterId(ref id);
        }
    }
}