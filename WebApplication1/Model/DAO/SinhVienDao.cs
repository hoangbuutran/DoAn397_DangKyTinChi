using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Text.RegularExpressions;
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
        public SINH_VIEN SinhVienSingerWithIDTaiKhoan(int id)
        {
            return db.SINH_VIEN.SingleOrDefault(x => x.ID_TAI_KHOAN == id);
        }
        public SINH_VIEN SinhVienSingerWithMaSV(string maSinhVien)
        {
            return db.SINH_VIEN.SingleOrDefault(x => x.MA_SINH_VIEN == maSinhVien);
        }
        /// <summary>
        /// trả về danh sách sinh viên có trong table
        /// </summary>
        /// <returns></returns>
        public List<SINH_VIEN> ListSinhVien()
        {
            return db.SINH_VIEN.ToList();
        }

        public List<SINH_VIEN> ListSinhVienByCondition(string chuoiTimKiem)
        {
            return db.SINH_VIEN.Where(x => x.TEN_SINH_VIEN.Contains(chuoiTimKiem) ||
                                           x.MA_SINH_VIEN.Contains(chuoiTimKiem) ||
                                           x.EMAIL.Contains(chuoiTimKiem) ||
                                           x.DIA_CHI.Contains(chuoiTimKiem) ||
                                           x.CMND.Contains(chuoiTimKiem) ||
                                           x.CHUYEN_NGANH.TEN_CHUYEN_NGANH.Contains(chuoiTimKiem) ||
                                           x.DIEN_THOAI.Contains(chuoiTimKiem)
                                        ).ToList();
        }

        public string RejectMarks(string text)
        {
            string[] pattern = new string[7];

            pattern[0] = "a|á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ";

            pattern[1] = "o|ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ";

            pattern[2] = "e|é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ";

            pattern[3] = "u|ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ";

            pattern[4] = "i|í|ì|ỉ|ị|ĩ";

            pattern[5] = "y|ý|ỳ|ỷ|ỵ|ỹ";

            pattern[6] = "d|đ";
            for (int i = 0; i < pattern.Length; i++)
            {
                // kí tự sẽ thay thế
                char replaceChar = pattern[i][0];

                MatchCollection matchs = Regex.Matches(text, pattern[i]);

                foreach (Match m in matchs)
                {
                    text = text.Replace(m.Value[0], replaceChar);
                }
            }
            return text;
        }

        public string[] RemovwWhite(string[] chuoi)
        {
            string[] user = chuoi;
            for (int i = 0; i <= user.Length; i++)
            {
                if (user[i] == " ")
                {
                    for (int j = i; j < user.Length; j++)
                    {
                        user[j] = user[j+1];
                    }
                }
            }
            return user;
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
                SinhVienCu.TEN_SINH_VIEN = SinhVienMoi.TEN_SINH_VIEN.Trim();
                SinhVienCu.NGAY_SINH = SinhVienMoi.NGAY_SINH;
                SinhVienCu.CMND = SinhVienMoi.CMND.Trim();
                SinhVienCu.DIEN_THOAI = SinhVienMoi.DIEN_THOAI.Trim();
                SinhVienCu.DIA_CHI = SinhVienMoi.DIA_CHI.Trim();
                SinhVienCu.EMAIL = SinhVienMoi.EMAIL.Trim();
                SinhVienCu.TRANG_THAI = SinhVienMoi.TRANG_THAI;
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
        /// sinh viên tự sửa thông tin của mình
        /// </summary>
        /// <param name="SinhVienMoi"></param>
        /// <returns></returns>
        public int SuaSinhVienTuSua(SINH_VIEN SinhVienMoi)
        {
            int i;
            try
            {
                SINH_VIEN SinhVienCu = db.SINH_VIEN.Find(SinhVienMoi.ID_SINHVIEN);
                SinhVienCu.NGAY_SINH = SinhVienMoi.NGAY_SINH;
                SinhVienCu.CMND = SinhVienMoi.CMND.Trim();
                SinhVienCu.DIEN_THOAI = SinhVienMoi.DIEN_THOAI.Trim();
                SinhVienCu.DIA_CHI = SinhVienMoi.DIA_CHI.Trim();
                SinhVienCu.EMAIL = SinhVienMoi.EMAIL.Trim();
                if (SinhVienMoi.Image != null)
                {
                    SinhVienCu.Image = SinhVienMoi.Image;
                }
                else
                {
                    SinhVienCu.Image = SinhVienCu.Image;
                }
                
                db.SaveChanges();
                i = 1;
            }
            catch (Exception ex)
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
        public int KhoaMo(int id)
        {
            int i;
            try
            {
                var sinhvien = db.SINH_VIEN.Find(id);
                sinhvien.TRANG_THAI = !sinhvien.TRANG_THAI;
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
