using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class QuyenDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public QuyenDao()
        {
            db = new CoSoDuLieuDbContext();
        }


        public QUYEN QuyenSinger(int id)
        {
            return db.QUYENs.SingleOrDefault(x => x.ID_QUYEN == id);
        }


        public List<QUYEN> ListQuyen()
        {
            return db.QUYENs.Where(x => x.TRANG_THAI == true).ToList();
        }

        public int SuaQuyen(QUYEN quyen)
        {
            int i;
            try
            {
                var QuyenCu = db.QUYENs.Find(quyen.ID_QUYEN);
                QuyenCu.TEN_QUYEN = QuyenCu.TEN_QUYEN;
                QuyenCu.MO_TA = QuyenCu.MO_TA;
                QuyenCu.TRANG_THAI = quyen.TRANG_THAI;
                db.SaveChanges();
                i = 1;
            }
            catch (Exception)
            {
                i = 0;
            }
            return i;
        }

    }
}
