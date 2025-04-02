
namespace Ex08
{
    internal class Funcionario
    {
        public string nome { get; set; }
        public string cargo { get; set; }
        public decimal salarioBase { get; set; }

        //------------------------------------

        // Contrutor
        public Funcionario(string nome, string cargo, decimal salarioBase)
        {
            this.nome = nome;
            this.cargo = cargo;
            this.salarioBase = salarioBase;
        }

        //------------------------------------
        // Metodo CalcularSalario()
        public virtual decimal CalcularSalario()
        {
            return salarioBase;
        }
    }
}
