using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using KDOS.Repository.Models;

namespace KDOS.Web.Controllers
{
    public class DichVuVanChuyenController : Controller
    {
        private readonly KingKoiContext _context;

        public DichVuVanChuyenController(KingKoiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dichVuList = _context.DichVuVanChuyens.ToList();
            return View(dichVuList);
        }

        public IActionResult AddOrEdit(int? id)
        {
            if (!id.HasValue)
                return View(new DichVuVanChuyen());

            var dichVu = _context.DichVuVanChuyens.FirstOrDefault(d => d.MaVanChuyen == null);
            if (dichVu == null)
                return NotFound();

            return View(dichVu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(DichVuVanChuyen dichVu)
        {
            if (ModelState.IsValid)
            {
                if (dichVu.MaVanChuyen == null)
                    _context.DichVuVanChuyens.Add(dichVu);
                else
                    _context.DichVuVanChuyens.Update(dichVu);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(dichVu);
        }

        public IActionResult Delete(int id)
        {
            var dichVu = _context.DichVuVanChuyens.FirstOrDefault(d => d.MaVanChuyen == null);
            if (dichVu == null)
                return NotFound();

            _context.DichVuVanChuyens.Remove(dichVu);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
