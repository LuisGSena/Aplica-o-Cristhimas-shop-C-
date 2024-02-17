namespace TrabalhoFinalCsharp.Models
{
    public class Usuario
    {
        // Propriedades
        public int Id { get; set; }
        public string? EmailUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public string? SenhaUsuario { get; set; }
        public string? CPFUsuario { get; set; }
        public string? CEPUsuario { get; set; }

        public Usuario()
        {
        }
    }
}