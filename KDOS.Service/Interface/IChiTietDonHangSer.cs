using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Models;


namespace KDOS.Service.Interface
{
    public interface IChiTietDonHangSer
    {
        List<ChiTietDonHang> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10);
        List<ChiTietDonHang> GetAll(string search = null);
        bool Insert(ChiTietDonHang chiTietDonHang);
        bool Update(ChiTietDonHang chiTietDonHang);
        bool Delete(int MaCtDonHang);
        ChiTietDonHang GetById(int MaCtDonHang);
    }
}
