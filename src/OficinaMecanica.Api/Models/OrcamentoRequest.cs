using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaMecanica.Api.Models
{
    public class OrcamentoRequest
    {
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public IList<OrcamentoItemRequest> Itens { get; set; } = new List<OrcamentoItemRequest>();
    }
}