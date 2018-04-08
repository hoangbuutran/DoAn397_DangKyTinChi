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

        public int? ID_MONHOC { get; set; }

        public int? ID_CHUYENNGANH { get; set; }

        public bool? TU_CHON { get; set; }

        public int? NHOM_TU_CHON { get; set; }

        public virtual CHUYEN_NGANH CHUYEN_NGANH { get; set; }

        public virtual MON_HOC MON_HOC { get; set; }
    }
}
