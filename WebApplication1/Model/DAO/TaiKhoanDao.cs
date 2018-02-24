using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class TaiKhoanDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public TaiKhoanDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        public List<TAIKHOAN> listTaiKhoan()
        {
            return db.TAIKHOANs.ToList();
        }

        public List<TAIKHOAN> listCountTaiKhoanGiaoVu()
        {
            return db.TAIKHOANs.Where(x=>x.ID_QUYEN != 1 && x.ID_QUYEN != 2).ToList();
        }

        public List<TAIKHOAN> listCountTaiKhoanSinhVien()
        {
            return db.TAIKHOANs.Where(x => x.ID_QUYEN == 2).ToList();
        }
        public TAIKHOAN TaiKhoanSingleWithID(int id)
        {
            return db.TAIKHOANs.Where(x => x.ID_TAI_KHOAN == id).SingleOrDefault();
        }

        public int AddTaiKhoan(TAIKHOAN taikhoan)
        {
            int i;
            try
            {
                db.TAIKHOANs.Add(taikhoan);
                db.SaveChanges();
                var taikhoantimlai = db.TAIKHOANs.Find(taikhoan.ID_TAI_KHOAN);
                i = taikhoantimlai.ID_TAI_KHOAN;
            }
            catch (Exception)
            {
                i = 0;
            }

            return i;
        }
        public TAIKHOAN TaiKhoanSingle(string tendangnhap, string matkhau)
        {
            return db.TAIKHOANs.Where(x => x.USERNAME == tendangnhap && x.PASS == matkhau).SingleOrDefault();
        }
        public int Login(string tendangnhap, string matkhau)
        {
            var dem = 0;
            dem = db.TAIKHOANs.Count(x => x.USERNAME == tendangnhap && x.PASS == matkhau);
            if (dem != 0)
            {
                var taikhoan = TaiKhoanSingle(tendangnhap, matkhau);
                if (taikhoan.ID_QUYEN == 1)
                {
                    return 1;//admin
                }
                else if (taikhoan.ID_QUYEN == 2)//sinhvien
                {
                    return 2;
                }
                else if (taikhoan.ID_QUYEN == 3)//giaovu CNTT
                {
                    return 3;
                }
            }
            return 0;
        }
    }
}
