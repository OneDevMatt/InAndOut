using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpensesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var objList = _dbContext.Expenses;
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
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            { 
                _dbContext.Expenses.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        //Post-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var item = _dbContext.Expenses.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _dbContext.Expenses.Remove(item);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _dbContext.Expenses.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //Get-Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _dbContext.Expenses.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //Post-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Expenses.Update(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }

}
