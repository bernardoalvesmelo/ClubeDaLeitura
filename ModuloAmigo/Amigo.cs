using ClubeDaLeitura.ModuloCompartilhado;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class Amigo : Entidade
    {
        static private int id = 0;

        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Amigo()
        {
            obterId(ref id);
        }
    }
}
