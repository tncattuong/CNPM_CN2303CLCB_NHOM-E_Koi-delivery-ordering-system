using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDOS.Repository.Models;

namespace KDOS.Service.Interface
{
    public interface ICaKoiSer
    {
        List<CaKoi> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10);
        List<CaKoi> GetAll(string search = null);
        bool Insert(CaKoi caKoi);
        bool Update(CaKoi caKoi);
        bool Delete(string MaCa);
        CaKoi GetById(string MaCa);
    }
}
