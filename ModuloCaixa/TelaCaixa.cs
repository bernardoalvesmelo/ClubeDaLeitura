using ClubeDaLeitura.ModuloCompartilhado;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class TelaCaixa : Tela
    {
        private RepositorioCaixa repositorioCaixa;
        public int QuantidadeCaixas
        {
            get { return repositorioCaixa.Lista.Count; }
        }

        public TelaCaixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }

        public void Opcoes()
        {
            string[] opcoes =
            {
            "Tela Caixa",
            "0-Sair",
            "1-Registrar Caixa",
            "2-Mostrar Caixas",
            "3-Atualizar Caixas",
            "4-Remover Caixa"
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
                        repositorioCaixa.InserirCaixa(RegistrarCaixa());
                        Console.WriteLine("Caixa registrada!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarCaixas();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorioCaixa.Lista.Count > 0)
                        {
                            AtualizarCaixa();
                            Console.WriteLine("Caixa atualizada!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe caixas registradas no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (repositorioCaixa.Lista.Count > 0)
                        {
                            RemoverCaixa();
                            Console.WriteLine("Caixa removida!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe caixas registradas no sistema!");
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

        public Caixa RegistrarCaixa()
        {
            Caixa caixa = new Caixa();
            PreencherAtributos(caixa);
            return caixa;
        }

        public void MostrarCaixas()
        {
            Console.Clear();
            string cabecalho = "";
            cabecalho += ("Id: ".PadRight(20) + "|");
            cabecalho += ("Etiqueta: ".PadRight(20) + "|");
            cabecalho += ("Cor: ".PadRight(20) + "|");
            Console.WriteLine(cabecalho);
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (Caixa caixa in repositorioCaixa.Lista)
            {
                Console.Write((caixa.Id + "").PadRight(20) + "|");
                Console.Write(caixa.Etiqueta.PadRight(20) + "|");
                Console.WriteLine(caixa.Cor.PadRight(20) + "|");
            }
        }

        public void AtualizarCaixa()
        {
            Caixa caixa = ValidarId();
            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();
            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();
            repositorioCaixa.EditarCaixa(cor, etiqueta, caixa.Id);
        }

        public void PreencherAtributos(Caixa caixa)
        {
            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();
            caixa.Cor = cor;
            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();
            caixa.Etiqueta = etiqueta;
        }

        public void RemoverCaixa()
        {
            Caixa caixa = ValidarId();
            repositorioCaixa.RemoverCaixa(caixa);
        }

        public Caixa ValidarId()
        {
            Caixa caixa;
            while (true)
            {
                MostrarCaixas();
                int indice = ValidarInt("Digite o id da caixa: ");
                caixa = repositorioCaixa.EncontrarCaixa(indice);
                if (caixa == null)
                {
                    Console.WriteLine("O id escolhido não existe!");
                    Console.ReadLine();
                    continue;
                }
                return caixa;
            }
        }
    }
}
