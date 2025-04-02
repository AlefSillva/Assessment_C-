namespace Ex08
{
    class Program
    {
        static void Main(string[] args)
        {
            // instanciando um gerente
            Funcionario gerente = new Gerente("Alef", 6000);

            // metodo Bonus() da classe CalcularSalario()
            Console.WriteLine($"Nome: {gerente.nome}");
            Console.WriteLine($"Cargo: {gerente.cargo}");
            Console.WriteLine($"Salário: {gerente.CalcularSalario():F2}");
        }
    }
}