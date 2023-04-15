using ClubeDaLeitura.ModuloCompartilhado;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloRevista
{
    public class RepositorioRevista : Repositorio
    {
        public void InserirRevista(Revista revista)
        {
            Lista.Add(revista);
        }

        public void EditarRevista(Caixa caixa, string colecao, int numero, int ano, int id)
        {
            Revista revista = EncontrarRevista(id);
            revista.CaixaRevista = caixa;
            revista.Colecao = colecao;
            revista.Numero = numero;
            revista.Ano = ano;
        }

        public Revista EncontrarRevista(int id)
        {
            foreach (Revista revista in Lista)
            {
                if (revista.Id == id)
                {
                    return revista;
                }
            }

            return null;
        }

        public void RemoverRevista(Revista revista)
        {
            Lista.Remove(revista);
        }
    }
}
