using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ThongTinChungDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public ThongTinChungDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        public NAM_HOC NamHocSinger(int id)
        {
            return db.NAM_HOC.SingleOrDefault(x => x.ID_NAM_HOC == id);
        }
        public HOC_KY HocKySinger(int id)
        {
            return db.HOC_KY.SingleOrDefault(x => x.ID_HOC_KY == id);
        }
    }
}
