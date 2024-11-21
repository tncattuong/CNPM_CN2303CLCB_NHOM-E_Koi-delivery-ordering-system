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
    public class IplCaKoiSer : ICaKoiSer
    {
        private readonly IBase _baseDAL;

        public IplCaKoiSer(IBase baseDAL)
        {
            _baseDAL = baseDAL;
        }

        // Insert new CaKoi
        public bool Insert(CaKoi caKoi)
        {
            try
            {
                _baseDAL.caKoirepository.Insert(caKoi);
                _baseDAL.caKoirepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Update existing CaKoi
        public bool Update(CaKoi caKoi)
        {
            try
            {
                _baseDAL.caKoirepository.Update(caKoi);
                _baseDAL.caKoirepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Delete CaKoi by MaCa
        public bool Delete(string maCa)
        {
            try
            {
                _baseDAL.caKoirepository.Delete(maCa);
                _baseDAL.caKoirepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Get CaKoi by MaCa
        public CaKoi GetById(string maCa)
        {
            try
            {
                var caKoi = _baseDAL.caKoirepository.GetById(maCa);  // Get CaKoi by MaCa
                return caKoi;
            }
            catch (Exception)
            {
                return null;  // Return null if error occurs
            }
        }

        // Get all CaKoi with optional search filter
        public List<CaKoi> GetAll(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _baseDAL.caKoirepository.Get(x => x.LoaiCa.Contains(search) || x.MauSac.Contains(search)).ToList();  // Filter by LoaiCa or MauSac
            }
            else
            {
                return _baseDAL.caKoirepository.Get().ToList();  // Return all if no filter is provided
            }
        }

        // Get list of CaKoi with paging and optional search keyword
        public List<CaKoi> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10)
        {
            try
            {
                return _baseDAL.caKoirepository.GetListAllPaging(keywork, offset, limit);
            }
            catch (Exception)
            {
                return new List<CaKoi>();  // Return empty list if error occurs
            }
        }
    }
}
