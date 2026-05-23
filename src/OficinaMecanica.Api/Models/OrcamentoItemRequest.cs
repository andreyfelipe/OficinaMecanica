using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaMecanica.Api.Models
{
    public class OrcamentoItemRequest
    {
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}