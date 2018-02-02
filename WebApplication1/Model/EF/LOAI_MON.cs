namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOAI_MON
    {
        public LOAI_MON()
        {
            MON_HOC = new HashSet<MON_HOC>();
        }

        [Key]
        public int ID_LOAI_MON { get; set; }

        [StringLength(500)]
        public string TEN_LOAI_MON { get; set; }

        public virtual ICollection<MON_HOC> MON_HOC { get; set; }
    }
}
