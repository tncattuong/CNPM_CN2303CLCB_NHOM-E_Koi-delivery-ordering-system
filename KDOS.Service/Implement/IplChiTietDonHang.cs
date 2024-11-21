using System;
using System.Collections.Generic;
using System.Linq;
using KDOS.Service.Interface;
using KDOS.Repository;
using KDOS.Repository.Models;

namespace KDOS.Service.Implement
{
    public class IplChiTietDonHangSer : IChiTietDonHangSer
    {
        private readonly IBase _baseDAL;

        public IplChiTietDonHangSer(IBase baseDAL)
        {
            _baseDAL = baseDAL;
        }

        // Insert new ChiTietDonHang
        public bool Insert(ChiTietDonHang chiTietDonHang)
        {
            try
            {
                _baseDAL.chiTietdonhangrepository.Insert(chiTietDonHang);
                _baseDAL.chiTietdonhangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Update existing ChiTietDonHang
        public bool Update(ChiTietDonHang chiTietDonHang)
        {
            try
            {
                _baseDAL.chiTietdonhangrepository.Update(chiTietDonHang);
                _baseDAL.chiTietdonhangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Delete ChiTietDonHang by MaCtDonHang
        public bool Delete(int maCtDonHang)
        {
            try
            {
                _baseDAL.chiTietdonhangrepository.Delete(maCtDonHang);
                _baseDAL.chiTietdonhangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Get ChiTietDonHang by MaCtDonHang
        public ChiTietDonHang GetById(int maCtDonHang)
        {
            try
            {
                var chiTietDonHang = _baseDAL.chiTietdonhangrepository.GetById(maCtDonHang);  // Get ChiTietDonHang by MaCtDonHang
                return chiTietDonHang;
            }
            catch (Exception)
            {
                return null;  // Return null if error occurs
            }
        }

        // Get all ChiTietDonHang with optional search filter
        public List<ChiTietDonHang> GetAll(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _baseDAL.chiTietdonhangrepository.Get(x => x.MaCa.Contains(search)).ToList();  // Filter by MaCa
            }
            else
            {
                return _baseDAL.chiTietdonhangrepository.Get().ToList();  // Return all if no filter is provided
            }
        }

        // Get list of ChiTietDonHang with paging and optional search keyword
        public List<ChiTietDonHang> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10)
        {
            try
            {
                return _baseDAL.chiTietdonhangrepository.GetListAllPaging(keywork, offset, limit);
            }
            catch (Exception)
            {
                return new List<ChiTietDonHang>();  // Return empty list if error occurs
            }
        }
    }
}
