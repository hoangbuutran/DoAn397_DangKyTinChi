namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEU_DANG_KY
    {
        [Key]
        public int ID_CT_PHIEU_DANG_KY { get; set; }

        [Display(Name = "Phiếu đăng kí")]
        public int? ID_PHIEU_DANG_KY { get; set; }

        [Display(Name = "Môn học")]
        public int? ID_MON_HOC { get; set; }

        public virtual MON_HOC MON_HOC { get; set; }

        public virtual PHIEU_DANG_KY PHIEU_DANG_KY { get; set; }
    }
}
