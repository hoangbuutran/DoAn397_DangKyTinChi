namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NAM_HOC
    {
        public NAM_HOC()
        {
            PHIEU_DANG_KY = new HashSet<PHIEU_DANG_KY>();
        }

        [Display(Name = "Năm học")]
        [Key]
        public int ID_NAM_HOC { get; set; }

        [Display(Name = "Tên năm học")]
        [StringLength(500)]
        public string TEN_NAM_HOC { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? TRANGTHAI { get; set; }

        public virtual ICollection<PHIEU_DANG_KY> PHIEU_DANG_KY { get; set; }
    }
}
