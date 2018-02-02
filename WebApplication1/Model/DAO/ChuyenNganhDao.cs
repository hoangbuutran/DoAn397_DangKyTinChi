using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ChuyenNganhDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public ChuyenNganhDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        /// <summary>
        /// trả về danh sách chuyên ngành có trong csdl
        /// </summary>
        /// <returns></returns>
        public List<CHUYEN_NGANH> ListChuyenNganh()
        {
            return db.CHUYEN_NGANH.ToList();
        }

       
    }
}
