using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leitr_De_Arquivo_Com_Relatorio;

internal class GerenciadorDeEstoque
{
    public List<Produto> Produtos { get; private set; } = new List<Produto>();

    public void ImportarArquivo(string caminhoDoArquivo)
    {
        var linhas = File.ReadAllLines(caminhoDoArquivo);//Lê todas as linhas do arquivo na váriavel linha 
        for (int i = 1; i < linhas.Length; i++) // i = 1 -> Pula o cabeçalho
        {
            var linha = linhas[i]; // toda vez que passa no loop pega a linha atual
            try
            {
                var colunas = linha.Split(','); //array de string -> [Bolsa Transversal,119.5,Acessorios]

                if (colunas.Length != 3)
                {
                    throw new FormatoInvalidoException($"A linha {i + 1} possui um número de colunas inválido.");
                }
                if (string.IsNullOrWhiteSpace(colunas[0]))
                {
                    throw new FormatoInvalidoException($"O nome do produto na linha {i + 1} está ausente.");
                }
                if (string.IsNullOrWhiteSpace(colunas[1]))
                {
                    throw new FormatoInvalidoException($"A categoria do preço na linha {i + 1} está ausente.");
                }
                if (!decimal.TryParse(colunas[1], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal preco) || preco < 0)
                {
                    throw new FormatoInvalidoException($"O preço do produto na linha {i + 1} é inválido ou negativo.");
                }
                if (string.IsNullOrWhiteSpace(colunas[2]))
                {
                    throw new FormatoInvalidoException($"A categoria do produto na linha {i + 1} está ausente.");
                }
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
}
