using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using KDOS.Service.Interface;
using KDOS.Repository;
using KDOS.Repository.Interface;
using KDOS.Repository.Models;

namespace KDOS.Service.Implement
{
    public class IplBangGiaSer : IBangGiaSer
    {
        private readonly IBase _baseDAL;

        public IplBangGiaSer(IBase baseDAL)
        {
            _baseDAL = baseDAL;
        }

        // Insert new BangGia
        public bool Insert(BangGia bangGia)
        {
            try
            {
                _baseDAL.bangGiarepository.Insert(bangGia);
                _baseDAL.bangGiarepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Update existing BangGia
        public bool Update(BangGia bangGia)
        {
            try
            {
                _baseDAL.bangGiarepository.Update(bangGia);
                _baseDAL.bangGiarepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Delete BangGia by ID
        public bool Delete(int maGia)
        {
            try
            {
                _baseDAL.bangGiarepository.Delete(maGia);
                _baseDAL.bangGiarepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Get BangGia by ID
        public BangGia GetById(int maGia)
        {
            try
            {
                var bangGia = _baseDAL.bangGiarepository.GetById(maGia);  // Get BangGia by ID
                return bangGia;
            }
            catch (Exception)
            {
                return null;  // Return null if error occurs
            }
        }

        // Get all BangGia with optional search filter
        public List<BangGia> GetAll(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _baseDAL.bangGiarepository.Get(x => x.MaCa.Contains(search)).ToList();  // Filter by MaCa
            }
            else
            {
                return _baseDAL.bangGiarepository.Get().ToList();  // Return all if no filter is provided
            }
        }

        // Get list of BangGia with paging and optional search keyword
        public List<BangGia> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10)
        {
            try
            {
                return _baseDAL.bangGiarepository.GetListAllPaging(keywork, offset, limit);
            }
            catch (Exception)
            {
                return new List<BangGia>();  // Return empty list if error occurs
            }
        }
    }
}
