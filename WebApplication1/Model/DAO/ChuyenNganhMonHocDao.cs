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
        /// trả về môn học thuộc chuyên ngành với id của môn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CHUYENNGANH_MONHOC ChuyenNganhMonHocSinger(int id)
        {
            return db.CHUYENNGANH_MONHOC.SingleOrDefault(x => x.ID == id);
        }


        public int ChuyenNganhMonHocWithIdMonIdChuyenNganh(int idMon, int idCN)
        {
            return db.CHUYENNGANH_MONHOC.Count(x => x.ID_MONHOC == idMon && x.ID_CHUYENNGANH == idCN);
        }

        public List<CHUYENNGANH_MONHOC> ChuyenNganhMonHocListWithIdMon(int id)
        {
            return db.CHUYENNGANH_MONHOC.Where(x => x.ID_MONHOC == id).ToList();
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
        /// Thêm môn học vào csdl với những chuyên ngành của môn
        /// </summary>
        /// <param name="MonHoc"></param>
        /// <returns></returns>
        public int AddMonHoc(CHUYENNGANH_MONHOC MonHoc)
        {
            var MonExist = new MON_HOC();
            MonExist = null;
            if (MonHoc.MON_HOC != null)
            {
                MonExist = new MonHocDao().MonHocSingerwithMaMon(MonHoc.MON_HOC.MA_MON_HOC);
            }
            int i;
            try
            {
                if (MonExist == null)
                {
                    db.CHUYENNGANH_MONHOC.Add(MonHoc);
                    db.SaveChanges();
                    i = MonHoc.MON_HOC.ID_MON_HOC;
                }
                else
                {
                    i = 0;
                }

            }
            catch (Exception)
            {
                i = 0;
            }
            return i;
        }

        /// <summary>
        /// sửa thông tin của môn
        /// </summary>
        /// <param name="MonHocMoi"></param>
        /// <returns></returns>
        public int SuaMonHoc(CHUYENNGANH_MONHOC MonHocMoi)
        {
            int i;
            try
            {
                var j = new MonHocDao().SuaMonHoc(MonHocMoi.MON_HOC);
                var MonHocChuyenNganhCu = ChuyenNganhMonHocSinger(MonHocMoi.ID);
                MonHocChuyenNganhCu.ID_CHUYENNGANH = MonHocMoi.ID_CHUYENNGANH;
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
        /// khóa mở môn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int KhoaMo(int id)
        {
            int i;
            try
            {
                var MonHoc = db.MON_HOC.Find(id);
                MonHoc.TRANG_THAI = !MonHoc.TRANG_THAI;
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
