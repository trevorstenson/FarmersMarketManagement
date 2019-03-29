using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FarmProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : Controller
    {

        private readonly FarmersdbContext _context;

        public VendorController(FarmersdbContext context)
        {
            _context = context;
        }

        /*
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
        */

        //gets all vendors for a specific market
        [HttpGet("{id}")]
        public ActionResult<List<Vendor>> GetByMarket(int id)
        {
            var result = _context.Vendor.FromSql("CALL get_vendors({0})", id).ToList();
            return result;
        }

        //creates a new Vendor object in the database
        [HttpPost]
        public IActionResult Create([FromBody] Vendor vendor)
        {
            _context.Vendor.FromSql("CALL add_vendor({0}, {1}, {2})", vendor.Name, vendor.Stallcount, vendor.FarmId);
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
        public IActionResult UpdateProductCategories(int id, [FromBody] string categories)
        {
            var datalist = JsonConvert.DeserializeObject<List<int>>(categories);
            
            _context.Sells.FromSql("DELETE FROM sells WHERE vendorID = {0}", id);

            foreach (int item in datalist)
            {
               _context.Sells.FromSql("CALL update_sells({0}, {1})", id, item);
            }
            
            
            return StatusCode(200);
        }
    }
}