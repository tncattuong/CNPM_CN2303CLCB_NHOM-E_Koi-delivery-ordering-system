using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Base;
using KDOS.Repository.Models;

namespace KDOS.Repository.Interface
{
    public interface INhanVienRepository : IGenericRepository<NhanVien>
    {
        // Lấy danh sách nhân viên với phân trang và từ khóa tìm kiếm
        List<NhanVien> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);

        // Tìm kiếm nhân viên theo mã
        NhanVien GetByMaNhanVien(string maNhanVien);

        // Thêm nhân viên mới
        bool Add(NhanVien nhanVien);

        // Cập nhật thông tin nhân viên
        bool Update(NhanVien nhanVien);

        // Xóa nhân viên theo mã nhân viên
        bool Delete(string maNhanVien);
        void SaveChanges();
    }
}
