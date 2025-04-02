
namespace Ex08
{
    class Gerente : Funcionario    
    {
        // Contrutor
        public Gerente(string nome, decimal salarioBase) 
            : base(nome, "Gerente", salarioBase) 
        {
        }

        // Metodo CalcularSalario() reescrito
        public override decimal CalcularSalario()
        {
            return salarioBase * 1.2m;
        }

    }
}
