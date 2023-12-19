using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_Final_Curs_C_.Models;

namespace Proiect_Final_Curs_C_.Controllers
{
    public class ToDo_Controller : Controller
    {
        private readonly BazaDate _context;

        public ToDo_Controller(BazaDate context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var todoItems = _context.TodoItems.ToList();
            return View(todoItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDo_Items todoItem)
        {
            if (ModelState.IsValid)
            {
                _context.TodoItems.Add(todoItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todoItem = _context.TodoItems.Find(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        [HttpPut]
        public IActionResult Edit(ToDo_Items todoItem)
        {
            if (ModelState.IsValid)
            {
                _context.TodoItems.Update(todoItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var todoItem = _context.TodoItems.Find(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
