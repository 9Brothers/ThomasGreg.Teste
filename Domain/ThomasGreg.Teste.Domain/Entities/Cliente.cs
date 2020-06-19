using System.Collections.Generic;

namespace ThomasGreg.Teste.Domain.Entities
{
    public class Cliente : SqlEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        public IEnumerable<Logradouro> Logradouros { get; set; }
    }
}