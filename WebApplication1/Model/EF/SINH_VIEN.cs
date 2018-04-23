namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SINH_VIEN
    {
        public SINH_VIEN()
        {
            PHIEU_DANG_KY = new HashSet<PHIEU_DANG_KY>();
        }

        [Display(Name = "Mã sinh viên")]
        [Key]
        public int ID_SINHVIEN { get; set; }

        [Display(Name = "Mã sinh viên")]
        [Required]
        [StringLength(500)]
        public string MA_SINH_VIEN { get; set; }

        [Display(Name = "Tên sinh viên")]
        [StringLength(500)]
        public string TEN_SINH_VIEN { get; set; }

        [Display(Name = "Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? NGAY_SINH { get; set; }

        [Display(Name = "Số CMND")]
        [StringLength(500)]
        public string CMND { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(500)]
        public string DIEN_THOAI { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(900)]
        public string DIA_CHI { get; set; }
        [Display(Name = "Email")]
        [StringLength(500)]
        public string EMAIL { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TRANG_THAI { get; set; }

        [Display(Name = "Tài khoản")]
        public int? ID_TAI_KHOAN { get; set; }

        [Display(Name = "Chuyên Ngành")]
        public int? ID_CHUYEN_NGANH { get; set; }

        public virtual CHUYEN_NGANH CHUYEN_NGANH { get; set; }

        public virtual ICollection<PHIEU_DANG_KY> PHIEU_DANG_KY { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
