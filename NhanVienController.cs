using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using KDOS.Repository.Models;

namespace KDOS.Web.Controllers
{
   
    public class NhanVienController : Controller
    {
        private readonly KingKoiContext _context;

        public NhanVienController(KingKoiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var nhanVienList = _context.NhanViens.ToList();
            return View(nhanVienList);
        }

        public IActionResult AddOrEdit(int? id)
        {
            if (!id.HasValue)
                return View(new NhanVien());

            var nhanVien = _context.NhanViens.FirstOrDefault(n => n.MaNhanVien == null);
            if (nhanVien == null)
                return NotFound();

            return View(nhanVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                if (nhanVien.MaNhanVien == null)
                    _context.NhanViens.Add(nhanVien);
                else
                    _context.NhanViens.Update(nhanVien);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        public IActionResult Delete(int id)
        {
            var nhanVien = _context.NhanViens.FirstOrDefault(n => n.MaNhanVien == null);
            if (nhanVien == null)
                return NotFound();

            _context.NhanViens.Remove(nhanVien);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
