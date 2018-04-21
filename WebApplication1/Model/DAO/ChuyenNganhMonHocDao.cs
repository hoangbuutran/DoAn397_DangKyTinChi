using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ChuyenNganhMonHocDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public ChuyenNganhMonHocDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        /// <summary>
        /// trả về môn học với id có được
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CHUYENNGANH_MONHOC ChuyenNganhMonHocSinger(int id)
        {
            return db.CHUYENNGANH_MONHOC.SingleOrDefault(x => x.ID_MONHOC == id);
        }

        /// <summary>
        /// tìm kiếm môn học với mã tìm kiếm được nhập vào.
        /// </summary>
        /// <param name="timkiem"></param>
        /// <returns></returns>
        public MON_HOC MonHocSingerwithMaTimKiem(string timkiem)
        {
            return db.MON_HOC.Where(x => x.MA_MON_HOC.Contains(timkiem)).SingleOrDefault();
        }
        /// <summary>
        /// trả về danh sách mon hoc có trong table
        /// </summary>
        /// <returns></returns>
        public List<MON_HOC> ListMonHoc()
        {
            return db.MON_HOC.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MonHoc"></param>
        /// <returns></returns>
        public int AddMonHoc(CHUYENNGANH_MONHOC MonHoc)
        {
            int i;
            try
            {
                db.CHUYENNGANH_MONHOC.Add(MonHoc);
                db.SaveChanges();
                i = MonHoc.MON_HOC.ID_MON_HOC;
            }
            catch (Exception)
            {
                i = 0;
            }
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MonHocMoi"></param>
        /// <returns></returns>
        public int SuaMonHoc(CHUYENNGANH_MONHOC MonHocMoi)
        {
            int i;
            try
            {
                var j = new MonHocDao().SuaMonHoc(MonHocMoi.MON_HOC);
                var MonHocCu = ChuyenNganhMonHocSinger(MonHocMoi.ID);
                MonHocCu.ID_CHUYENNGANH = MonHocMoi.ID_CHUYENNGANH;
                MonHocCu.TU_CHON = MonHocMoi.TU_CHON;
                MonHocCu.NHOM_TU_CHON = MonHocMoi.NHOM_TU_CHON;
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int XoaMonHoc(int id)
        {
            int i;
            try
            {

                var MonHoc = ChuyenNganhMonHocSinger(id);
                var MonHoc2 = db.MON_HOC.Find(id);
                db.CHUYENNGANH_MONHOC.Remove(MonHoc);
                db.MON_HOC.Remove(MonHoc2);
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
