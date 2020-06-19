using System;

namespace ThomasGreg.Teste.Domain.Entities
{
    public class SqlEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}