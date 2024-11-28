using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using KDOS.Repository.Models;

namespace KDOS.Web.Controllers
{
 
    public class DonHangController : Controller
    {
        private readonly KingKoiContext _context;

        public DonHangController(KingKoiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var donHangList = _context.DonHangs.ToList();
            return View(donHangList);
        }

        public IActionResult AddOrEdit(int? id)
        {
            if (!id.HasValue)
                return View(new DonHang());

            var donHang = _context.DonHangs.FirstOrDefault(d => d.MaDonHang == id);
            if (donHang == null)
                return NotFound();

            return View(donHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                if (donHang.MaDonHang == 0)
                    _context.DonHangs.Add(donHang);
                else
                    _context.DonHangs.Update(donHang);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(donHang);
        }

        public IActionResult Delete(int id)
        {
            var donHang = _context.DonHangs.FirstOrDefault(d => d.MaDonHang == id);
            if (donHang == null)
                return NotFound();

            _context.DonHangs.Remove(donHang);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
