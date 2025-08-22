using System;

namespace Leitr_De_Arquivo_Com_Relatorio;
internal class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Categoria { get; set; }
    

    public Produto(string nome, decimal preco, string categoria)
    {
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
    }

    public override string ToString()
    {
        return $" Nome: {Nome} | Preço: R${Preco:C} | Categoria: {Categoria}";
    }
}
