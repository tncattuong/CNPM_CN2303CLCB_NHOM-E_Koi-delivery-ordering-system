using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using KDOS.Repository.Models;

namespace KDOS.Web.Controllers
{
    
    public class KhachHangController : Controller
    {
        private readonly KingKoiContext _context;

        public KhachHangController(KingKoiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var khachHangList = _context.KhachHangs.ToList();
            return View(khachHangList);
        }

        public IActionResult AddOrEdit(int? id)
        {
            if (!id.HasValue)
                return View(new KhachHang());

            var khachHang = _context.KhachHangs.FirstOrDefault(k => k.MaKhach == null);
            if (khachHang == null)
                return NotFound();

            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                if (khachHang.MaKhach == null)
                    _context.KhachHangs.Add(khachHang);
                else
                    _context.KhachHangs.Update(khachHang);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }

        public IActionResult Delete(int id)
        {
            var khachHang = _context.KhachHangs.FirstOrDefault(k => k.MaKhach == null);
            if (khachHang == null)
                return NotFound();

            _context.KhachHangs.Remove(khachHang);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
