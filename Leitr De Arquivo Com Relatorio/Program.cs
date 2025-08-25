using Leitr_De_Arquivo_Com_Relatorio;


class Program
{
    static void Main(string[] args)
    {

        var gerenciador = new GerenciadorDeEstoque();

        ExibirOpçõesDoMenu();


        void ExibirOpçõesDoMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu Principal ---");
                Console.WriteLine("1. Importar Produtos do CSV");
                Console.WriteLine("2. Adicionar Produto");
                Console.WriteLine("3. Remover Produto");
                Console.WriteLine("4. Atualizar Produto");
                Console.WriteLine("5. Listar Todos os Produtos");
                Console.WriteLine("6. Consultar Produtos");
                Console.WriteLine("7. Gerar Relatório");
                Console.WriteLine("8. Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        gerenciador.ImportarArquivo("produtos_3.csv");
                        Console.WriteLine("Importação concluída. Produtos válidos foram carregados.");
                        break;
                    case "2":
                        AdicionarProdutoNovo();
                        break;
                    case "3":
                        break;
                        
                    case "4":
                        break;
                        
                    case "5":
                        gerenciador.ListarProdutos();
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                }
            }
        }
       
        void AdicionarProdutoNovo()
        {
            Console.Write("Nome do produto: ");
            var nome = Console.ReadLine();
            Console.Write("Preço do produto (use , como separador): ");
            var preco = decimal.Parse(Console.ReadLine());
            Console.Write("Categoria do produto: ");
            var categoria = Console.ReadLine();

            var produto = new Produto(nome, preco, categoria);
            gerenciador.AdicionarProduto(produto);
        }


    }
}
