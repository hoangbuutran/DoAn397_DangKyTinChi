namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHAN_VIEN
    {
        [Key]
        public int ID_NHANVIEN { get; set; }

        [StringLength(50)]
        public string TEN_NHANVIEN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY_SINH { get; set; }

        [StringLength(500)]
        public string DIEN_THOAI { get; set; }

        [StringLength(900)]
        public string DIA_CHI { get; set; }

        [StringLength(500)]
        public string EMAIL { get; set; }

        public int? ID_TAI_KHOAN { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
