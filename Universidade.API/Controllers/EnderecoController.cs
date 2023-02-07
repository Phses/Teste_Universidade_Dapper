using Microsoft.AspNetCore.Mvc;
using Universidade.Domain.Entities;
using Universidade.Domain.Interfaces.Repository;

namespace Universidade.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var enderecos = await _enderecoRepository.ListAsync();
            return Ok(enderecos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var endereco = await _enderecoRepository.FindAsync(id);
            return Ok(endereco);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Endereco entity)
        {
            var id = await _enderecoRepository.AddAsync(entity);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Endereco endereco, [FromRoute] int id)
        {
            await _enderecoRepository.AtualizarAsync(endereco, id);
            return Ok(endereco);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelAsync([FromRoute] int id)
        {
            await _enderecoRepository.DeleteAsync(id);
            return Ok(id);
        }
    }
}
