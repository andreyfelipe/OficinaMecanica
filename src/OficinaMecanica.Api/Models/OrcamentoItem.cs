using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaMecanica.Api.Models
{
    public class OrcamentoItem
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total => Quantidade * ValorUnitario;
        public Orcamento? Orcamento { get; set; }
    }
}