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
        /// trả về nhân viên với id co được
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NHAN_VIEN NhanVienSinger(int id)
        {
            return db.NHAN_VIEN.SingleOrDefault(x => x.ID_NHANVIEN == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="namHoc"></param>
        public void DeleteMult(NHAN_VIEN nhanVien)
        {
            var taiKhoan = db.TAIKHOANs.Where(x => x.ID_TAI_KHOAN == nhanVien.ID_TAI_KHOAN).Single();
            db.TAIKHOANs.Remove(taiKhoan);
            db.NHAN_VIEN.Remove(nhanVien);
            db.SaveChanges();
        }

        /// <summary>
        /// trả về nhân viên với id của tài khoản truyền vào
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NHAN_VIEN NhanVienSingerWithIDTaiKhoan(int id)
        {
            return db.NHAN_VIEN.SingleOrDefault(x => x.ID_TAI_KHOAN == id);
        }

        /// <summary>
        /// trả về danh sách nhân viên có trong table
        /// </summary>
        /// <returns></returns>
        public List<NHAN_VIEN> ListNhanVien()
        {
            return db.NHAN_VIEN.ToList();
        }

        /// <summary>
        /// hàm bỏ kí tự việt nam sang kí tự EN
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// hàm xóa kí tự trắng có trong chuổi
        /// </summary>
        /// <param name="chuoi"></param>
        /// <returns></returns>
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
        /// thêm một nhân viên mới nhập vào csdl
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
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return i;
        }

        /// <summary>
        /// sửa nhân viên 
        /// </summary>
        /// <param name="SinhVienMoi"></param>
        /// <returns></returns>
        public int SuaNhaVien(NHAN_VIEN NVMoi)
        {
            int i;
            try
            {
                var NVCu = NhanVienSinger(NVMoi.ID_NHANVIEN);
                NVCu.TEN_NHANVIEN = NVMoi.TEN_NHANVIEN.Trim();
                NVCu.NGAY_SINH = NVMoi.NGAY_SINH;
                NVCu.DIEN_THOAI = NVMoi.DIEN_THOAI.Trim();
                NVCu.DIA_CHI = NVMoi.DIA_CHI.Trim();
                NVCu.EMAIL = NVMoi.EMAIL.Trim();
                NVCu.TRANG_THAI = NVMoi.TRANG_THAI;
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
        /// sửa nhân viên tự sửa
        /// </summary>
        /// <param name="SinhVienMoi"></param>
        /// <returns></returns>
        public int SuaNhaVienTuSua(NHAN_VIEN NVMoi)
        {
            int i;
            try
            {
                var NVCu = NhanVienSinger(NVMoi.ID_NHANVIEN);
                NVCu.NGAY_SINH = NVMoi.NGAY_SINH;
                NVCu.DIEN_THOAI = NVMoi.DIEN_THOAI.Trim();
                NVCu.DIA_CHI = NVMoi.DIA_CHI.Trim();
                NVCu.EMAIL = NVMoi.EMAIL.Trim();
                if (NVMoi.Image != null)
                {
                    NVCu.Image = NVMoi.Image.Trim();
                }
                else
                {
                    NVCu.Image = NVCu.Image;
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
        /// khóa mở nhan viên với id nhập vào
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int KhoaMo(int id)
        {
            int i;
            try
            {
                var nhanVien = db.NHAN_VIEN.Find(id);
                nhanVien.TRANG_THAI = !nhanVien.TRANG_THAI;
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
