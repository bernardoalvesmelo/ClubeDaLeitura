using ClubeDaLeitura.ModuloCompartilhado;
using ClubeDaLeitura.ModuloRevista;
using ClubeDaLeitura.ModuloAmigo;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class Emprestimo : Entidade
    {
        static private int id = 0;

        public Amigo AmigoEmprestimo { get; set; }
        public Revista RevistaEmprestimo { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo()
        {
            obterId(ref id);
        }
    }
}
