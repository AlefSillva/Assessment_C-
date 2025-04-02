using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Ex11
{
    class Program11
    {
        // Caminho do arquivo 
        static string arquivoContatos = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "contatos.txt");


        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Gerenciador de Contatos ===");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos cadastrados");
                Console.WriteLine("3 - Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarContato();
                        break;

                    case "2":
                        ListarContatos();
                        break;

                    case "3":
                        Console.WriteLine("Encerrando programa...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        //---------------------------------------

        // Método adicionarContato()
        static void AdicionarContato()
        {
            string nome, telefone, email;

            // Entrada de informações do usuário
            nome = ValidarNome();
            telefone = ValidarTelefone();
            email = ValidarEmail();

            // Salvar no arquivo
            try
            {
                using (StreamWriter writer = new StreamWriter(arquivoContatos, true))
                {
                    writer.WriteLine($"{nome},{telefone},{email}");
                }
                Console.WriteLine("\nContato cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao salvar o contato: {e.Message}");
            }

            Console.WriteLine("\nPressione ENTER para continuar.");
            Console.ReadLine();
        }

        // Função para validar o nome
        static string ValidarNome()
        {
            string nome;
            while (true)
            {
                Console.Write("\nNome: ");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome não pode ser vazio. Tente novamente.");
                }
                else
                {
                    break;
                }
            }
            return nome;
        }

        // Função para validar e formatar o telefone
        static string ValidarTelefone()
        {
            string telefone;
            while (true)
            {
                Console.Write("Telefone (apenas números): ");
                telefone = Console.ReadLine();

                // Verificando se o número tem pelo menos 10 dígitos
                if (telefone.Length >= 10 && telefone.Length <= 11 && long.TryParse(telefone, out _))
                {
                    // Formatando o número
                    telefone = FormatarTelefone(telefone);
                    break;
                }
                else
                {
                    Console.WriteLine("Telefone inválido! Digite apenas números e com no mínimo 10 e no máximo 11 dígitos.");
                }
            }
            return telefone;
        }

        // Função para validar o email
        static string ValidarEmail()
        {
            string email;
            while (true)
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    Console.WriteLine("Email inválido! Tente novamente.");
                }
                else
                {
                    break;
                }
            }
            return email;
        }

        // Função para formatar o número de telefone
        static string FormatarTelefone(string telefone)
        {
            if (telefone.Length == 11)
            {
                return string.Format("({0}) {1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 5), telefone.Substring(7, 4));
            }
            else if (telefone.Length == 10)
            {
                return string.Format("({0}) {1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 4), telefone.Substring(6, 4));
            }
            return telefone;
        }

        // Método listarCadastrados()
        static void ListarContatos()
        {
            Console.WriteLine("\nContatos cadastrados:");

            if (File.Exists(arquivoContatos))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(arquivoContatos))
                    {
                        string linha;
                        bool encontrouContatos = false;

                        while ((linha = reader.ReadLine()) != null)
                        {
                            encontrouContatos = true;
                            var dados = linha.Split(',');

                            if (dados.Length == 3)
                            {
                                string nome = dados[0];
                                string telefone = dados[1];
                                string email = dados[2];

                                Console.WriteLine($"Nome: {nome} | Telefone: {telefone} | Email: {email}");
                            }
                        }

                        if (!encontrouContatos)
                        {
                            Console.WriteLine("Nenhum contato cadastrado.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao carregar contatos: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }

            Console.WriteLine("\nPressione ENTER para continuar.");
            Console.ReadLine();
        }
    }
}
