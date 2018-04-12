namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HOC_KY
    {
        public HOC_KY()
        {
            PHIEU_DANG_KY = new HashSet<PHIEU_DANG_KY>();
        }
        [Display(Name = "Học kỳ")]
        [Key]
        public int ID_HOC_KY { get; set; }

        [Display(Name = "Tên học kỳ")]
        [StringLength(500)]
        public string TEN_HOC_KY { get; set; }

        public virtual ICollection<PHIEU_DANG_KY> PHIEU_DANG_KY { get; set; }
    }
}
