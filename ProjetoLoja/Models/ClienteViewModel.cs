namespace ProjetoLoja.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public required string Email { get; set; }
        public string Telefone { get; set; }

    }
}
