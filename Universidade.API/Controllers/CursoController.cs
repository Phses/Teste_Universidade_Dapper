using Microsoft.AspNetCore.Mvc;
using Universidade.Domain.Entities;
using Universidade.Domain.Interfaces.Repository;

namespace Universidade.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository CursoRepository)
        {
            _cursoRepository = CursoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Cursos = await _cursoRepository.ListAsync();
            return Ok(Cursos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var Curso = await _cursoRepository.FindAsync(id);
            return Ok(Curso);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Curso entity)
        {
            var id = await _cursoRepository.AddAsync(entity);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Curso Curso, [FromRoute] int id)
        {
            await _cursoRepository.AtualizarAsync(Curso, id);
            return Ok(Curso);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelAsync([FromRoute] int id)
        {
            await _cursoRepository.DeleteAsync(id);
            return Ok(id);
        }
    }
}
