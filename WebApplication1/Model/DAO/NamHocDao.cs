using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NamHocDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public NamHocDao()
        {
            db = new CoSoDuLieuDbContext();
        }


        public NAM_HOC NamHocSinger(int id)
        {
            return db.NAM_HOC.SingleOrDefault(x => x.ID_NAM_HOC == id);
        }


        public List<NAM_HOC> ListNamHoc()
        {
            return db.NAM_HOC.ToList();
        }

        public int AddNamHoc(NAM_HOC model)
        {
            int i;
            try
            {
                db.NAM_HOC.Add(model);
                db.SaveChanges();
                i = model.ID_NAM_HOC;
            }
            catch (Exception)
            {
                i = 0;
                throw;
            }
            return i;
        }

        public int SuaNamHoc(NAM_HOC NAM_HOC)
        {
            int i;
            try
            {
                var NAM_HOCCu = db.NAM_HOC.Find(NAM_HOC.ID_NAM_HOC);
                NAM_HOCCu.TEN_NAM_HOC = NAM_HOC.TEN_NAM_HOC;
                NAM_HOCCu.TRANGTHAI = NAM_HOC.TRANGTHAI;
                db.SaveChanges();
                i = 1;
            }
            catch (Exception)
            {
                i = 0;
            }
            return i;
        }
        public NAM_HOC NamHocDelete(int id)
        {
            return db.NAM_HOC.Remove(db.NAM_HOC.Find(id));
        }
    }
}
