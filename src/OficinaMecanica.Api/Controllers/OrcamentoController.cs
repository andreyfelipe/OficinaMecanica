using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaMecanica.Api.Data;
using OficinaMecanica.Api.Models;

namespace OficinaMecanica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrcamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrcamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrcamentoRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { error = "O corpo da requisição não pode ser vazio." });
            }

            var errors = ValidateRequest(request);
            if (errors.Any())
            {
                return BadRequest(new { errors });
            }

            var orcamento = new Orcamento
            {
                ClienteId = request.ClienteId,
                VeiculoId = request.VeiculoId,
                Itens = request.Itens.Select(item => new OrcamentoItem
                {
                    Descricao = item.Descricao.Trim(),
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario
                }).ToList()
            };

            orcamento.Total = orcamento.Itens.Sum(item => item.Total);

            _context.Orcamentos.Add(orcamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = orcamento.Id }, orcamento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orcamento = await _context.Orcamentos
                .Include(o => o.Itens)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orcamento == null)
            {
                return NotFound();
            }

            return Ok(orcamento);
        }

        private static IEnumerable<string> ValidateRequest(OrcamentoRequest request)
        {
            var errors = new List<string>();

            if (request.ClienteId <= 0)
            {
                errors.Add("clientId é obrigatório e deve ser maior que zero.");
            }

            if (request.VeiculoId <= 0)
            {
                errors.Add("veiculoId é obrigatório e deve ser maior que zero.");
            }

            if (request.Itens == null || !request.Itens.Any())
            {
                errors.Add("O orçamento deve conter pelo menos um item.");
            }
            else
            {
                for (var index = 0; index < request.Itens.Count; index++)
                {
                    var item = request.Itens[index];
                    var itemNumber = index + 1;

                    if (string.IsNullOrWhiteSpace(item.Descricao))
                    {
                        errors.Add($"Item {itemNumber}: descrição é obrigatória.");
                    }

                    if (item.Quantidade <= 0)
                    {
                        errors.Add($"Item {itemNumber}: quantidade deve ser maior que zero.");
                    }

                    if (item.ValorUnitario <= 0)
                    {
                        errors.Add($"Item {itemNumber}: valorUnitario deve ser maior que zero.");
                    }
                }
            }

            return errors;
        }
    }
}