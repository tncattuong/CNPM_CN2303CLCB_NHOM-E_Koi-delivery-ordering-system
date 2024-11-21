using System;
using System.Collections.Generic;
using KDOS.Repository.Models;

namespace KDOS.Service.Interface
{
    public interface IBangGiaSer
    {
        List<BangGia> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10);
        List<BangGia> GetAll(string search = null);
        bool Insert(BangGia banggia);
        bool Update(BangGia banggia);
        bool Delete(int MaGia);
        BangGia GetById(int MaGia);
    }
}
