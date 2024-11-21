using System;
using System.Collections.Generic;
using System.Linq;
using KDOS.Service.Interface;
using KDOS.Repository;
using KDOS.Repository.Models;

namespace KDOS.Service.Implement
{
    public class IplPhanHoiSer : IPhanHoiSer
    {
        private readonly IBase _baseDAL;

        public IplPhanHoiSer(IBase baseDAL)
        {
            _baseDAL = baseDAL;
        }

        // Insert new PhanHoi
        public bool Insert(PhanHoi phanHoi)
        {
            try
            {
                _baseDAL.phanHoirepository.Insert(phanHoi);
                _baseDAL.phanHoirepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Update existing PhanHoi
        public bool Update(PhanHoi phanHoi)
        {
            try
            {
                _baseDAL.phanHoirepository.Update(phanHoi);
                _baseDAL.phanHoirepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Delete PhanHoi by MaPhanHoi
        public bool Delete(int maPhanHoi)
        {
            try
            {
                _baseDAL.phanHoirepository.Delete(maPhanHoi);
                _baseDAL.phanHoirepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Get PhanHoi by MaPhanHoi
        public PhanHoi GetById(int maPhanHoi)
        {
            try
            {
                var phanHoi = _baseDAL.phanHoirepository.GetById(maPhanHoi);  // Get PhanHoi by MaPhanHoi
                return phanHoi;
            }
            catch (Exception)
            {
                return null;  // Return null if error occurs
            }
        }

        // Get all PhanHoi with optional search filter
        public List<PhanHoi> GetAll(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _baseDAL.phanHoirepository.Get(x => x.MaKhach.Contains(search) || x.NoiDung.Contains(search)).ToList();  // Filter by MaKhach or NoiDung
            }
            else
            {
                return _baseDAL.phanHoirepository.Get().ToList();  // Return all if no filter is provided
            }
        }

        // Get list of PhanHoi with paging and optional search keyword
        public List<PhanHoi> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                return _baseDAL.phanHoirepository.GetListAllPaging(keyword, offset, limit);
            }
            catch (Exception)
            {
                return new List<PhanHoi>();  // Return empty list if error occurs
            }
        }
    }
}
