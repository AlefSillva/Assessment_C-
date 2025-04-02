

namespace Ex06
{
    internal class Aluno
    {
        string nome;
        int matricula;
        string curso;
        double[] mediaDasNotas = new double[3];

        //---------------------------------------------
        // Construtor
        public Aluno(string nome, int matricula, string curso, double[] mediaDasNotas)
        { 
            this.nome = nome;
            this.matricula = matricula;
            this.curso = curso;
            this.mediaDasNotas = mediaDasNotas;
        }
        //---------------------------------------------

        //---------------------Métodos------------------------
        // método exibirDados()
        public void exibirDados()
        {
            double soma = 0;
            foreach (double nota in mediaDasNotas)
            {
                soma += nota;
            }

            // evitando divisão por zero
            double media = mediaDasNotas.Length > 0 ? soma / mediaDasNotas.Length : 0;

            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Matrícula: " + matricula);
            Console.WriteLine("Curso: " + curso);
            Console.WriteLine("Média das notas: " + media.ToString("F2") + "\n");

            Console.WriteLine("Notas do Aluno: ");
            for (int i = 0; i < mediaDasNotas.Length; i++ )
            {
                Console.Write($"Nota {i + 1}: {mediaDasNotas[i]}");

                if (i < mediaDasNotas.Length -1) Console.Write(" | ");
            }
            Console.WriteLine("\n");
        }

        // método verificarAprovacao()
        public string verificarAprovacao()
        {
            double soma = 0;
            foreach (double nota in mediaDasNotas)
            {
                soma += nota;
            }

            double media = soma / mediaDasNotas.Length;

            return media >= 7 ? "Aprovado" : "Reprovado";
        }
    }
}
