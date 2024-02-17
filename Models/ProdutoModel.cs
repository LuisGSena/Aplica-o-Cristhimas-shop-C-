using System;
namespace TrabalhoFinalCsharp.Models
{
    public class ProdutoModel
    {
        // Propriedades
        public int Id { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string? NomeProduto { get; set; }
        public float ValorUnidade { get; set; }
        public string? Slug { get; set; }

        // Construtor
        public ProdutoModel()
        {
        }

    }
}
