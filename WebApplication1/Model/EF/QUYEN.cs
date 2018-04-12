namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        public QUYEN()
        {
            TAIKHOANs = new HashSet<TAIKHOAN>();
        }

        [Display(Name = "Quyền")]
        [Key]
        public int ID_QUYEN { get; set; }

        [Display(Name = "Tê quyền")]
        [StringLength(500)]
        public string TEN_QUYEN { get; set; }

        [Display(Name = "Mô tả")]
        [Column(TypeName = "ntext")]
        public string MO_TA { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TRANG_THAI { get; set; }

        public virtual ICollection<TAIKHOAN> TAIKHOANs { get; set; }
    }
}
