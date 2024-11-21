using Microsoft.AspNetCore.Mvc;
using KDOS.Repository.Models;

namespace KDOS.Web.Controllers
{
    public class ChiTietDonHangController : Controller
    {
        private readonly KingKoiContext _context;

        public ChiTietDonHangController(KingKoiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var chiTietDonHangList = _context.ChiTietDonHangs.ToList();
            return View(chiTietDonHangList);
        }

        public IActionResult AddOrEdit(int? id)
        {
            if (!id.HasValue)
                return View(new ChiTietDonHang());

            var chiTietDonHang = _context.ChiTietDonHangs.FirstOrDefault(c => c.MaCtDonHang == id);
            if (chiTietDonHang == null)
                return NotFound();

            return View(chiTietDonHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                if (chiTietDonHang.MaCtDonHang == 0)
                    _context.ChiTietDonHangs.Add(chiTietDonHang);
                else
                    _context.ChiTietDonHangs.Update(chiTietDonHang);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(chiTietDonHang);
        }

        public IActionResult Delete(int id)
        {
            var chiTietDonHang = _context.ChiTietDonHangs.FirstOrDefault(c => c.MaCtDonHang == id);
            if (chiTietDonHang == null)
                return NotFound();

            _context.ChiTietDonHangs.Remove(chiTietDonHang);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
