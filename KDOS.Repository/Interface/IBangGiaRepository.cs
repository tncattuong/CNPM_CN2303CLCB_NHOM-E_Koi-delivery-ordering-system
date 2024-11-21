using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Base;
using KDOS.Repository.Models;

namespace KDOS.Repository.Interface
{
    public interface IBangGiaRepository : IGenericRepository<BangGia> 
    {
        // Lấy danh sách BangGia với phân trang và từ khóa tìm kiếm
        List<BangGia> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);

        // Thêm bảng giá
        bool Add(BangGia bangGia);

        // Cập nhật bảng giá
        bool Update(BangGia bangGia);

        // Xóa bảng giá theo MaGia
        bool Delete(int maGia);
        void SaveChanges();
    }
}
