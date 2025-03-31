namespace Ex04
{
    class Program04
    {
        static void Main(string[] args)
        {
            bool taCerto = true;

            while (taCerto)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("   CÁCULO DE DIAS ATÉ O PRÓXIMO ANIVERSÁRIO   ");
                Console.WriteLine("==============================================");

                Console.WriteLine("Digite a data de nascimento (dd/MM/yyyy): ");
                string dataNascimento = Console.ReadLine();

                if (dataNascimento.Length != 10 || dataNascimento[2] != '/' || dataNascimento[5] != '/')
                {
                    Console.WriteLine("\nPor favor, digite a data no formato correto (dd/mm/yyyy): ");
                    continue;
                }

                string[] partes = dataNascimento.Split("/");

                bool diaValido = int.TryParse(partes[0], out int dia);
                bool mesValido = int.TryParse(partes[1], out int mes);
                bool anoValido = int.TryParse(partes[2], out int ano);

                if (!diaValido || !mesValido || !anoValido)
                {
                    Console.WriteLine("Data Inválida. Digite o formato correto (dd/mm/yyyy).");
                    continue;
                }

                if ((dia >= 1 && dia <= 31) && (mes >= 1 && mes <= 12) && ano >= 1900)
                {
                    try
                    {
                        DateTime dataValida = new DateTime(ano, mes, dia);

                        var diasRestantes = ProximoAniversario(dataValida);

                        if (diasRestantes < 7)
                        {
                            Console.WriteLine("Faltam menos de 7 dias para o seu aniversário, UHUUL !!!!");
                        }
                        
                        Console.WriteLine($"\nFaltam {diasRestantes} dias para o seu próximo aniversário.");

                        taCerto = false;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Data Inválida. Dia ou mês fora do intervalo permitido.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erro de formato. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira uma data válida.");
                }
            }
        }

        static int ProximoAniversario(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Today;
            DateTime proximoAniversario = new DateTime(dataAtual.Year, dataNascimento.Month, dataNascimento.Day);
            
            if (proximoAniversario < dataAtual)
            {
                proximoAniversario = proximoAniversario.AddYears(1);
            }
            return (int)(proximoAniversario - dataAtual).Days;
        }
    }
}