using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Base;
using KDOS.Repository.Models;

namespace KDOS.Repository.Interface
{
    public interface IDonHangRepository : IGenericRepository<DonHang>
    {
        // Lấy danh sách đơn hàng với phân trang và từ khóa tìm kiếm
        List<DonHang> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);

        // Thêm đơn hàng
        bool Add(DonHang donHang);

        // Cập nhật đơn hàng
        bool Update(DonHang donHang);

        // Xóa đơn hàng theo mã đơn hàng
        bool Delete(int maDonHang);
        void SaveChanges();
    }
}
