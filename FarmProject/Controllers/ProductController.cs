using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly FarmersdbContext _context;

        public ProductController(FarmersdbContext context)
        {
            _context = context;
        }

        //gets all existing product categories
        [HttpGet]
        public ActionResult<List<Productcategory>> GetCategories()
        {
            return _context.Productcategory.ToList();
        }

        //gets the product categories sold by a given vendor id
        [HttpGet("{id}")]
        public ActionResult<List<Productcategory>> GetProductsByVendor(int id)
        {
            var categories = 
                from p in _context.Productcategory
                join s in _context.Sells 
                    on p.CategoryId equals s.CategoryId
                where s.VendorId == id
                select p;
            return categories.ToList();
        }
    }
}