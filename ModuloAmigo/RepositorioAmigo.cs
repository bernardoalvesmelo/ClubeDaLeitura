using System.Collections;

using ClubeDaLeitura.ModuloCompartilhado;

namespace ClubeDaLeitura.ModuloAmigo
{

    public class RepositorioAmigo : Repositorio
    {
        public ArrayList Lista { get; private set; }

        public RepositorioAmigo()
        {
            Lista = new ArrayList();
        }

        public void InserirAmigo(Amigo amigo)
        {
            Lista.Add(amigo);
        }

        public void EditarAmigo(
            string nome,
            string responsavel,
            string telefone,
            string endereco,
            int id
        )
        {
            Amigo amigo = EncontrarAmigo(id);
            amigo.Nome = nome;
            amigo.Responsavel = responsavel;
            amigo.Telefone = telefone;
            amigo.Endereco = endereco;
        }

        public Amigo EncontrarAmigo(int id)
        {
            foreach (Amigo amigo in Lista)
            {
                if (amigo.Id == id)
                {
                    return amigo;
                }
            }

            return null;
        }

        public void RemoverAmigo(Amigo amigo)
        {
            Lista.Remove(amigo);
        }
    }
}
