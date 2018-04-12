namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MON_HOC
    {
        public MON_HOC()
        {
            CHUYENNGANH_MONHOC = new HashSet<CHUYENNGANH_MONHOC>();
            CT_PHIEU_DANG_KY = new HashSet<CT_PHIEU_DANG_KY>();
        }
        [Display(Name = "Môn học")]
        [Key]
        public int ID_MON_HOC { get; set; }

        [Display(Name = "Mã môn học")]
        [Required]
        [StringLength(500)]
        public string MA_MON_HOC { get; set; }

        [Display(Name = "Tên môn học")]
        [StringLength(500)]
        public string TEN_MON_HOC { get; set; }

        [Display(Name = "Số tín chỉ")]
        public int? SO_CHI { get; set; }

        [Display(Name = "Loại DVHT")]
        [StringLength(500)]
        public string LOAI_DVHT { get; set; }

        [Display(Name = "Loại hình")]
        [StringLength(500)]
        public string LOAI_HINH { get; set; }

        [Display(Name = "Môn học tiên quyết")]
        [StringLength(500)]
        public string MON_TIEN_QUYET { get; set; }

        [Display(Name = "Môn học song ngành")]
        [StringLength(500)]
        public string MON_SONG_HANH { get; set; }

        [Display(Name = "Mô tả")]
        [Column(TypeName = "ntext")]
        public string MO_TA { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TRANG_THAI { get; set; }

        public virtual ICollection<CHUYENNGANH_MONHOC> CHUYENNGANH_MONHOC { get; set; }

        public virtual ICollection<CT_PHIEU_DANG_KY> CT_PHIEU_DANG_KY { get; set; }
    }
}
