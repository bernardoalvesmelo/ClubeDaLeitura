using System.Collections;

using ClubeDaLeitura.ModuloCompartilhado;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class RepositorioCaixa : Repositorio
    {
        public ArrayList Lista { get; private set; }

        public RepositorioCaixa()
        {
            Lista = new ArrayList();
        }

        public void InserirCaixa(Caixa caixa)
        {
            Lista.Add(caixa);
        }

        public void EditarCaixa(string cor, string etiqueta, int id)
        {
            Caixa caixa = EncontrarCaixa(id);
            caixa.Cor = cor;
            caixa.Etiqueta = etiqueta;
        }

        public Caixa EncontrarCaixa(int id)
        {
            foreach (Caixa caixa in Lista)
            {
                if (caixa.Id == id)
                {
                    return caixa;
                }
            }

            return null;
        }

        public void RemoverCaixa(Caixa caixa)
        {
            Lista.Remove(caixa);
        }
    }
}
