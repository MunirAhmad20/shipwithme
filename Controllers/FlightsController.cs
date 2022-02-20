using Microsoft.AspNetCore.Mvc;
using shipwithme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipwithme.Controllers
{
    public class FlightsController : Controller
    {
        private readonly AppDBContext _context;
        public FlightsController(AppDBContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var list = _context.Flight.ToList();
           
            return View(list);
           
        }
    }
}
