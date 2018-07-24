using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyHomeProject.Models;

namespace MyHomeProject.Controllers
{
    public class DishesController : Controller
    {
        private readonly MyHomeProjectContext _context;

        public DishesController(MyHomeProjectContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }






        // GET: Dishes/Details/5
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var Dish = await _context.Dishes
            .SingleOrDefaultAsync(m => m.DishID == id); ;


             List<Dish> list =_context.Dishes.Include(di => di.Dish_Ingridients).ThenInclude(i => i.Ingridient).ToList() ;
       

            return View(Dish);
                        
        }

        [Authorize]
        public async Task<IActionResult> Index(string dishCategory, string searchString)
        {
         
            IQueryable<string> categoryQuery = from m in _context.Dishes
                                            orderby m.Category
                                            select m.Category;

            var dishes = from m in _context.Dishes
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(s => s.Title.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(dishCategory))
            {
                dishes = dishes.Where(x => x.Category == dishCategory);
            }

            var dishCategoryVM = new DishSectionViewModel();
            dishCategoryVM.category = new SelectList(await categoryQuery.Distinct().ToListAsync());
            dishCategoryVM.dishes = await dishes.ToListAsync();
            return View(dishCategoryVM);
        }

        // GET: Dishes/Create
        public IActionResult Create()
        {
            ViewBag.DI = _context.Ingridients.ToList(); 
            return View();
        }

        // POST: Dishes/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DishID,Title,Recipe,Category")] Dish dish, int[] selectedIngridients)
        {
            if (ModelState.IsValid)
            {
                _context.Dishes.Add(dish);
                foreach(var m in selectedIngridients)
                {
                    _context.Dish_Ingridents.Add(new Dish_Ingrident { Dish = dish, Ingridient = _context.Ingridients.Find(m) });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        // GET: Dishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.SingleOrDefaultAsync(m => m.DishID == id);
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }

        // POST: Dishes/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DishID,Title,Recipe,Category")] Dish dish)
        {
            if (id != dish.DishID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.DishID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        // GET: Dishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .SingleOrDefaultAsync(m => m.DishID == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dish = await _context.Dishes.SingleOrDefaultAsync(m => m.DishID == id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.DishID == id);
        }
    }
}
