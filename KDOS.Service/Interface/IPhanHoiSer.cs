using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Models;


namespace KDOS.Service.Interface
{
    public interface IPhanHoiSer
    {
        List<PhanHoi> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10);
        List<PhanHoi> GetAll(string search = null);
        bool Insert(PhanHoi phanHoi);
        bool Update(PhanHoi phanHoi);
        bool Delete(int maPhanHoi);
        PhanHoi GetById(int maPhanHoi);
    }
}
