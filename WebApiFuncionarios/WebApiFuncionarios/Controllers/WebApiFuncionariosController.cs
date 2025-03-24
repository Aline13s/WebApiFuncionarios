using Microsoft.AspNetCore.Mvc;
using WebApiFuncionarios.Interfaces;
using WebApiFuncionarios.Entities;

namespace WebApiFuncionarios.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase

{
    private readonly IFuncionarioService _funcionarioService;

    public FuncionariosController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var funcionarios = await _funcionarioService.GetFuncionariosAsync();
        return Ok(funcionarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorId(int id)
    {
        var funcionario = await _funcionarioService.GetFuncionarioByIdAsync(id);
        if (funcionario == null)
            return NotFound();

        return Ok(funcionario);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Funcionario funcionario)
    {
        await _funcionarioService.AddFuncionarioAsync(funcionario);
        return CreatedAtAction(nameof(GetPorId), new { id = funcionario.Id }, funcionario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Funcionario funcionario)
    {
        if (id != funcionario.Id)
            return BadRequest("IDs não coincidem.");

        await _funcionarioService.UpdateFuncionarioAsync(funcionario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _funcionarioService.DeleteFuncionarioAsync(id);
        return NoContent();
    }
}
