using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MonHocDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public MonHocDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        /// <summary>
        /// trả về môn học với id có được
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MON_HOC MonHocSinger(int id)
        {
            return db.MON_HOC.SingleOrDefault(x => x.ID_MON_HOC == id);
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
        public int AddMonHoc(MON_HOC MonHoc)
        {
            int i;
            try
            {
                db.MON_HOC.Add(MonHoc);
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
        /// <param name="MonHocMoi"></param>
        /// <returns></returns>
        public int SuaMonHoc(MON_HOC MonHocMoi)
        {
            int i;
            try
            {
                var MonHocCu = db.MON_HOC.Find(MonHocMoi.ID_MON_HOC);
                MonHocCu.SO_CHI = MonHocMoi.SO_CHI;
                MonHocCu.LOAI_DVHT = MonHocMoi.LOAI_DVHT;
                MonHocCu.LOAI_HINH = MonHocMoi.LOAI_HINH;
                MonHocCu.MON_TIEN_QUYET = MonHocMoi.MON_TIEN_QUYET;
                MonHocCu.MON_SONG_HANH = MonHocMoi.MON_SONG_HANH;
                MonHocCu.MO_TA = MonHocMoi.MO_TA;
                //MonHocCu.ID_LOAI_MON = MonHocMoi.ID_LOAI_MON;
                MonHocCu.ID_CHUYEN_NGANH = MonHocMoi.ID_CHUYEN_NGANH;
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
                var MonHoc = db.MON_HOC.Find(id);
                db.MON_HOC.Remove(MonHoc);
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
