using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using KDOS.Repository.Models;

namespace KDOS.Web.Controllers
{
   
    public class PhanHoiController : Controller
    {
        private readonly KingKoiContext _context;

        public PhanHoiController(KingKoiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var phanHoiList = _context.PhanHois.ToList();
            return View(phanHoiList);
        }

        public IActionResult AddOrEdit(int? id)
        {
            if (!id.HasValue)
                return View(new PhanHoi());

            var phanHoi = _context.PhanHois.FirstOrDefault(p => p.MaPhanHoi == id);
            if (phanHoi == null)
                return NotFound();

            return View(phanHoi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(PhanHoi phanHoi)
        {
            if (ModelState.IsValid)
            {
                if (phanHoi.MaPhanHoi == 0)
                    _context.PhanHois.Add(phanHoi);
                else
                    _context.PhanHois.Update(phanHoi);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(phanHoi);
        }

        public IActionResult Delete(int id)
        {
            var phanHoi = _context.PhanHois.FirstOrDefault(p => p.MaPhanHoi == id);
            if (phanHoi == null)
                return NotFound();

            _context.PhanHois.Remove(phanHoi);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
