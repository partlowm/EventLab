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
    public class CreateController : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public CreateController(ApplicationDbContext context)
        {
            _context = context;
           
        }
        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            var theEvent = _context.Event;
            return View(theEvent.ToList());
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Event theEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Event.Add(theEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theEvent);
        }

        [Authorize]
        public IActionResult Cancel(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Event theEvent = _context.Event.SingleOrDefault(a => a.EventID == id);
            if (theEvent == null)
            {
                return NotFound();
            }
            return View(theEvent);

        }

        [Authorize]
        [HttpPost]
        public IActionResult Cancel(int id)
        {
            Event theEvent = _context.Event.SingleOrDefault(a => a.EventID == id);
            _context.Event.Remove(theEvent);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize]
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Event theEvent = _context.Event.SingleOrDefault(a => a.EventID == id);
            if (theEvent == null)
            {
                return NotFound();
            }
            ViewBag.AlbumsList = _context.Event.Where(a => a.EventID == theEvent.EventID);
            return View(theEvent);

        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Event theEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Event.Update(theEvent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theEvent);
        }
    }

}
