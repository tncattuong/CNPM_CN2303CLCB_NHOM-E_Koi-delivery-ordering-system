using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Models;


namespace KDOS.Service.Interface
{
    public interface IDonHangSer
    {
        List<DonHang> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10);
        List<DonHang> GetAll(string search = null);
        bool Insert(DonHang donHang);
        bool Update(DonHang donHang);
        bool Delete(int maDonHang);
        DonHang GetById(int maDonHang);
    }
}
