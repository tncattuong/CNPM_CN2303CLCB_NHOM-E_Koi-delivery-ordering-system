using System;
using System.Collections.Generic;
using System.Linq;
using KDOS.Service.Interface;
using KDOS.Repository;
using KDOS.Repository.Models;

namespace KDOS.Service.Implement
{
    public class IplNhanVienSer : INhanVienSer
    {
        private readonly IBase _baseDAL;

        public IplNhanVienSer(IBase baseDAL)
        {
            _baseDAL = baseDAL;
        }

        // Insert new NhanVien
        public bool Insert(NhanVien nhanVien)
        {
            try
            {
                _baseDAL.nhanVienrepository.Insert(nhanVien);
                _baseDAL.nhanVienrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Update existing NhanVien
        public bool Update(NhanVien nhanVien)
        {
            try
            {
                _baseDAL.nhanVienrepository.Update(nhanVien);
                _baseDAL.nhanVienrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Delete NhanVien by MaNhanVien
        public bool Delete(string maNhanVien)
        {
            try
            {
                _baseDAL.nhanVienrepository.Delete(maNhanVien);
                _baseDAL.nhanVienrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Get NhanVien by MaNhanVien
        public NhanVien GetById(string maNhanVien)
        {
            try
            {
                var nhanVien = _baseDAL.nhanVienrepository.GetById(maNhanVien);  // Get NhanVien by MaNhanVien
                return nhanVien;
            }
            catch (Exception)
            {
                return null;  // Return null if error occurs
            }
        }

        // Get all NhanVien with optional search filter
        public List<NhanVien> GetAll(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _baseDAL.nhanVienrepository.Get(x => x.MaNhanVien.Contains(search) || x.HoTen.Contains(search)).ToList();  // Filter by MaNhanVien or HoTen
            }
            else
            {
                return _baseDAL.nhanVienrepository.Get().ToList();  // Return all if no filter is provided
            }
        }

        // Get list of NhanVien with paging and optional search keyword
        public List<NhanVien> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                return _baseDAL.nhanVienrepository.GetListAllPaging(keyword, offset, limit);
            }
            catch (Exception)
            {
                return new List<NhanVien>();  // Return empty list if error occurs
            }
        }
    }
}
