namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHUONG_TRINH_HOC
    {
        [Key]
        public int ID_CHUONG_TRINH_HOC { get; set; }

        public int? ID_SINHVIEN { get; set; }

        public int? ID_MON_HOC { get; set; }

        public bool? TINH_TRANG { get; set; }

        public virtual MON_HOC MON_HOC { get; set; }

        public virtual SINH_VIEN SINH_VIEN { get; set; }
    }
}
