using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Models;


namespace KDOS.Service.Interface
{
    public interface INhanVienSer
    {
        List<NhanVien> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);
        List<NhanVien> GetAll(string search = null);
        bool Insert(NhanVien nhanVien);
        bool Update(NhanVien nhanVien);
        bool Delete(string maNhanVien);
        NhanVien GetById(string maNhanVien);
    }
}
