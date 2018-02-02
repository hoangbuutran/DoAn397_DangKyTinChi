﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PhieuDangKyDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public PhieuDangKyDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        public List<NAM_HOC> ListNamHoc()
        {
            return db.NAM_HOC.ToList();
        }

        public List<HOC_KY> ListHocKy()
        {
            return db.HOC_KY.ToList();
        }

        public List<PHIEU_DANG_KY> ListPhieuDangKy(int IDSinhVien)
        {
            return db.PHIEU_DANG_KY.Where(x => x.ID_SINHVIEN == IDSinhVien).ToList();
        }

        public int CreatePhieuDangKy(PHIEU_DANG_KY model)
        {
            int i = 0;
            try
            {
                db.PHIEU_DANG_KY.Add(model);
                db.SaveChanges();
                i = model.ID_PHIEU_DANG_KY;
            }
            catch (Exception)
            {
                throw;
            }
            return i;
        }
    }
}