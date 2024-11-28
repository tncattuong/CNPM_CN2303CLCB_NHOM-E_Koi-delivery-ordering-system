using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using KDOS.Repository.Models;

namespace KDOS.Web.Controllers
{
    public class CaKoiController : Controller
    {
        private readonly KingKoiContext _context;

        public CaKoiController(KingKoiContext context)
        {
            _context = context;
        }

        // Action hiển thị danh sách các cá koi
        public IActionResult Index()
        {
            var caKoiList = _context.CaKois.ToList();
            return View(caKoiList);
        }

        // Action thêm hoặc chỉnh sửa thông tin cá koi
        public IActionResult AddOrEdit(string id)
        {
            // Nếu là thêm mới, khởi tạo đối tượng rỗng
            if (string.IsNullOrEmpty(id))
            {
                return View(new CaKoi());
            }

            // Nếu là chỉnh sửa, lấy cá koi theo MaCa
            var caKoi = _context.CaKois.FirstOrDefault(c => c.MaCa == id);
            if (caKoi == null)
            {
                return NotFound();
            }

            return View(caKoi);
        }

        // Action lưu thông tin cá koi sau khi thêm hoặc chỉnh sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(CaKoi caKoi)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(caKoi.MaCa))
                {
                    // Thêm mới
                    _context.CaKois.Add(caKoi);
                }
                else
                {
                    // Chỉnh sửa
                    _context.CaKois.Update(caKoi);
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(caKoi);
        }

        // Action xóa cá koi
        public IActionResult Delete(string id)
        {
            var caKoi = _context.CaKois.FirstOrDefault(c => c.MaCa == id);
            if (caKoi == null)
            {
                return NotFound();
            }

            _context.CaKois.Remove(caKoi);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
