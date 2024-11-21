using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Base;
using KDOS.Repository.Models;

namespace KDOS.Repository.Interface
{
    public interface IPhanHoiRepository : IGenericRepository<PhanHoi>
    {
        // Phương thức lấy danh sách phản hồi với phân trang và tìm kiếm theo từ khóa
        List<PhanHoi> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);

        // Phương thức lấy phản hồi theo mã phản hồi
        PhanHoi GetByMaPhanHoi(int maPhanHoi);

        // Phương thức thêm mới phản hồi
        bool Add(PhanHoi phanHoi);

        // Phương thức cập nhật thông tin phản hồi
        bool Update(PhanHoi phanHoi);

        // Phương thức xóa phản hồi
        bool Delete(int maPhanHoi);
        void SaveChanges();
    }
}
