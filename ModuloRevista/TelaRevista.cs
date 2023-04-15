
using ClubeDaLeitura.ModuloCompartilhado;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloRevista
{
    public class TelaRevista : Tela
    {
        private RepositorioRevista repositorioRevista;
        private TelaCaixa telaCaixa;
        public int QuantidadeRevistas
        {
            get { return repositorioRevista.Lista.Count; }
        }

        public TelaRevista(RepositorioRevista repositorioRevista, TelaCaixa telaCaixa)
        {
            this.repositorioRevista = repositorioRevista;
            this.telaCaixa = telaCaixa;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Revista",
            "0-Sair",
            "1-Registrar Revista",
            "2-Mostrar Revistas",
            "3-Atualizar Revistas",
            "4-Remover Revista"
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
                        if (telaCaixa.QuantidadeCaixas > 0)
                        {
                            repositorioRevista.InserirRevista(RegistrarRevista());
                            Console.WriteLine("Revista registrada!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe caixas registradas no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        MostrarRevistas();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorioRevista.Lista.Count > 0)
                        {
                            if (telaCaixa.QuantidadeCaixas > 0)
                            {
                                AtualizarRevista();
                                Console.WriteLine("Revista atualizada!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Não existe caixas registradas no sistema!");
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
                    case "4":
                        if (repositorioRevista.Lista.Count > 0)
                        {
                            RemoverRevista();
                            Console.WriteLine("Revista removida!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe revistas registradas no sistema!");
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

        public Revista RegistrarRevista()
        {
            Revista revista = new Revista();
            PreencherAtributos(revista);
            return revista;
        }

        public void MostrarRevistas()
        {
            Console.Clear();
            string cabecalho = "";
            cabecalho += ("Id: ".PadRight(20) + "|");
            cabecalho += ("Coleção: ".PadRight(20) + "|");
            cabecalho += ("Edição: ".PadRight(20) + "|");
            cabecalho += ("Ano: ".PadRight(20) + "|");
            cabecalho += ("Caixa: ".PadRight(20) + "|");
            Console.WriteLine(cabecalho);
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Revista revista in repositorioRevista.Lista)
            {
                Console.Write((revista.Id + "").PadRight(20) + "|");
                Console.Write(revista.Colecao.PadRight(20) + "|");
                Console.Write((revista.Numero + "").PadRight(20) + "|");
                Console.Write((revista.Ano + "").PadRight(20) + "|");
                Console.WriteLine(revista.CaixaRevista.Etiqueta.PadRight(20) + "|");
            }
        }

        public void AtualizarRevista()
        {
            Revista revista = ValidarId();
            Caixa caixa = telaCaixa.ValidarId();
            Console.Write("Digite a coleção da revista: ");
            string colecao = Console.ReadLine();
            int numero = ValidarInt("Digite o número da edição da revista: ");
            int ano = ValidarInt("Digite o ano da revista: ");
            repositorioRevista.EditarRevista(caixa, colecao, numero, ano, revista.Id);
        }

        public void PreencherAtributos(Revista revista)
        {
            Caixa caixa = telaCaixa.ValidarId();
            revista.CaixaRevista = caixa;
            Console.Write("Digite a coleção da revista: ");
            string colecao = Console.ReadLine();
            revista.Colecao = colecao;
            int numero = ValidarInt("Digite o número da edição da revista: ");
            int ano = ValidarInt("Digite o ano da revista: ");
            revista.Ano = ano;
        }

        public void RemoverRevista()
        {
            Revista revista = ValidarId();
            repositorioRevista.RemoverRevista(revista);
        }

        public Revista ValidarId()
        {
            Revista revista;
            while (true)
            {
                MostrarRevistas();
                int indice = ValidarInt("Digite o id da revista: ");
                revista = repositorioRevista.EncontrarRevista(indice);
                if (revista == null)
                {
                    Console.WriteLine("O id escolhido não existe!");
                    Console.ReadLine();
                    continue;
                }
                return revista;
            }
        }
    }
}
