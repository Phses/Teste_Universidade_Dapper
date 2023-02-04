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
        public async Task<IActionResult> GetAsync()
        {
            var enderecos = await _enderecoRepository.ListAsync();
            return Ok(enderecos);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Endereco entity)
        {
            var id = await _enderecoRepository.AddAsync(entity);
            return Ok(id);
        }
    }
}
