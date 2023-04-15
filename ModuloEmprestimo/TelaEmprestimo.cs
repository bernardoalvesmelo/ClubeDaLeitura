using System.Globalization;

using ClubeDaLeitura.ModuloCompartilhado;
using ClubeDaLeitura.ModuloRevista;
using ClubeDaLeitura.ModuloAmigo;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class TelaEmprestimo : Tela
    {
        RepositorioEmprestimo repositorioEmprestimo;
        TelaRevista telaRevista;
        TelaAmigo telaAmigo;
        public int QuantidadeEmprestimosAbertos
        {
            get { return repositorioEmprestimo.Lista.Count; }
        }

        public TelaEmprestimo(
            RepositorioEmprestimo repositorioEmprestimo,
            TelaRevista telaRevista,
            TelaAmigo telaAmigo
        )
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.telaRevista = telaRevista;
            this.telaAmigo = telaAmigo;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Empréstimo",
            "0-Sair",
            "1-Registrar Empréstimo",
            "2-Mostrar Empréstimos",
            "3-Realizar Devolução",
            "4-Remover Empréstimo Aberto",
            "5-Remover Empréstimo Devolvido",
            "6-Mostrar Empréstimos Abertos",
            "7-Mostrar Empréstimos Mensais"
        };
            while (true)
            {
                MostrarMenu(opcoes);
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        return;
                    case "1":
                        if (telaRevista.QuantidadeRevistas > 0)
                        {
                            if (
                                telaAmigo
                                    .ObterAmigosDisponiveis(repositorioEmprestimo.AmigosLista)
                                    .Count > 0
                            )
                            {
                                repositorioEmprestimo.InserirEmprestimo(RegistrarEmprestimo());
                                Console.WriteLine("Empréstimo registrado!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Não existe amigos disponíveis no sistema!");
                                Console.ReadLine();
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Não existe revistas registradas no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        MostrarEmprestimos();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorioEmprestimo.Lista.Count > 0)
                        {
                            RealizarDevolucao();
                            Console.WriteLine("Devolução concluída!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe empréstimos em aberto no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorioEmprestimo.Lista.Count > 0)
                        {
                            RemoverEmprestimoAberto();
                            Console.WriteLine("Remoção concluída!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe empréstimos em aberto no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        if (repositorioEmprestimo.EmprestimosDevolvidosLista.Count > 0)
                        {
                            RemoverEmprestimoDevolvido();
                            Console.WriteLine("Remoção concluída!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe empréstimos delvovidos no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "6":
                        MostrarEmprestimosEmAberto();
                        Console.ReadLine();
                        break;
                    case "7":
                        MostrarEmprestimosMensais();
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public Emprestimo RegistrarEmprestimo()
        {
            Emprestimo emprestimo = new Emprestimo();
            PreencherAtributos(emprestimo);
            return emprestimo;
        }

        public void MostrarEmprestimosDevolvidos()
        {
            Console.Clear();
            string cabecalho = "";
            cabecalho += ("Id: ".PadRight(20) + "|");
            cabecalho += ("Amigo: ".PadRight(20) + "|");
            cabecalho += ("Revista: ".PadRight(20) + "|");
            cabecalho += ("Data de Abertura: ".PadRight(20) + "|");
            cabecalho += ("Data de Devolução: ".PadRight(20) + "|");
            Console.WriteLine(cabecalho);
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Emprestimo emprestimo in repositorioEmprestimo.EmprestimosDevolvidosLista)
            {
                Console.Write((emprestimo.Id + "").PadRight(20) + "|");
                Console.Write(emprestimo.AmigoEmprestimo.Nome.PadRight(20) + "|");
                Console.Write(emprestimo.RevistaEmprestimo.Colecao.PadRight(20) + "|");
                Console.Write(emprestimo.Data.ToString("dd/MM/yyyy").PadRight(20) + "|");
                Console.WriteLine(emprestimo.DataDevolucao.ToString("dd/MM/yyyy").PadRight(20) + "|");
            }
        }

        public void MostrarEmprestimos()
        {
            Console.Clear();
            string cabecalho = "";
            cabecalho += ("Id: ".PadRight(20) + "|");
            cabecalho += ("Amigo: ".PadRight(20) + "|");
            cabecalho += ("Revista: ".PadRight(20) + "|");
            cabecalho += ("Data de Abertura: ".PadRight(20) + "|");
            cabecalho += ("Data de Devolução: ".PadRight(20) + "|");
            Console.WriteLine(cabecalho);
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Emprestimo emprestimo in repositorioEmprestimo.Lista)
            {
                Console.Write((emprestimo.Id + "").PadRight(20) + "|");
                Console.Write(emprestimo.AmigoEmprestimo.Nome.PadRight(20) + "|");
                Console.Write(emprestimo.RevistaEmprestimo.Colecao.PadRight(20) + "|");
                Console.Write(emprestimo.Data.ToString("dd/MM/yyyy").PadRight(20) + "|");
                Console.WriteLine("Em aberto".PadRight(20) + "|");
            }
            foreach (Emprestimo emprestimo in repositorioEmprestimo.EmprestimosDevolvidosLista)
            {
                Console.Write((emprestimo.Id + "").PadRight(20) + "|");
                Console.Write(emprestimo.AmigoEmprestimo.Nome.PadRight(20) + "|");
                Console.Write(emprestimo.RevistaEmprestimo.Colecao.PadRight(20) + "|");
                Console.Write(emprestimo.Data.ToString("dd/MM/yyyy").PadRight(20) + "|");
                Console.WriteLine(emprestimo.DataDevolucao.ToString("dd/MM/yyyy").PadRight(20) + "|");
            }
        }

        public void MostrarEmprestimosEmAberto()
        {
            Console.Clear();
            string cabecalho = "";
            cabecalho += ("Id: ".PadRight(20) + "|");
            cabecalho += ("Amigo: ".PadRight(20) + "|");
            cabecalho += ("Revista: ".PadRight(20) + "|");
            cabecalho += ("Data de Abertura: ".PadRight(20) + "|");
            cabecalho += ("Data de Devolução: ".PadRight(20) + "|");
            Console.WriteLine(cabecalho);
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Emprestimo emprestimo in repositorioEmprestimo.Lista)
            {
                Console.Write((emprestimo.Id + "").PadRight(20) + "|");
                Console.Write(emprestimo.AmigoEmprestimo.Nome.PadRight(20) + "|");
                Console.Write(emprestimo.RevistaEmprestimo.Colecao.PadRight(20) + "|");
                Console.Write(emprestimo.Data.ToString("dd/MM/yyyy").PadRight(20) + "|");
                Console.WriteLine("Em aberto".PadRight(20) + "|");
            }
        }

        public void MostrarEmprestimosMensais()
        {
            Console.Clear();
            string cabecalho = "";
            cabecalho += ("Id: ".PadRight(20) + "|");
            cabecalho += ("Amigo: ".PadRight(20) + "|");
            cabecalho += ("Revista: ".PadRight(20) + "|");
            cabecalho += ("Data de Abertura: ".PadRight(20) + "|");
            cabecalho += ("Data de Devolução: ".PadRight(20) + "|");
            Console.WriteLine(cabecalho);
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Emprestimo emprestimo in repositorioEmprestimo.Lista)
            {
                if (
                    DateTime.Now.Month == emprestimo.Data.Month
                    && DateTime.Now.Year == emprestimo.Data.Year
                )
                {
                    Console.Write((emprestimo.Id + "").PadRight(20) + "|");
                    Console.Write(emprestimo.AmigoEmprestimo.Nome.PadRight(20) + "|");
                    Console.Write(emprestimo.RevistaEmprestimo.Colecao.PadRight(20) + "|");
                    Console.Write(emprestimo.Data.ToString("dd/MM/yyyy").PadRight(20) + "|");
                    Console.WriteLine("Em aberto".PadRight(20) + "|");
                }
            }
            foreach (Emprestimo emprestimo in repositorioEmprestimo.EmprestimosDevolvidosLista)
            {
                if (
                    DateTime.Now.Month == emprestimo.Data.Month
                    && DateTime.Now.Year == emprestimo.Data.Year
                )
                {
                    Console.Write((emprestimo.Id + "").PadRight(20) + "|");
                    Console.Write(emprestimo.AmigoEmprestimo.Nome.PadRight(20) + "|");
                    Console.Write(emprestimo.RevistaEmprestimo.Colecao.PadRight(20) + "|");
                    Console.Write(emprestimo.Data.ToString("dd/MM/yyyy").PadRight(20) + "|");
                    Console.WriteLine(
                        emprestimo.DataDevolucao.ToString("dd/MM/yyyy").PadRight(20) + "|"
                    );
                }
            }
        }

        public void RealizarDevolucao()
        {
            DateTime data;
            if (
                DateTime.TryParseExact(
                    DateTime.Now.ToString("dd/MM/yyyy"),
                    "dd/MM/yyyy",
                    new CultureInfo("pt-BR"),
                    DateTimeStyles.None,
                    out data
                )
            )
            {
                Emprestimo emprestimo = ValidarIdAbertos();
                repositorioEmprestimo.AtualizarDevolucao(data, emprestimo.Id);
            }
            else
            {
                Console.WriteLine("Não é possível realizar devoluções no momento!");
                Console.ReadLine();
            }
        }

        public void RemoverEmprestimoAberto()
        {
            Emprestimo emprestimo = ValidarIdAbertos();
            repositorioEmprestimo.RemoverEmprestimoAberto(emprestimo);
        }

        public void RemoverEmprestimoDevolvido()
        {
            Emprestimo emprestimo = ValidarIdDevolvidos();
            repositorioEmprestimo.RemoverEmprestimoDevolvido(emprestimo);
        }

        public void PreencherAtributos(Emprestimo emprestimo)
        {
            Amigo amigo = ValidarIdAmigo();
            emprestimo.AmigoEmprestimo = amigo;
            Revista revista = telaRevista.ValidarId();
            emprestimo.RevistaEmprestimo = revista;
            emprestimo.Data = ValidarData("Digite a data do empréstimo: ");
        }

        private Emprestimo ValidarIdAbertos()
        {
            Emprestimo emprestimo;
            while (true)
            {
                MostrarEmprestimosEmAberto();
                int indice = ValidarInt("Digite o id do empréstimo: ");
                emprestimo = repositorioEmprestimo.EncontrarEmprestimoAberto(indice);
                if (emprestimo == null)
                {
                    Console.WriteLine("O id escolhido não está disponível!");
                    Console.ReadLine();
                    continue;
                }
                return emprestimo;
            }
        }

        private Emprestimo ValidarIdDevolvidos()
        {
            Emprestimo emprestimo;
            while (true)
            {
                MostrarEmprestimosDevolvidos();
                int indice = ValidarInt("Digite o id do empréstimo: ");
                emprestimo = repositorioEmprestimo.EncontrarEmprestimoDevolvido(indice);
                if (emprestimo == null)
                {
                    Console.WriteLine("O id escolhido não está disponível!");
                    Console.ReadLine();
                    continue;
                }
                return emprestimo;
            }
        }

        public void MostrarAmigos()
        {
            Console.Clear();
            string cabecalho = "";
            cabecalho += ("Id: ".PadRight(20) + "|");
            cabecalho += ("Nome: ".PadRight(20) + "|");
            cabecalho += ("Responsavel: ".PadRight(20) + "|");
            cabecalho += ("Telefone: ".PadRight(20) + "|");
            cabecalho += ("Endereço: ".PadRight(20) + "|");
            Console.WriteLine(cabecalho);
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Amigo amigo in telaAmigo.ObterAmigosDisponiveis(repositorioEmprestimo.AmigosLista))
            {
                Console.Write((amigo.Id + "").PadRight(20) + "|");
                Console.Write(amigo.Nome.PadRight(20) + "|");
                Console.Write(amigo.Responsavel.PadRight(20) + "|");
                Console.Write(amigo.Telefone.PadRight(20) + "|");
                Console.WriteLine(amigo.Endereco.PadRight(20) + "|");
            }
        }

        public Amigo ValidarIdAmigo()
        {
            Amigo amigo;
            while (true)
            {
                MostrarAmigos();
                int indice = ValidarInt("Digite o id da amigo: ");
                amigo = repositorioEmprestimo.EncontrarAmigo(indice);
                if (amigo == null)
                {
                    Console.WriteLine("O id escolhido não está disponível!");
                    Console.ReadLine();
                    continue;
                }
                return amigo;
            }
        }
    }
}
