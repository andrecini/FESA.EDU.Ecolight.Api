namespace Treinamento.REST.Domain.Entities.Auth
{
    public class TokenModel
    {
        public string? Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
