using ClubeDaLeitura.ModuloCompartilhado;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloRevista
{
    public class Revista : Entidade
    {
        static private int id = 0;

        public string Colecao { get; set; }
        public int Numero { get; set; }
        public int Ano { get; set; }
        public Caixa CaixaRevista { get; set; }

        public Revista()
        {
            obterId(ref id);
        }
    }
}
