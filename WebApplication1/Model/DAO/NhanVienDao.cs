using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NhanVienDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public NhanVienDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        /// <summary>
        /// trả về sinh viên với id co được
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NHAN_VIEN NhanVienSinger(int id)
        {
            return db.NHAN_VIEN.SingleOrDefault(x => x.ID_NHANVIEN == id);
        }
        public NHAN_VIEN NhanVienSingerWithIDTaiKhoan(int id)
        {
            return db.NHAN_VIEN.SingleOrDefault(x => x.ID_TAI_KHOAN == id);
        }
        /// <summary>
        /// trả về danh sách sinh viên có trong table
        /// </summary>
        /// <returns></returns>
        public List<NHAN_VIEN> ListNhanVien()
        {
            return db.NHAN_VIEN.ToList();
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
                        user[j] = user[j + 1];
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
        public int AddNhanVien(NHAN_VIEN nv)
        {
            int i;
            try
            {
                db.NHAN_VIEN.Add(nv);
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
        public int SuaNhaVien(NHAN_VIEN NVMoi)
        {
            int i;
            try
            {
                NHAN_VIEN NVCu = db.NHAN_VIEN.Find(NVMoi.ID_NHANVIEN);
                NVCu.TEN_NHANVIEN = NVMoi.TEN_NHANVIEN;
                NVCu.NGAY_SINH = NVMoi.NGAY_SINH;
                NVCu.DIEN_THOAI = NVMoi.DIEN_THOAI;
                NVCu.DIA_CHI = NVMoi.DIA_CHI;
                NVCu.EMAIL = NVMoi.EMAIL;
                NVCu.ID_TAI_KHOAN = NVMoi.ID_TAI_KHOAN;
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
        public int XoaNhanVien(int id)
        {
            int i;
            try
            {
                var NV = db.NHAN_VIEN.Find(id);
                db.NHAN_VIEN.Remove(NV);
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
