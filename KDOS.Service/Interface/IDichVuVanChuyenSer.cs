using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Models;


namespace KDOS.Service.Interface
{
    public interface IDichVuVanChuyenSer
    {
        List<DichVuVanChuyen> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10);
        List<DichVuVanChuyen> GetAll(string search = null);
        bool Insert(DichVuVanChuyen dichVuVanChuyen);
        bool Update(DichVuVanChuyen dichVuVanChuyen);
        bool Delete(string maVanChuyen);
        DichVuVanChuyen GetById(string maVanChuyen);
    }
}
