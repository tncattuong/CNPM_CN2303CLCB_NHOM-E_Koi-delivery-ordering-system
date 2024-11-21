using System;
using System.Collections.Generic;
using System.Linq;
using KDOS.Service.Interface;
using KDOS.Repository;
using KDOS.Repository.Models;

namespace KDOS.Service.Implement
{
    public class IplKhachHangSer : IKhachHangSer
    {
        private readonly IBase _baseDAL;

        public IplKhachHangSer(IBase baseDAL)
        {
            _baseDAL = baseDAL;
        }

        // Insert new KhachHang
        public bool Insert(KhachHang khachHang)
        {
            try
            {
                _baseDAL.khachHangrepository.Insert(khachHang);
                _baseDAL.khachHangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Update existing KhachHang
        public bool Update(KhachHang khachHang)
        {
            try
            {
                _baseDAL.khachHangrepository.Update(khachHang);
                _baseDAL.khachHangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Delete KhachHang by MaKhach
        public bool Delete(string maKhach)
        {
            try
            {
                _baseDAL.khachHangrepository.Delete(maKhach);
                _baseDAL.khachHangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Get KhachHang by MaKhach
        public KhachHang GetById(string maKhach)
        {
            try
            {
                var khachHang = _baseDAL.khachHangrepository.GetById(maKhach);  // Get KhachHang by MaKhach
                return khachHang;
            }
            catch (Exception)
            {
                return null;  // Return null if error occurs
            }
        }

        // Get all KhachHang with optional search filter
        public List<KhachHang> GetAll(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _baseDAL.khachHangrepository.Get(x => x.MaKhach.Contains(search) || x.TenKhach.Contains(search)).ToList();  // Filter by MaKhach or TenKhach
            }
            else
            {
                return _baseDAL.khachHangrepository.Get().ToList();  // Return all if no filter is provided
            }
        }

        // Get list of KhachHang with paging and optional search keyword
        public List<KhachHang> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                return _baseDAL.khachHangrepository.GetListAllPaging(keyword, offset, limit);
            }
            catch (Exception)
            {
                return new List<KhachHang>();  // Return empty list if error occurs
            }
        }
    }
}
