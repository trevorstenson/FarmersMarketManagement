using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : Controller
    {

        private readonly FarmersdbContext _context;

        public FarmController(FarmersdbContext context)
        {
            _context = context;
        }

        //get all farms
        [HttpGet]
        public ActionResult<List<Farm>> getAllFarms()
        {
            return _context.Farm.ToList();
        }

        //gets the Farm object with the given id
        [HttpGet("{id}")]
        public async Task<ActionResult<Farm>> GetById(int id)
        {
            var farm = await _context.Farm.FindAsync(id);
            if (farm == null)
            {
                return NotFound();
            }
            return farm;
        }

        //creates a new Farm object in the database
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Farm farm)
        {
            _context.Farm.Add(farm);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        //deletes the Farm object with the given id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var farm = await _context.Farm.FindAsync(id);
            if (farm == null)
            {
                return NotFound();
            }
            _context.Farm.Remove(farm);
            await _context.SaveChangesAsync();
            return StatusCode(202);
        }
    


    }
}