namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHAN_VIEN
    {
        [Display(Name = "Nhân viên")]
        [Key]
        public int ID_NHANVIEN { get; set; }

        [Required]
        [Display(Name = "Tên nhân viên")]
        [StringLength(50)]
        public string TEN_NHANVIEN { get; set; }

        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? NGAY_SINH { get; set; }

        [Display(Name = "Điện thoại")]
        [Required]
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

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
