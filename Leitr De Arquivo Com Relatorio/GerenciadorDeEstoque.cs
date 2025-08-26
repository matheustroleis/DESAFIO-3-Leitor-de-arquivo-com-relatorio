using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Leitr_De_Arquivo_Com_Relatorio;

internal class GerenciadorDeEstoque
{
    public List<Produto> Produtos { get; private set; } = new List<Produto>();

    public void ImportarProdutos(string caminhoDoArquivo)
    {
        var linhas = File.ReadAllLines(caminhoDoArquivo);//Lê todas as linhas do arquivo na váriavel linhas 
        for (int i = 1; i < linhas.Length; i++) // i = 1 -> Pula o cabeçalho
        {
            var linha = linhas[i]; // toda vez que passa no loop pega a linha atual
            try
            {
                var colunas = linha.Split(','); //array de string -> [Bolsa Transversal,119.5,Acessorios]

                if (colunas.Length != 4)
                {
                    throw new FormatoInvalidoException($"A linha {i + 1} possui um número de colunas inválido.");
                }
                if (string.IsNullOrWhiteSpace(colunas[0]))
                {
                    throw new FormatoInvalidoException($"O nome do produto na linha {i + 1} está ausente.");
                }
                if (!decimal.TryParse(colunas[1], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal preco) || preco < 0)
                {
                    throw new FormatoInvalidoException($"O preço do produto na linha {i + 1} é inválido ou negativo.");
                }

                string nome = colunas[0];

                if (nome.ToLower().Contains("erro"))
                {
                    throw new FormatoInvalidoException($"O nome do produto na linha {i + 1} foi identificado como um erro ('{nome}').");
                }
                if (string.IsNullOrWhiteSpace(colunas[1]))
                {
                    throw new FormatoInvalidoException($"A categoria do preço na linha {i + 1} está ausente.");
                }
                if (string.IsNullOrWhiteSpace(colunas[2]))
                {
                    throw new FormatoInvalidoException($"A categoria do produto na linha {i + 1} está ausente.");
                }

                string categoria = colunas[2];
               
                var produtoImportacao = new Produto(nome, preco, categoria);

                Produtos.Add(produtoImportacao);
            }
            catch (FormatoInvalidoException ex)
            {
                Console.WriteLine($"Erro de validação na linha {i + 1}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado ao processar a linha {i + 1}: {ex.Message}");
            }
        }
    }

    public void AdicionarProduto()
    {
        Console.WriteLine("--- Adicionar Novo Produto ---\n");
        Console.Write("Nome do produto: ");
        var nome = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("\nO nome não pode ser vazio. Por favor digite novamente");
            Console.Write("Nome do produto: ");
            nome = Console.ReadLine();
        }

        decimal preco;
        Console.Write("\nPreço do produto (use . como separador decimal): ");
        while (!decimal.TryParse(Console.ReadLine() ?? "", CultureInfo.InvariantCulture, out preco) || preco < 0)
        {
            Console.WriteLine("\nPreço inválido ou negativo. Por favor, insira um preço válido.");
            Console.Write("Preço do produto (use . como separador decimal): ");
        }

        Console.Write("\nCategoria do produto: ");
        var categoria = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(categoria))
        {
            Console.WriteLine("\nA categoria não pode estar vazia. Por favor digite novamente");
            Console.Write("Categoria do produto: ");
            categoria = Console.ReadLine();
        }

        var produto = new Produto(nome, preco, categoria);
        
        Produtos.Add(produto);
        Console.WriteLine($"\nProduto {produto.Nome} adicionado com sucesso");
        Console.WriteLine("\nPressione qualquer tecla para VOLTAR AO MENU...");
        Console.ReadKey();
        Console.Clear();

    }

    public void ListarProdutos()
    {
        if (Produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\n Lista de Pordutos: ");

        foreach (var produto in Produtos)
        {
            Console.WriteLine(produto);
        }

        Console.WriteLine("\nPressione qualquer tecla para VOLTAR AO MENU...");
        Console.ReadKey();
        Console.Clear();

    }

    public void RemoverProduto()
    {
        Console.WriteLine("--- Remover Produto ---\n");

        if (Produtos.Count == 0)
        {
            Console.WriteLine("Não há produtos no estoque para remover.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            return; 
        }

        Console.WriteLine("Produtos disponíveis:");
        foreach (var produto in Produtos)
        {
            Console.WriteLine(produto.ToString());
        }

        Console.Write("\nDigite o nome exato do produto que deseja remover: ");
        string nomeParaRemover = Console.ReadLine();

        var produtoEncontrado = Produtos.FirstOrDefault(p => p.Nome.Equals(nomeParaRemover)); //FirstOrDefault -> retorna o primeiro valor encontrado

        if (produtoEncontrado != null)
        { 
            Produtos.Remove(produtoEncontrado);
            Console.WriteLine("\nProduto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("\nProduto não encontrado. Verifique se o nome foi digitado corretamente.");
        }

        Console.WriteLine("Pressione qualquer tecla para VOLTAR AO MENU...");
        Console.ReadKey();
        Console.Clear();
    }

    public void AtualizarProduto()
    {
        Console.WriteLine("\n--- Atualizar Produto ---");

        if (Produtos.Count == 0)
        {
            Console.WriteLine("Não há produtos no estoque para atualizar.");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Produtos disponíveis para atualização:");
        foreach (var produto in Produtos)
        {
            Console.WriteLine(produto.ToString());
        }

        Console.Write("\nDigite o nome exato do produto que deseja atualizar: ");
        string nomeParaAtualizar = Console.ReadLine();

        var produtoParaAtualizar = Produtos.FirstOrDefault(p => p.Nome.Equals(nomeParaAtualizar));

        
        if (produtoParaAtualizar != null) // Se encontramos o produto, pedimos os novos dados
        {
            
            Console.WriteLine("\nDigite os novos dados para o produto (deixe em branco para não alterar).");

            Console.Write($"Novo nome ({produtoParaAtualizar.Nome}): ");
            string novoNome = Console.ReadLine();

            Console.Write($"Novo preço (use , como separador)({produtoParaAtualizar.Preco:C}): ");
            string novoPreco = Console.ReadLine();

            Console.Write($"Nova categoria ({produtoParaAtualizar.Categoria}): ");
            string novaCategoria = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoNome)) //IsNullOrWhiteSpace -> ÉNuloOuEspaçoEmBranco
            {
                produtoParaAtualizar.Nome = novoNome;
            }

            if (!string.IsNullOrWhiteSpace(novoPreco))
            {
                if (decimal.TryParse(novoPreco, out decimal precoAtualizado))
                {
                    produtoParaAtualizar.Preco = precoAtualizado;
                }
                else
                {
                    Console.WriteLine("Valor de preço inválido. O preço não foi alterado.");
                }
            }

            if (!string.IsNullOrWhiteSpace(novaCategoria))
            {
                produtoParaAtualizar.Categoria = novaCategoria;
            }

            Console.WriteLine("\nProduto atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nProduto não encontrado.");
        }

        Console.WriteLine("\nPressione qualquer tecla para VOLTAR AO MENU...");
        Console.ReadKey();
        Console.Clear();
    }

    public void ConsultarProdutos()

    
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- Menu de Consulta ---");

            if (Produtos.Count == 0)
            {
                Console.WriteLine("Não há produtos no estoque para consultar.");
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("1. Consultar por Nome");
            Console.WriteLine("2. Consultar por Categoria");
            Console.WriteLine("3. Consultar por Preço Máximo");
            Console.WriteLine("4. Voltar ao Menu Principal");
            Console.Write("Escolha um tipo de filtro: ");

            var opcao = Console.ReadLine();


            List<Produto> resultados = new List<Produto>();
            bool sair = false;

            switch (opcao)
            {
                case "1":
                    Console.Write("\nDigite o nome do produto: ");
                    string nomeBusca = Console.ReadLine() ?? "";
                    resultados = Produtos.Where(p => p.Nome.Contains(nomeBusca)).ToList();
                    break;
                case "2":
                    Console.Write("\nDigite a categoria: ");
                    string categoriaBusca = Console.ReadLine() ?? "";
                    resultados = Produtos.Where(p => p.Categoria.Contains(categoriaBusca)).ToList();
                    break;
                case "3":
                    Console.Write("\nDigite o preço máximo: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal precoMaximo) && precoMaximo >= 0)
                    {
                        resultados = Produtos.Where(p => p.Preco <= precoMaximo).OrderBy(p => p.Preco).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Preço inválido.");
                    }
                    break;
                case "4":
                    sair = true;
                    break;
            }
            
            if (sair)
            {
                Console.Clear();
                break; // Quebra o loop 'while' e volta para o menu principal
            }

            Console.Clear();
            if (resultados.Any()) //Any em LINQ é para verifiação booleana
            {
                Console.WriteLine("\n--- Resultados da Busca ---");
                foreach (var produto in resultados)
                {
                    Console.WriteLine(produto.ToString());
                }
            }
            else
            {
               Console.WriteLine("\nNenhum produto encontrado com o critério informado.");
            }

            Console.WriteLine("\nPressione qualquer tecla para VOLTAR AO MENU...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public void GerarRelatorio()
    {

    }
}
