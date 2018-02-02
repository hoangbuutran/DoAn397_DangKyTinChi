using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class SinhVienDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public SinhVienDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        /// <summary>
        /// trả về sinh viên với id co được
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SINH_VIEN SinhVienSinger(int id)
        {
            return db.SINH_VIEN.SingleOrDefault(x => x.ID_SINHVIEN == id);
        }
        /// <summary>
        /// trả về danh sách sinh viên có trong table
        /// </summary>
        /// <returns></returns>
        public List<SINH_VIEN> ListSinhVien()
        {
            return db.SINH_VIEN.ToList();
        }

        /// <summary>
        /// thêm một sinh viên mới nhập vào csdl
        /// </summary>
        /// <param name="sv"></param>
        /// <returns></returns>
        public int AddSinhVien(SINH_VIEN sv)
        {
            int i;
            try
            {
                db.SINH_VIEN.Add(sv);
                db.SaveChanges();
                i = 1;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }  
            return i;
        }

        /// <summary>
        /// sửa sinh viên mới sửa
        /// </summary>
        /// <param name="SinhVienMoi"></param>
        /// <returns></returns>
        public int SuaSinhVien(SINH_VIEN SinhVienMoi)
        {
            int i;
            try
            {
                SINH_VIEN SinhVienCu = db.SINH_VIEN.Find(SinhVienMoi.ID_SINHVIEN);
                SinhVienCu.TEN_SINH_VIEN = SinhVienMoi.TEN_SINH_VIEN;
                SinhVienCu.NGAY_SINH = SinhVienMoi.NGAY_SINH;
                SinhVienCu.CMND = SinhVienMoi.CMND;
                SinhVienCu.DIEN_THOAI = SinhVienMoi.DIEN_THOAI;
                SinhVienCu.DIA_CHI = SinhVienMoi.DIA_CHI;
                SinhVienCu.EMAIL = SinhVienMoi.EMAIL;
                SinhVienCu.ID_TAI_KHOAN = SinhVienMoi.ID_TAI_KHOAN;
                SinhVienCu.ID_CHUYEN_NGANH = SinhVienMoi.ID_CHUYEN_NGANH;
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
        /// xóa sinh viên với id nhập vào
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int XoaSinhVien(int id)
        {
            int i;
            try
            {
                var sinhvien = db.SINH_VIEN.Find(id);
                db.SINH_VIEN.Remove(sinhvien);
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
