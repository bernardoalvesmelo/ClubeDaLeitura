using System.Globalization;

namespace ClubeDaLeitura.ModuloCompartilhado
{
    public class Tela
    {
        public void MostrarMenu(string[] menu)
        {
            Console.Clear();
            foreach (string opcao in menu)
            {
                Console.WriteLine(opcao);
            }

            Console.Write("Digite a opção desejada: ");
        }

        protected int ValidarInt(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string valor = Console.ReadLine();
                int numero;
                if (Int32.TryParse(valor, out numero))
                {
                    return numero;
                }
                Console.WriteLine("Digite apenas um número inteiro!");
                Console.ReadLine();
            }
        }

        protected DateTime ValidarData(string mensagem)
        {
            DateTime data;
            while (true)
            {
                Console.Write(mensagem);
                string dataInput = Console.ReadLine();
                if (
                    DateTime.TryParseExact(
                        dataInput,
                        "dd/MM/yyyy",
                        new CultureInfo("pt-BR"),
                        DateTimeStyles.None,
                        out data
                    )
                )
                {
                    return data;
                }
                else
                {
                    Console.WriteLine("Digite a data no formato dd/mm/yyyy!");
                    Console.ReadLine();
                }
            }
        }
    }
}
