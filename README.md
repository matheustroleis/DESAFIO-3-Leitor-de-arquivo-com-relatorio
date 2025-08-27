📦 Leitor de Arquivo de Produtos com Relatório
Este é um sistema de console em C# projetado para gerenciar um inventário de produtos. A aplicação simula funcionalidades básicas de um ERP, permitindo a importação de dados via CSV, consultas interativas, geração de relatórios detalhados e operações CRUD (Criar, Ler, Atualizar, Deletar) em memória.

✨ Funcionalidades Principais
Importação de Dados: Carregue produtos de forma massiva a partir de um arquivo .csv.

Gerenciamento Dinâmico: Adicione, atualize e remova produtos em tempo de execução.

Consultas Avançadas: Filtre produtos por nome, categoria ou faixa de preço.

Relatórios Detalhados: Gere resumos analíticos do seu inventário.

Exportação Simples: Salve os relatórios gerados em formato .txt.

🚀 Como Funciona

📂 Importação de Dados (produtos_3.csv)
O sistema inicia lendo o arquivo produtos_3.csv, convertendo cada linha em um objeto Produto. Durante a importação, são realizadas validações para garantir a integridade dos dados:

Validação de Linhas: Verifica se há campos ausentes ou valores inválidos.

Tratamento de Erros: Utiliza exceções personalizadas, como FormatoInvalidoException, para lidar com dados malformados de maneira robusta.

🛠️ Operações CRUD em Memória
Gerencie seu catálogo de produtos diretamente pelo console com as seguintes operações:

Adicionar: Insira um novo produto fornecendo suas informações.

Listar: Visualize todos os produtos cadastrados.

Atualizar:

1.Escolha um produto pelo nome.

2.Selecione o campo que deseja alterar (Nome, Preço ou Categoria).

3.Informe o novo valor.

Remover: Exclua um produto do inventário.

📊 Geração de Relatórios
Crie um relatório de resumo (relatorio.txt) com métricas importantes sobre o seu estoque. Antes de gerar, o sistema permite que você escolha o escopo dos dados:

Relatório Completo: Analisa todos os produtos cadastrados.

Relatório por Categoria: Filtra os dados para uma categoria específica antes de calcular as métricas.

O relatório gerado inclui:

-Total de Produtos: Contagem total de itens no escopo selecionado.

-Produto Mais Caro: Detalhes do produto com o maior preço.

-Média de Preços: O valor médio dos produtos analisados.

🛠️ Tecnologias Utilizadas
Linguagem: C# (.NET)
