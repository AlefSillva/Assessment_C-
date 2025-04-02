namespace Ex06
{
    class Program06
    {
        static void Main(string[] args)
        {
            // Instanciando um objeto da classe Aluno
            double[] notas = { 8.5, 7.5, 9.0 };
            Aluno aluno = new Aluno("Alef", 123, "ADS", notas);

            // Chamando o método exibirDados()
            aluno.exibirDados();

            // Chamando o método verificarAprovacao()
            string situacao = aluno.verificarAprovacao();
            Console.WriteLine("Situação: " + situacao);
        }

    }
}