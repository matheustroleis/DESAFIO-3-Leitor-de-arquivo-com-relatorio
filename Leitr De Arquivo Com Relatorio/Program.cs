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
                        ImportarArquivo();
                        break;
                    case "2":
                        gerenciador.AdicionarProduto();
                        break;
                    case "3":
                        gerenciador.RemoverProduto();
                        break;
                    case "4":
                        gerenciador.AtualizarProduto();
                        break;
                    case "5":
                        gerenciador.ListarProdutos();
                        break;
                    case "6":
                        gerenciador.ConsultarProdutos();
                        break;
                    case "7":
                        gerenciador.GerarRelatorio();
                        break;
                    case "8":
                        Console.WriteLine("Fechando Aplicação...");
                        Thread.Sleep(2000);
                        return;
                }
            }
        }

        void ImportarArquivo()
        {
            try
            {
                gerenciador.ImportarProdutos("produtos_3.csv");
                Console.WriteLine($"\nImportação concluída. {gerenciador.Produtos.Count} produtos válidos foram carregados.");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Arquivo produtos_3.csv não encontrado");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro inesperado durante a importação: {ex.Message}");
            }
            Console.WriteLine("Pressione qualquer tecla para gerenciar o arquivo...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
