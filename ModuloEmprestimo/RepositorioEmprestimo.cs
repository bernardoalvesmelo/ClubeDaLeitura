using System.Collections;

using ClubeDaLeitura.ModuloCompartilhado;
using ClubeDaLeitura.ModuloAmigo;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class RepositorioEmprestimo : Repositorio
    {
        public ArrayList EmprestimosDevolvidosLista { get; private set; }
        public ArrayList AmigosLista { get; private set; }

        private TelaAmigo telaAmigo;

        public RepositorioEmprestimo(TelaAmigo telaAmigo)
        {
            this.telaAmigo = telaAmigo;
            EmprestimosDevolvidosLista = new ArrayList();
            AmigosLista = new ArrayList();
        }

        public void InserirEmprestimo(Emprestimo emprestimo)
        {
            Lista.Add(emprestimo);
            AmigosLista.Add(emprestimo.AmigoEmprestimo);
        }

        public void AtualizarDevolucao(DateTime data, int id)
        {
            Emprestimo emprestimo = EncontrarEmprestimoAberto(id);
            EmprestimosDevolvidosLista.Add(emprestimo);
            AmigosLista.Remove(emprestimo.AmigoEmprestimo);
            Lista.Remove(emprestimo);
            emprestimo.DataDevolucao = data;
        }

        public void RemoverEmprestimoAberto(Emprestimo emprestimo)
        {
            Lista.Remove(emprestimo);
            AmigosLista.Remove(emprestimo.AmigoEmprestimo);
        }

        public void RemoverEmprestimoDevolvido(Emprestimo emprestimo)
        {
            EmprestimosDevolvidosLista.Remove(emprestimo);
        }

        public Emprestimo EncontrarEmprestimoAberto(int id)
        {
            foreach (Emprestimo emprestimo in Lista)
            {
                if (emprestimo.Id == id)
                {
                    return emprestimo;
                }
            }

            return null;
        }

        public Emprestimo EncontrarEmprestimoDevolvido(int id)
        {
            foreach (Emprestimo emprestimo in EmprestimosDevolvidosLista)
            {
                if (emprestimo.Id == id)
                {
                    return emprestimo;
                }
            }

            return null;
        }

        public Amigo EncontrarAmigo(int id)
        {
            foreach (Amigo amigo in telaAmigo.ObterAmigosDisponiveis(AmigosLista))
            {
                if (amigo.Id == id)
                {
                    return amigo;
                }
            }

            return null;
        }
    }
}