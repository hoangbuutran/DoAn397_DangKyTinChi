namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHIEU_DANG_KY
    {
        public PHIEU_DANG_KY()
        {
            CT_PHIEU_DANG_KY = new HashSet<CT_PHIEU_DANG_KY>();
        }

        [Key]
        public int ID_PHIEU_DANG_KY { get; set; }
        [Display(Name = "Mã Sinh Viên")]
        public int? ID_SINHVIEN { get; set; }
        [Display(Name="Học Kỳ")]
        public int? ID_HOC_KY { get; set; }
        [Display(Name = "Năm Học")]
        public int? ID_NAM_HOC { get; set; }

        [Display(Name = "Tổng số chỉ")]
        public int? TONG_SO_TIN_CHI { get; set; }

        public virtual ICollection<CT_PHIEU_DANG_KY> CT_PHIEU_DANG_KY { get; set; }

        public virtual HOC_KY HOC_KY { get; set; }

        public virtual NAM_HOC NAM_HOC { get; set; }

        public virtual SINH_VIEN SINH_VIEN { get; set; }
    }
}
