using System;
using System.Collections.Generic;
using System.Linq;
using KDOS.Service.Interface;
using KDOS.Repository;
using KDOS.Repository.Models;

namespace KDOS.Service.Implement
{
    public class IplDichVuVanChuyenSer : IDichVuVanChuyenSer
    {
        private readonly IBase _baseDAL;

        public IplDichVuVanChuyenSer(IBase baseDAL)
        {
            _baseDAL = baseDAL;
        }

        // Insert new DichVuVanChuyen
        public bool Insert(DichVuVanChuyen dichVuVanChuyen)
        {
            try
            {
                _baseDAL.dichVuvanchuyenrepository.Insert(dichVuVanChuyen);
                _baseDAL.dichVuvanchuyenrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Update existing DichVuVanChuyen
        public bool Update(DichVuVanChuyen dichVuVanChuyen)
        {
            try
            {
                _baseDAL.dichVuvanchuyenrepository.Update(dichVuVanChuyen);
                _baseDAL.dichVuvanchuyenrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Delete DichVuVanChuyen by MaVanChuyen
        public bool Delete(string maVanChuyen)
        {
            try
            {
                _baseDAL.dichVuvanchuyenrepository.Delete(maVanChuyen);
                _baseDAL.dichVuvanchuyenrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Get DichVuVanChuyen by MaVanChuyen
        public DichVuVanChuyen GetById(string maVanChuyen)
        {
            try
            {
                var dichVuVanChuyen = _baseDAL.dichVuvanchuyenrepository.GetById(maVanChuyen);  // Get DichVuVanChuyen by MaVanChuyen
                return dichVuVanChuyen;
            }
            catch (Exception)
            {
                return null;  // Return null if error occurs
            }
        }

        // Get all DichVuVanChuyen with optional search filter
        public List<DichVuVanChuyen> GetAll(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _baseDAL.dichVuvanchuyenrepository.Get(x => x.TenVanChuyen.Contains(search)).ToList();  // Filter by TenVanChuyen
            }
            else
            {
                return _baseDAL.dichVuvanchuyenrepository.Get().ToList();  // Return all if no filter is provided
            }
        }

        // Get list of DichVuVanChuyen with paging and optional search keyword
        public List<DichVuVanChuyen> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10)
        {
            try
            {
                return _baseDAL.dichVuvanchuyenrepository.GetListAllPaging(keywork, offset, limit);
            }
            catch (Exception)
            {
                return new List<DichVuVanChuyen>();  // Return empty list if error occurs
            }
        }
    }
}
