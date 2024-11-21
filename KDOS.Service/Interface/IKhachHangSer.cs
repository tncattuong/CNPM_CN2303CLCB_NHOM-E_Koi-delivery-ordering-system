using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Models;


namespace KDOS.Service.Interface
{
    public interface IKhachHangSer
    {
        List<KhachHang> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);
        List<KhachHang> GetAll(string search = null);
        bool Insert(KhachHang khachHang);
        bool Update(KhachHang khachHang);
        bool Delete(string maKhach);
        KhachHang GetById(string maKhach);
    }
}
