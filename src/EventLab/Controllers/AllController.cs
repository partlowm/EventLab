using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventLab.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using EventLab.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EventLab.Controllers
{
    [Authorize]
    public class AllController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public AllController(ApplicationDbContext context)
        {
            _context = context;
           

        }
        [Authorize]
        // GET: /<controller>/
        public IActionResult Index()
        {
            var theEvent = _context.Event;
            return View(theEvent.ToList());
        }
    }

}
