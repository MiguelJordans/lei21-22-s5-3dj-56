using GestArm.Domain.Armazens;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArmazemController : ControllerBase
{
    private readonly IArmazemService _service;

    public ArmazemController(IArmazemService service)
    {
        _service = service;
    }

    // GET: api/Armazem/id
    [HttpGet("{id}")]
    public async Task<ActionResult<ArmazemDTO>> GetById(Guid id)
    {
        var armazem = await _service.GetByIdAsync(new ArmazemId(id));

        if (armazem == null) return NotFound();

        return armazem;
    }

    // GET: api/Armazens
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArmazemDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    //POST: api/Armazem
    [HttpPost]
    public async Task<ActionResult<ArmazemDTO>> AddAsync(CreatingArmazemDto dto)
    {
        var armazem = await _service.AddAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = armazem.Id }, armazem);
    }

    //DELETE: api/Armazem
    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteAsync(ArmazemDTO armazemDTO)
    {
        var armazem = await _service.RemoveAsync(armazemDTO.Id);

        return true;
    }
}