using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);

            RepositorioRevista repositorioRevista = new RepositorioRevista();
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, telaCaixa);

            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo(telaAmigo);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(
                repositorioEmprestimo,
                telaRevista,
                telaAmigo
            );

            bool continuar = true;
            string[] opcoes =
            {
            "Bem Vindo ao Clube da Leitura!",
            "0-Sair",
            "1-Cadastrar Caixa",
            "2-Cadastrar Revista",
            "3-Cadastrar Amigo",
            "4-Cadastrar Empréstimo"
        };
            while (continuar)
            {
                MostrarMenu(opcoes);
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        continuar = false;
                        break;
                    case "1":
                        telaCaixa.Opcoes();
                        break;
                    case "2":
                        telaRevista.Opcoes();
                        break;
                    case "3":
                        telaAmigo.Opcoes();
                        break;
                    case "4":
                        telaEmprestimo.Opcoes();
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        continue;
                }
            }
        }

        static void MostrarMenu(string[] menu)
        {
            Console.Clear();
            foreach (string opcao in menu)
            {
                Console.WriteLine(opcao);
            }

            Console.Write("Digite a opção desejada: ");
        }
    }
}