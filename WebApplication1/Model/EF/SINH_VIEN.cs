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
            CHUONG_TRINH_HOC = new HashSet<CHUONG_TRINH_HOC>();
            PHIEU_DANG_KY = new HashSet<PHIEU_DANG_KY>();
        }
        [Display(Name = "Sinh Viên")]
        [Key]
        public int ID_SINHVIEN { get; set; }
        [Display(Name = "Mã Sinh Viên")]
        [Required]
        [StringLength(500)]
        public string MA_SINH_VIEN { get; set; }
        [Display(Name = "Tên Sinh Viên")]
        [StringLength(500)]
        public string TEN_SINH_VIEN { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime? NGAY_SINH { get; set; }
        [Display(Name = "Số CMND")]
        [StringLength(500)]
        public string CMND { get; set; }

        [StringLength(500)]
        public string DIEN_THOAI { get; set; }

        [StringLength(900)]
        public string DIA_CHI { get; set; }

        [StringLength(500)]
        public string EMAIL { get; set; }

        public int? ID_TAI_KHOAN { get; set; }

        public int? ID_CHUYEN_NGANH { get; set; }

        public virtual ICollection<CHUONG_TRINH_HOC> CHUONG_TRINH_HOC { get; set; }

        public virtual CHUYEN_NGANH CHUYEN_NGANH { get; set; }

        public virtual ICollection<PHIEU_DANG_KY> PHIEU_DANG_KY { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
