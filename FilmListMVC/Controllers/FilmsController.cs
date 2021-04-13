using FilmListMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmListMVC.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Film Film { get; set; }

        public FilmsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Film = new Film();
            if(id==null)
            {
                //create
                return View(Film);
            }
            //update
            Film = _db.Films.FirstOrDefault(u => u.Id == id); 
            if(Film==null)
            {
                return NotFound();
            }
            return View(Film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if(Film.Id==0)
                {
                    //create
                    _db.Films.Add(Film);
                }
                else
                {
                    //update
                    _db.Films.Update(Film);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Film);
        }
        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dat = await _db.Films.ToListAsync();
            return Json(new { data = dat });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var filmFromDb = await _db.Films.FirstOrDefaultAsync(u => u.Id == id);
            if (filmFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Films.Remove(filmFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
