using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using KDOS.Repository.Models;

namespace KDOS.Web.Controllers
{
    public class BangGiaController : Controller
    {
        private readonly KingKoiContext _context;

        public BangGiaController(KingKoiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bangGiaList = _context.BangGias.ToList();
            return View(bangGiaList);
        }

        public IActionResult AddOrEdit(int? id)
        {
            if (!id.HasValue)
                return View(new BangGia());

            var bangGia = _context.BangGias.FirstOrDefault(b => b.MaGia == id);
            if (bangGia == null)
                return NotFound();

            return View(bangGia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(BangGia bangGia)
        {
            if (ModelState.IsValid)
            {
                if (bangGia.MaGia == 0)
                    _context.BangGias.Add(bangGia);
                else
                    _context.BangGias.Update(bangGia);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(bangGia);
        }

        public IActionResult Delete(int id)
        {
            var bangGia = _context.BangGias.FirstOrDefault(b => b.MaGia == id);
            if (bangGia == null)
                return NotFound();

            _context.BangGias.Remove(bangGia);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
