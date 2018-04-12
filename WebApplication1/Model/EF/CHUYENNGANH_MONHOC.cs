namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHUYENNGANH_MONHOC
    {
        public int ID { get; set; }

        [Display(Name = "Môn học")]
        public int? ID_MONHOC { get; set; }

        [Display(Name = "Chuyên ngành")]
        public int? ID_CHUYENNGANH { get; set; }

        [Display(Name = "Môn tự chọn ?")]
        public bool? TU_CHON { get; set; }

        [Display(Name = "Thuộc nhóm tự chọn")]
        public int? NHOM_TU_CHON { get; set; }

        public virtual CHUYEN_NGANH CHUYEN_NGANH { get; set; }

        public virtual MON_HOC MON_HOC { get; set; }
    }
}
