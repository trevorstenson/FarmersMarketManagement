using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmProject.Controllers
{
    public class VendorController : Controller
    {

        private readonly FarmersdbContext _context;

        public VendorController(FarmersdbContext context)
        {
            _context = context;
        }

        //gets the Vendor object with the given id
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetById(int id)
        {
            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return vendor;
        }

        //creates a new Vendor object in the database
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vendor vendor)
        {
            _context.Vendor.Add(vendor);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        //deletes the Vendor object with the given id
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

        //updates the product categories sold by the given Vendor
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductCategories(int id, [FromBody] List<int> categories)
        {
            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            
            var sellsList = _context.Sells.Where(s => s.VendorId == id);
            foreach (Sells s in sellsList)
            {
                if (categories.Contains(s.CategoryId))
                {
                    categories.Remove(s.CategoryId);
                }
                else
                {
                    _context.Sells.Remove(s);
                }
            }

            foreach (int i in categories)
            {
                _context.Sells.Add(new Sells
                {
                    CategoryId = i,
                    VendorId = id
                });
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}