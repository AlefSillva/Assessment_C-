

using System.Text;

namespace Ex07
{
    internal class ContaBancaria
    {
        public string titular { get; set; }
        private decimal saldo;

        //---------------------------------------

        // Construtor
        public ContaBancaria(string titular, decimal saldo)
        {
            this.titular = titular;
            this.saldo = saldo;
        }

        //---------------------------------------

        //----------------Métodos----------------
        // Método para depositar
        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Console.WriteLine($"Depósito de R$ {valor} realizado com sucesso!");
            }
            else { 
                Console.WriteLine("O valor do depósito deve ser positivo!");
            }
        }

        // Método para sacar
        public void Sacar(decimal valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
            }
            else {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
            }
        }

        // Método para retornar o saldo
        public decimal ExibirSaldo()
        {
            return saldo;
        }
    }
}
