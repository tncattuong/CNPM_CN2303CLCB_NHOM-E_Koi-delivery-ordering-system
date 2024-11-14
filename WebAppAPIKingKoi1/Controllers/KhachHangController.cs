using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAPIKingKoi1.MyModels;

namespace WebAppAPIKingKoi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        KetNoiCSDL dbc;
        public KhachHangController(KetNoiCSDL dbc_in)
        {
            dbc = dbc_in;
        }
        [HttpGet]
        [Route("GetList")]
        public ActionResult Read()
        {
            return Ok(new { data = dbc.KhachHangs.ToList() });//table
        }

        [HttpPost]
        [Route("Seach")]
        public ActionResult Timiem(string s)
        {
            return Ok(new
            {
                data = dbc.KhachHangs.Where(
                    item => item.MaKhach.Contains(s) ||
                    item.TenKhach.Contains(s) ||
                    (item.GioiTinhKhach.HasValue && item.GioiTinhKhach.Value.ToString().Contains(s)) // Adjusted for GioiTinhKhach
                ).ToList()
            });
        }


    }
}
