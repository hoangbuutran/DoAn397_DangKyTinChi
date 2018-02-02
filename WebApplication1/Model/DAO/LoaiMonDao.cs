using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class LoaiMonDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public LoaiMonDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        /// <summary>
        /// trả về danh sách loại môn có trong csdl
        /// </summary>
        /// <returns></returns>
        public List<LOAI_MON> ListLoaiMon()
        {
            return db.LOAI_MON.ToList();
        }
    }
}
