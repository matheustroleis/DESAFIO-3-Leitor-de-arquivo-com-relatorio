LEITOR DE ARQUIVO DE PRODUTOS COM RELATÓRIO


Console em C# capaz de gerenciar produtos de um estoque, realizando a importação de dados via CSV, 
permitindo consultas interativas, relatórios detalhados e até operações CRUD em memória.

Esse sistema vai simular parte de um ERP simples, permitindo ao usuário:
-Importar produtos
-Adicionar e remover produtos dinamicamente
-Consultar produtos filtrando por nome, categoria, ou faixa de preço
-Gerar relatórios 
-Exportar os relatórios em formato .txt
 
IMPORTAÇÃO DE DADOS:
-Leitura do arquivo produtos_3.csv
-Criação de objetos Produto
-Validação de linhas (campos ausentes, valores inválidos, etc.)
-Uso de exceções personalizadas como FormatoInvalidoException

OPERAÇÕES CRUD:
Adicionar novo produto via console
Atualizar produto existente
Escolher produto por nome
Escolher qual parte do produto atualizar (Nome, Preço ou Categoria)
Remover produto
Listar todos os produtos cadastrados

RELATÓRIOS:
-Gerar relatório de resumo (relatorio.txt) com:
-total de produtos lidos
-produto mais caro
-média de preços
cada um desses relatórios pode ser feito considerando todos os produtos, ou filtrando por categoria
antes de gerar um relatório o usuário vai poder escolher pelo console como vai ser o relatório
