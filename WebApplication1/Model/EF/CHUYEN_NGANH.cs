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
            SINH_VIEN = new HashSet<SINH_VIEN>();
            CHUYENNGANH_MONHOC = new HashSet<CHUYENNGANH_MONHOC>();
        }

        [Key]
        public int ID_CHUYEN_NGANH { get; set; }

        [StringLength(500)]
        public string TEN_CHUYEN_NGANH { get; set; }

        public virtual ICollection<SINH_VIEN> SINH_VIEN { get; set; }

        public virtual ICollection<CHUYENNGANH_MONHOC> CHUYENNGANH_MONHOC { get; set; }
    }
}
