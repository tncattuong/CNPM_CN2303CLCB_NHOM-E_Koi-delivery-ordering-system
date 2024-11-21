using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Base;
using KDOS.Repository.Models;

namespace KDOS.Repository.Interface
{
    public interface IDichVuVanChuyenRepository : IGenericRepository<DichVuVanChuyen>
    {
        // Lấy danh sách dịch vụ vận chuyển với phân trang và từ khóa tìm kiếm
        List<DichVuVanChuyen> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);

        // Thêm dịch vụ vận chuyển
        bool Add(DichVuVanChuyen dichVu);

        // Cập nhật dịch vụ vận chuyển
        bool Update(DichVuVanChuyen dichVu);

        // Xóa dịch vụ vận chuyển theo mã vận chuyển
        bool Delete(string maVanChuyen);
        void SaveChanges();
    }
}
