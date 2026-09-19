using ApiVazada.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVazada.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProdutosController(AppDbContext db) => _db = db;

    [HttpGet]
    public IActionResult GetAll() => Ok(_db.Produtos.ToList());

    [HttpGet("buscar")]
    public IActionResult Buscar(string nome)
    {
        var resultado = _db.Produtos
            .Where(p => p.Nome.Contains(nome))
            .ToList();

        return Ok(resultado);
    }
}
