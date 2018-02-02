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
    }
}
