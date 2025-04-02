namespace Ex07
{
    public class Program06
    {
        static void Main(string[] args)
        {
            // Instanciando a classe ContaBancaria
            ContaBancaria conta = new ContaBancaria("João Silva", 0);

            // Realizando um depósito
            conta.Depositar(500);

            // Tentativa de saque acima do saldo
            conta.Sacar(700);

            // Realizando um saque
            conta.Sacar(200);

            // Exibindo o saldo
            Console.WriteLine($"Saldo atual: R$ {conta.ExibirSaldo():F2}");
        }
    }
}