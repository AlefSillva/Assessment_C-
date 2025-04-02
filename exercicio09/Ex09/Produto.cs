

namespace Ex09
{
    class Produto
    {
        public string nome { get; set; }
        public int quantidadeEmEstoque { get; set; }
        public decimal precoUnitario { get; set; }

        // Construtor
        public Produto(string nome, int quantidadeEmEstoque, decimal precoUnitario)
        {
            this.nome = nome;
            this.quantidadeEmEstoque = quantidadeEmEstoque;
            this.precoUnitario = precoUnitario;
        }

        // Método ListarProdutos()
        public void ListarProdutos()
        {
            Console.WriteLine($"Produto: {nome} | Quantidade: {quantidadeEmEstoque} | Preço: {precoUnitario:F2}");
        }
    }
}
