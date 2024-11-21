using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Base;
using KDOS.Repository.Models;

namespace KDOS.Repository.Interface
{
    public interface IKhachHangRepository : IGenericRepository<KhachHang>
    {
        // Lấy danh sách khách hàng với phân trang và từ khóa tìm kiếm
        List<KhachHang> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);

        // Tìm khách hàng theo mã khách
        KhachHang GetByMaKhach(string maKhach);

        // Thêm khách hàng
        void Add(KhachHang khachHang);

        // Cập nhật thông tin khách hàng
        void Update(KhachHang khachHang);

        // Xóa khách hàng theo mã khách
        void Delete(string maKhach);
        void SaveChanges();
    }
}
