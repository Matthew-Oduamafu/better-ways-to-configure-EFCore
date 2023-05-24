using Better.Way.To.Configure.EFCore.Data;
using Better.Way.To.Configure.EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Better.Way.To.Configure.EFCore.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CarsController : Controller
{
    private readonly EfCoreDbContext _context;

    public CarsController(EfCoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        return Ok(await _context.Cars.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddCar(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
        await _context.DisposeAsync();
        return Ok();
    }
}