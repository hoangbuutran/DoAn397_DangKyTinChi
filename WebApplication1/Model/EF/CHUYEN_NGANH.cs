namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHUYEN_NGANH
    {
        public CHUYEN_NGANH()
        {
            MON_HOC = new HashSet<MON_HOC>();
            SINH_VIEN = new HashSet<SINH_VIEN>();
        }

        [Key]
        public int ID_CHUYEN_NGANH { get; set; }

        [StringLength(500)]
        public string TEN_CHUYEN_NGANH { get; set; }

        public int? ID_KHOA { get; set; }

        public virtual KHOA KHOA { get; set; }

        public virtual ICollection<MON_HOC> MON_HOC { get; set; }

        public virtual ICollection<SINH_VIEN> SINH_VIEN { get; set; }
    }
}
