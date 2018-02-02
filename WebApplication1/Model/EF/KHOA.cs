namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOA")]
    public partial class KHOA
    {
        public KHOA()
        {
            CHUYEN_NGANH = new HashSet<CHUYEN_NGANH>();
        }

        [Key]
        public int ID_KHOA { get; set; }

        [StringLength(500)]
        public string TEN_KHOA { get; set; }

        public virtual ICollection<CHUYEN_NGANH> CHUYEN_NGANH { get; set; }
    }
}
