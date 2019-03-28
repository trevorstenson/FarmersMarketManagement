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
    public class MarketController : Controller
    {

        private readonly FarmersdbContext _context;

        public MarketController(FarmersdbContext context)
        {
            _context = context;
        }

        //gets all markets
        [HttpGet]
        public ActionResult<List<Market>> getAllFarms()
        {
            return _context.Market.ToList();
        }

        //gets all markets in a given state
        [HttpGet("{state}")]
        public ActionResult<List<Market>> GetByState(string state)
        { 
            var query = from m in _context.Market
                        where m.State == state
                        select m;

            return query.ToList();
        }
    }
}