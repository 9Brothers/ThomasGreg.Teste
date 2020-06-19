using System;

namespace ThomasGreg.Teste.Domain.Entities
{
    public class Logradouro : SqlEntity
    {
        public string Nome { get; set; }        
        public Guid ClienteId { get; set; }
    }
}