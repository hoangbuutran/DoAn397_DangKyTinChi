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

        /// <summary>
        /// trả về năm học với id truyền vào
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NAM_HOC NamHocSinger(int id)
        {
            return db.NAM_HOC.SingleOrDefault(x => x.ID_NAM_HOC == id);
        }

        /// <summary>
        /// trả về danh sách năm học
        /// </summary>
        /// <returns></returns>
        public List<NAM_HOC> ListNamHoc()
        {
            return db.NAM_HOC.ToList();
        }

        /// <summary>
        /// thêm năm học vào csdl
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// sửa thông tin năm học
        /// </summary>
        /// <param name="NAM_HOC"></param>
        /// <returns></returns>
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

        /// <summary>
        /// khóavà mở năm học 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int KhoaMo(int id)
        {
            int i;
            try
            {
                var namHoc = db.NAM_HOC.Find(id);
                namHoc.TRANGTHAI = !namHoc.TRANGTHAI;
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
