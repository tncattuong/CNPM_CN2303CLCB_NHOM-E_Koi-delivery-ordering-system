using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Base;
using KDOS.Repository.Models;

namespace KDOS.Repository.Interface
{
    public interface ICaKoiRepository : IGenericRepository<CaKoi>
    {
        // Lấy danh sách CaKoi với phân trang và từ khóa tìm kiếm
        List<CaKoi> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);

        // Thêm cá koi
        bool Add(CaKoi caKoi);

        // Cập nhật cá koi
        bool Update(CaKoi caKoi);

        // Xóa cá koi theo MaCa
        bool Delete(string maCa);
        void SaveChanges();
    }
}
