
namespace Ex03
{
    class Program03
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n------------------------");
                Console.WriteLine("      CALCULADORA     ");
                Console.WriteLine("------------------------\n");

                // ---------VERIFICAÇÃO DE ENTRADA DE DADOS---------

                // verifica se o primeiro número é inteiro
                Console.WriteLine("Digite o primeiro número:");
                if (!int.TryParse(Console.ReadLine(), out int num1))
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                    continue;
                }

                // verifica se o segundo número é inteiro
                Console.WriteLine("Digite o segundo número:");
                if (!int.TryParse(Console.ReadLine(), out int num2))
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                    continue;
                }
                //--------------------------------------------------

                // ---------ESCOLHA DA OPERAÇÃO---------
                Console.WriteLine("Escolha a operação");
                Console.WriteLine("1 - Soma");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("0 - Sair\n");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine($"A soma de {num1} + {num2} é {num1 + num2}");
                        break;
                    case "2":
                        Console.WriteLine($"A subtração de {num1} - {num2} é {num1 - num2}");
                        break;
                    case "3":
                        Console.WriteLine($"A multiplicação de {num1} * {num2} é {num1 * num2}");
                        break;
                    case "4":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Não é possível dividir por zero.");
                        }
                        else
                        {
                            Console.WriteLine($"A divisão de {num1} / {num2} é {num1 / num2}");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                // --------------------------------------------------

                // Verificação de continuação do programa
                Console.WriteLine("Deseja realizar uma outra operação? (S / N)");
                string continuar = Console.ReadLine().ToUpper();

                if (continuar != "S")
                {
                    Console.WriteLine("Fechando a calculadora...");
                    break;
                }
            }
        }
    }
}
