using System.Collections;

using ClubeDaLeitura.ModuloCompartilhado;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class TelaAmigo : Tela
    {
        private RepositorioAmigo repositorioAmigo;
        public int QuantidadeAmigos
        {
            get { return repositorioAmigo.Lista.Count; }
        }

        public TelaAmigo(RepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Amigo",
            "0-Sair",
            "1-Registrar Amigo",
            "2-Mostrar Amigos",
            "3-Atualizar Amigos",
            "4-Remover Amigo"
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
                        repositorioAmigo.InserirAmigo(RegistrarAmigo());
                        Console.WriteLine("Amigo registrado!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarAmigos();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorioAmigo.Lista.Count > 0)
                        {
                            AtualizarAmigo();
                            Console.WriteLine("Amigo atualizado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe amigos registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorioAmigo.Lista.Count > 0)
                        {
                            RemoverAmigo();
                            Console.WriteLine("Amigo removido!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe amigos registrados no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public ArrayList ObterAmigosDisponiveis(ArrayList amigosIndisponiveis)
        {
            ArrayList amigosDisponiveis = new ArrayList();
            foreach (Amigo amigo in repositorioAmigo.Lista)
            {
                if (amigosIndisponiveis.Contains(amigo))
                {
                    continue;
                }
                amigosDisponiveis.Add(amigo);
            }
            return amigosDisponiveis;
        }

        public Amigo RegistrarAmigo()
        {
            Amigo amigo = new Amigo();
            PreencherAtributos(amigo);
            return amigo;
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
            foreach (Amigo amigo in repositorioAmigo.Lista)
            {
                Console.Write((amigo.Id + "").PadRight(20) + "|");
                Console.Write(amigo.Nome.PadRight(20) + "|");
                Console.Write(amigo.Responsavel.PadRight(20) + "|");
                Console.Write(amigo.Telefone.PadRight(20) + "|");
                Console.WriteLine(amigo.Endereco.PadRight(20) + "|");
            }
        }

        public void AtualizarAmigo()
        {
            Amigo amigo = ValidarId();
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o responsável do amigo: ");
            string responsavel = Console.ReadLine();
            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();
            Console.Write("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();
            repositorioAmigo.EditarAmigo(nome, responsavel, telefone, endereco, amigo.Id);
        }

        public void PreencherAtributos(Amigo amigo)
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();
            amigo.Nome = nome;
            Console.Write("Digite o responsável do amigo: ");
            string responsavel = Console.ReadLine();
            amigo.Responsavel = responsavel;
            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();
            amigo.Telefone = telefone;
            Console.Write("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();
            amigo.Endereco = endereco;
        }

        public void RemoverAmigo()
        {
            Amigo amigo = ValidarId();
            repositorioAmigo.RemoverAmigo(amigo);
        }

        public Amigo ValidarId()
        {
            Amigo amigo;
            while (true)
            {
                MostrarAmigos();
                int indice = ValidarInt("Digite o id do amigo: ");
                amigo = repositorioAmigo.EncontrarAmigo(indice);
                if (amigo == null)
                {
                    Console.WriteLine("O id escolhido não existe!");
                    Console.ReadLine();
                    continue;
                }
                return amigo;
            }
        }
    }
}
