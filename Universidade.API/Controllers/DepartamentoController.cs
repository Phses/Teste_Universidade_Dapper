using Microsoft.AspNetCore.Mvc;
using Universidade.Domain.Entities;
using Universidade.Domain.Interfaces.Repository;

namespace Universidade.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepository _DepartamentoRepository;

        public DepartamentoController(IDepartamentoRepository DepartamentoRepository)
        {
            _DepartamentoRepository = DepartamentoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Departamentos = await _DepartamentoRepository.ListAsync();
            return Ok(Departamentos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var Departamento = await _DepartamentoRepository.FindAsync(id);
            return Ok(Departamento);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Departamento entity)
        {
            var id = await _DepartamentoRepository.AddAsync(entity);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Departamento Departamento, [FromRoute] int id)
        {
            await _DepartamentoRepository.AtualizarAsync(Departamento, id);
            return Ok(Departamento);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelAsync([FromRoute] int id)
        {
            await _DepartamentoRepository.DeleteAsync(id);
            return Ok(id);
        }
    }
}
