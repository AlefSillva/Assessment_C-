namespace Ex09
{
    class Program09
    {
        static string arquivo = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "estoque.txt");

        static void Main(string[] args)
        {
            Produto[] produtos = new Produto[5];
            int contador = 0;

            // Carregar produtos do arquivo
            CarregarProdutosDoArquivo(ref produtos, ref contador);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Sistema de Gerenciamento de Estoque");
                Console.WriteLine("1. Inserir Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Sair");

                Console.Write("\nEscolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        if (contador < 5)
                        {
                            string nome;
                            int quantidadeEmEstoque;
                            decimal precoUnitario;

                            do
                            {
                                Console.Write("Digite o nome do Produto: ");
                                nome = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(nome))
                                {
                                    Console.WriteLine("O nome do produto não pode ser vazio ou nulo. Tente novamente.");
                                }

                            } while (string.IsNullOrWhiteSpace(nome));

                            Console.Write("Digite a quantidade em estoque: ");
                            while (!int.TryParse(Console.ReadLine(), out quantidadeEmEstoque) || quantidadeEmEstoque < 0)
                            {
                                Console.WriteLine("Entrada inválida! Digite um número inteiro positivo.");
                                Console.Write("Digite a quantidade em estoque: ");
                            }

                            Console.Write("Digite o preço unitário: ");
                            while (!decimal.TryParse(Console.ReadLine(), out precoUnitario) || precoUnitario < 0)
                            {
                                Console.Write("\nPreço inválido! Digite novamente: ");
                            }

                            Produto produto = new Produto(nome, quantidadeEmEstoque, precoUnitario);
                            produtos[contador] = produto;
                            contador++;

                            // Salvar o produto no arquivo
                            SalvarProdutoNoArquivo(produto);

                            Console.WriteLine($"\nO produto {nome} foi cadastrado com sucesso!");
                            Console.WriteLine("\nPressione ENTER para continuar.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nLimite de produtos atingido!");
                            Console.WriteLine("\nPressione ENTER para continuar.");
                            Console.ReadLine();
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nListagem de Produtos: \n");
                        if (contador == 0)
                        {
                            Console.WriteLine("Nenhum produto cadastrado.");
                        }
                        else
                        {
                            for (int i = 0; i < contador; i++)
                            {
                                produtos[i].ListarProdutos();
                            }
                        }
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("Saindo do programa...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        //-----------------Métodos-----------------

        // Método para salvar o produto no arquivo
        static void SalvarProdutoNoArquivo(Produto produto)
        {
            try
            {
                // Usando o caminho atualizado
                using (StreamWriter writer = new StreamWriter(arquivo, true))
                {
                    writer.WriteLine($"{produto.nome},{produto.quantidadeEmEstoque},{produto.precoUnitario}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao salvar produto no arquivo: {e.Message}");
            }
        }

        //-----------------------------------------

        // Método para carregar produtos do arquivo
        static void CarregarProdutosDoArquivo(ref Produto[] produtos, ref int contador)
        {
            if (File.Exists(arquivo))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(arquivo))
                    {
                        string linha;
                        while ((linha = reader.ReadLine()) != null)
                        {
                            var dados = linha.Split(',');

                            if (dados.Length == 3)
                            {
                                string nome = dados[0];
                                int quantidadeEmEstoque = int.Parse(dados[1]);

                                decimal precoUnitario = decimal.Parse(dados[2]);

                                Produto produto = new Produto(nome, quantidadeEmEstoque, precoUnitario);

                                if (contador < 5)
                                {
                                    produtos[contador] = produto;
                                    contador++;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Erro na linha do arquivo: {linha}. Esperado 3 valores separados por vírgula.");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao carregar produtos: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
        }
    }
}
