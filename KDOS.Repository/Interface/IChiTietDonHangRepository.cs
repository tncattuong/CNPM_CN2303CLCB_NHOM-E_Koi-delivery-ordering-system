using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Base;
using KDOS.Repository.Models;

namespace KDOS.Repository.Interface
{
    public interface IChiTietDonHangRepository : IGenericRepository<ChiTietDonHang>
    {
        // Lấy danh sách ChiTietDonHang với phân trang và từ khóa tìm kiếm
        List<ChiTietDonHang> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);

        // Thêm chi tiết đơn hàng
        bool Add(ChiTietDonHang chiTietDonHang);

        // Cập nhật chi tiết đơn hàng
        bool Update(ChiTietDonHang chiTietDonHang);

        // Xóa chi tiết đơn hàng theo MaCtDonHang
        bool Delete(int maChiTiet);
        void SaveChanges();
    }
}
