using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var objList = _context.Items;
            return View(objList);
        }
        //Get-Create
        public IActionResult Create()
        {
            return View();
        }
        //Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _context.Items.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
