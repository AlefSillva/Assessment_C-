namespace Ex05
{
    class Program05
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("   Tempo Restante para Conclusão do Curso   ");
            Console.WriteLine("==============================================");

            Console.WriteLine("Digite a data atual: ");
            string dataAtual = Console.ReadLine();
            
            //----------------------------------------------

            DateTime hoje;

            // Validação da data
            while (!DateTime.TryParse(dataAtual, out hoje) || hoje > DateTime.Today)
            {
                if (hoje > DateTime.Today)
                {
                    Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                }
                else
                {
                    Console.WriteLine("Data inválida. Digite a data atual novamente (dd/MM/yyyy): ");
                }

                dataAtual = Console.ReadLine();
            }

            // Instanciando um novo objeto de data para o término do curso
            DateTime dataTermino = new DateTime(2026, 6, 30);

            // Verifica se o curso já terminou
            if (hoje >= dataTermino)
            {
                Console.WriteLine("Parabéns! Você já deveria estar formado!");
            }
            else
            {
                // Calcula a diferença entre a data de formatura e a data atual
                int anos = dataTermino.Year - hoje.Year;
                int meses = dataTermino.Month - hoje.Month;
                int dias = dataTermino.Day - hoje.Day;

                //----------------------------------------------

                // Ajuste para quando o mês ou o dia forem menores que o esperado
                if (meses < 0)
                {
                    anos--;
                    meses += 12;
                }

                //----------------------------------------------

                // Ajuste para quando o dia for menor que o esperado
                if (dias < 0)
                {
                    meses--;
                    dias += DateTime.DaysInMonth(hoje.Year, hoje.Month); // Ajusta os dias
                }

                //----------------------------------------------

                // Verifica se falta menos de 6 meses para mensagem especial
                if (anos == 0 && meses < 6)
                {
                    Console.WriteLine($"Faltam {meses} mes(es) e {dias} dia(s) para a sua formatura!");
                    Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
                }
                else
                {
                    Console.WriteLine($"Faltam {anos} ano(s), {meses} mes(es) e {dias} dia(s) para a conclusão do curso.");
                }
            }
        }
    }
}
