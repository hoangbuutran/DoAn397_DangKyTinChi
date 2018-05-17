using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        /// 
        /// </summary>
        /// <param name="namHoc"></param>
        public void DeleteMult(MON_HOC monHoc)
        {
            var listChuyenNganhMonHoc = db.CHUYENNGANH_MONHOC.Where(x => x.ID_MONHOC == monHoc.ID_MON_HOC).ToList();
            foreach (var item in listChuyenNganhMonHoc)
            {
                db.CHUYENNGANH_MONHOC.Remove(item);
            }
            var listCT_PHIEU_DANG_KY = db.CT_PHIEU_DANG_KY.Where(x => x.ID_MON_HOC == monHoc.ID_MON_HOC).ToList();

            foreach (var item in listCT_PHIEU_DANG_KY)
            {
                db.CT_PHIEU_DANG_KY.Remove(item);
            }
            db.MON_HOC.Remove(monHoc);
            db.SaveChanges();
        }
        /// <summary>
        /// tìm kiếm môn học với mã tìm kiếm được nhập vào.
        /// </summary>
        /// <param name="timkiem"></param>
        /// <returns></returns>
        public MON_HOC MonHocSingerwithMaTimKiem(string timkiem)
        {
            return db.MON_HOC.Where(x => x.MA_MON_HOC == timkiem).SingleOrDefault();
        }
        public MON_HOC MonHocSingerwithMaMon(string maMon)
        {
            return db.MON_HOC.Where(x => x.MA_MON_HOC == maMon).SingleOrDefault();
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
        /// dành cho action index truyền vào giá trị chuổi tìm kiếm
        /// </summary>
        /// <param name="chuoiTimKiem"></param>
        /// <returns>kết quả trùng khớp với chuổi tìm kiếm truyền vào</returns>
        public List<MON_HOC> ListMonHocByCondition(string chuoiTimKiem)
        {
            return db.MON_HOC.Where(x => x.TEN_MON_HOC.Contains(chuoiTimKiem) ||
                                           x.MA_MON_HOC.Contains(chuoiTimKiem) ||
                                           x.SO_CHI.ToString().Contains(chuoiTimKiem) ||
                                           x.TRANG_THAI.ToString().Contains(chuoiTimKiem) ||
                                           x.LOAI_DVHT.Contains(chuoiTimKiem) ||
                                           x.MON_SONG_HANH.Contains(chuoiTimKiem) ||
                                           x.MON_TIEN_QUYET.Contains(chuoiTimKiem) ||
                                           x.LOAI_HINH.Contains(chuoiTimKiem) ||
                                           x.MO_TA.Contains(chuoiTimKiem)
                                        ).ToList();
        }
        /// <summary>
        /// thêm môn học
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
                i = MonHoc.ID_MON_HOC;
            }
            catch (Exception)
            {
                i = 0;
            }
            return i;
        }

        /// <summary>
        /// sửa môn học
        /// </summary>
        /// <param name="MonHocMoi"></param>
        /// <returns></returns>
        public int SuaMonHoc(MON_HOC MonHocMoi)
        {
            int i;
            try
            {
                var MonHocCu = db.MON_HOC.Find(MonHocMoi.ID_MON_HOC);
                if (MonHocMoi.SO_CHI != MonHocCu.SO_CHI)
                {
                    if (MonHocMoi.SO_CHI > MonHocCu.SO_CHI)
                    {
                        //CongChi
                        var soChi = MonHocMoi.SO_CHI - MonHocCu.SO_CHI;
                        var listPhieu = new PhieuDangKyDao().ListPhieu();
                        foreach (var item in listPhieu)
                        {
                            var check = new CT_PhieuDangKyDao().CheckMonTrongPhieu(MonHocMoi.ID_MON_HOC, item.ID_PHIEU_DANG_KY);
                            if (check != null)
                            {
                                item.TONG_SO_TIN_CHI = item.TONG_SO_TIN_CHI + soChi;
                                object[] parameter =
                                {
                                    new SqlParameter("@ID_PHIEU", item.ID_PHIEU_DANG_KY),
                                    new SqlParameter("@TONG_CHI_HIEN_TAI", item.TONG_SO_TIN_CHI),
                                };
                                db.Database.ExecuteSqlCommand("TINCHIPHIEUUPDATEMON @ID_PHIEU, @TONG_CHI_HIEN_TAI", parameter);
                            }
                        }
                    }
                    if (MonHocMoi.SO_CHI < MonHocCu.SO_CHI)
                    {
                        //TruChi
                        var soChi = MonHocCu.SO_CHI - MonHocMoi.SO_CHI;
                        var listPhieu = new PhieuDangKyDao().ListPhieu();
                        foreach (var item in listPhieu)
                        {
                            var check = new CT_PhieuDangKyDao().CheckMonTrongPhieu(MonHocMoi.ID_MON_HOC, item.ID_PHIEU_DANG_KY);
                            if (check != null)
                            {
                                item.TONG_SO_TIN_CHI = item.TONG_SO_TIN_CHI - soChi;
                                object[] parameter =
                                {
                                    new SqlParameter("@ID_PHIEU", item.ID_PHIEU_DANG_KY),
                                    new SqlParameter("@TONG_CHI_HIEN_TAI", item.TONG_SO_TIN_CHI),
                                };
                                db.Database.ExecuteSqlCommand("TINCHIPHIEUUPDATEMON @ID_PHIEU, @TONG_CHI_HIEN_TAI", parameter);
                            }
                        }
                    }
                }
                MonHocCu.MA_MON_HOC = MonHocMoi.MA_MON_HOC.Trim();
                MonHocCu.SO_CHI = MonHocMoi.SO_CHI;
                MonHocCu.LOAI_DVHT = MonHocMoi.LOAI_DVHT.Trim();
                MonHocCu.LOAI_HINH = MonHocMoi.LOAI_HINH.Trim();
                MonHocCu.MON_TIEN_QUYET = MonHocMoi.MON_TIEN_QUYET.Trim();
                MonHocCu.MON_SONG_HANH = MonHocMoi.MON_SONG_HANH.Trim();
                MonHocCu.TU_CHON = MonHocMoi.TU_CHON;
                MonHocCu.NHOM_TU_CHON = MonHocMoi.NHOM_TU_CHON;
                MonHocCu.MO_TA = MonHocMoi.MO_TA.Trim();
                db.SaveChanges();
                i = 1;
            }
            catch (Exception EX)
            {
                i = 0;
            }
            return i;
        }

        /// <summary>
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
