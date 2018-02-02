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
            CHUONG_TRINH_HOC = new HashSet<CHUONG_TRINH_HOC>();
            CT_PHIEU_DANG_KY = new HashSet<CT_PHIEU_DANG_KY>();
        }

        [Key]
        public int ID_MON_HOC { get; set; }

        [Required]
        [StringLength(500)]
        public string MA_MON_HOC { get; set; }

        [StringLength(500)]
        public string TEN_MON_HOC { get; set; }

        public int? SO_CHI { get; set; }

        [StringLength(500)]
        public string LOAI_DVHT { get; set; }

        [StringLength(500)]
        public string LOAI_HINH { get; set; }

        [StringLength(500)]
        public string MON_TIEN_QUYET { get; set; }

        [StringLength(500)]
        public string MON_SONG_HANH { get; set; }

        [Column(TypeName = "ntext")]
        public string MO_TA { get; set; }

        public int? ID_LOAI_MON { get; set; }

        public int? ID_CHUYEN_NGANH { get; set; }

        public bool? TRANG_THAI { get; set; }

        public virtual ICollection<CHUONG_TRINH_HOC> CHUONG_TRINH_HOC { get; set; }

        public virtual CHUYEN_NGANH CHUYEN_NGANH { get; set; }

        public virtual ICollection<CT_PHIEU_DANG_KY> CT_PHIEU_DANG_KY { get; set; }

        public virtual LOAI_MON LOAI_MON { get; set; }
    }
}
