namespace ThomasGreg.Teste.Domain.Entities
{
    public class Usuario : SqlEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}