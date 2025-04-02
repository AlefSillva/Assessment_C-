using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}

abstract class ContatoFormatter
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
            Console.WriteLine($"- 📧 Email: {contato.Email}");
            Console.WriteLine();
        }
    }
}

class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("| Nome               | Telefone        | Email             |");
        Console.WriteLine("----------------------------------------");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome,-18} | {contato.Telefone,-15} | {contato.Email,-17} |");
        }
        Console.WriteLine("----------------------------------------");
    }
}

class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Contato> contatos = new List<Contato>();

        // Carregar contatos do arquivo
        CarregarContatos(contatos);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciamento de Contatos ===");
            Console.WriteLine("1. Cadastrar novo contato");
            Console.WriteLine("2. Exibir contatos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            if (opcao == "1")
            {
                CadastrarContato(contatos);
            }
            else if (opcao == "2")
            {
                ExibirContatos(contatos);
            }
            else if (opcao == "3")
            {
                // Salvar contatos antes de sair
                SalvarContatos(contatos);
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                Console.ReadKey();
            }
        }
    }

    static void CadastrarContato(List<Contato> contatos)
    {
        Console.Clear();
        Console.WriteLine("Cadastrar Novo Contato");

        string nome, telefone, email;

        // Nome
        Console.Write("Nome: ");
        nome = Console.ReadLine();

        // Telefone com validação (apenas números)
        telefone = "";
        while (true)
        {
            Console.Write("Telefone (somente números, ex: 21999999999): ");
            telefone = Console.ReadLine();
            if (ValidarTelefone(telefone))
            {
                telefone = FormatTelefone(telefone); // Formatar telefone
                break;
            }
            else
            {
                Console.WriteLine("Telefone inválido! Certifique-se de digitar somente números (ex: 21999999999).");
            }
        }

        // E-mail com validação
        email = "";
        while (true)
        {
            Console.Write("Email: ");
            email = Console.ReadLine();
            if (ValidarEmail(email))
            {
                break;
            }
            else
            {
                Console.WriteLine("Email inválido! Certifique-se de usar um formato válido (ex: exemplo@dominio.com).");
            }
        }

        // Validações
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone) || string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Todos os campos são obrigatórios. Tente novamente.");
            Console.ReadKey();
            return;
        }

        contatos.Add(new Contato(nome, telefone, email));

        // Salvar os contatos imediatamente no arquivo
        SalvarContatos(contatos);
    }

    static void ExibirContatos(List<Contato> contatos)
    {
        Console.Clear();
        Console.WriteLine("Escolha o formato de exibição:");

        Console.WriteLine("1. Exibir em formato Markdown");
        Console.WriteLine("2. Exibir em formato Tabela");
        Console.WriteLine("3. Exibir em formato Texto Puro");

        Console.Write("Escolha uma opção: ");
        var formato = Console.ReadLine();

        ContatoFormatter formatoEscolhido = null;

        if (formato == "1")
        {
            formatoEscolhido = new MarkdownFormatter();
        }
        else if (formato == "2")
        {
            formatoEscolhido = new TabelaFormatter();
        }
        else if (formato == "3")
        {
            formatoEscolhido = new RawTextFormatter();
        }
        else
        {
            Console.WriteLine("Opção inválida.");
            Console.ReadKey();
            return;
        }

        formatoEscolhido.ExibirContatos(contatos);
        Console.ReadKey();
    }

    static bool ValidarTelefone(string telefone)
    {
        // Verifica se o telefone contém somente números
        return telefone.All(char.IsDigit) && telefone.Length >= 10 && telefone.Length <= 11;
    }

    static string FormatTelefone(string telefone)
    {
        // Formata o telefone no formato (XX) XXXXX-XXXX
        return string.Format("({0}) {1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 5), telefone.Substring(7, 4));
    }

    static bool ValidarEmail(string email)
    {
        // Expressão regular para validar o formato básico de email
        var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
        return regex.IsMatch(email);
    }

    static void CarregarContatos(List<Contato> contatos)
    {
        try
        {
            if (File.Exists("contatos.txt"))
            {
                var linhas = File.ReadAllLines("contatos.txt");
                foreach (var linha in linhas)
                {
                    var partes = linha.Split('|');
                    if (partes.Length == 3)
                    {
                        var nome = partes[0].Trim();
                        var telefone = partes[1].Trim();
                        var email = partes[2].Trim();
                        contatos.Add(new Contato(nome, telefone, email));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar os contatos: {ex.Message}");
        }
    }

    static void SalvarContatos(List<Contato> contatos)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter("contatos.txt"))
            {
                foreach (var contato in contatos)
                {
                    sw.WriteLine($"{contato.Nome} | {contato.Telefone} | {contato.Email}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar os contatos: {ex.Message}");
        }
    }
}
