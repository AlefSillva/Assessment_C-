using System;

namespace JogoDeAdivinhacao
{
    class Program
    {
        static void Main(string[] args)
        {
            // Gerar um número aleatório entre 1 e 50
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 51);

            //---------------------------------------

            int tentativas = 5;
            int palpite = 0;

            //-----------Início do Jogo--------------
            Console.WriteLine("--------Jogo de Adivinhação--------\n");

            Console.WriteLine("Tente adivinhar o número entre 1 e 50.");
            
            while (tentativas > 0)
            {
                Console.WriteLine($"\nVocê tem {tentativas} tentativas restantes.");
                Console.Write("\nDigite seu palpite: ");


                // validação das entradas
                try
                {
                    palpite = int.Parse(Console.ReadLine());

                    if (palpite < 1 || palpite > 50)
                    {
                        Console.WriteLine("Erro: O número deve estar entre 1 e 50.");
                        continue; 
                    }

                    // Verificar se o palpite está correto
                    if (palpite == numeroAleatorio)
                    {
                        Console.WriteLine("Parabéns! Você adivinhou o número!");
                        break; 
                    }
                    else if (palpite < numeroAleatorio)
                    {
                        Console.WriteLine("O número é maior. Tente novamente.");
                    }
                    else
                    {
                        Console.WriteLine("O número é menor. Tente novamente.");
                    }

                    tentativas--;

                    // Fim do jogo por falta de tentativas restantes. Mostrando número aleatório
                    if (tentativas == 0)
                    {
                        Console.WriteLine($"\nVocê perdeu! O número era {numeroAleatorio}.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Digite um número válido.");
                }
            }

            //----------------Fim do Jogo-------------------
            Console.WriteLine("\nFIM DO JOGO! Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}
