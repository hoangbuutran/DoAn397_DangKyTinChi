using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ChuongTrinhHocDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public ChuongTrinhHocDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        /// <summary>
        /// trả về danh sách chuyên ngành có trong csdl
        /// </summary>
        /// <returns></returns>
        public List<CHUONG_TRINH_HOC> ListChuongTrinhHoc(int idsinhvien)
        {
            return db.CHUONG_TRINH_HOC.Where(x=>x.ID_SINHVIEN == idsinhvien).ToList();
        }



    }
}
