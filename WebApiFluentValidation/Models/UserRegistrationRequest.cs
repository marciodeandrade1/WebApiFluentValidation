namespace WebApiFluentValidation.Models
{
    public class UserRegistrationRequest
    {
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? ConfirmaSenha { get; set; }
    }
}