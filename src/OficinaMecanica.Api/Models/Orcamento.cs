using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaMecanica.Api.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }
        public IList<OrcamentoItem> Itens { get; set; } = new List<OrcamentoItem>();
    }
}