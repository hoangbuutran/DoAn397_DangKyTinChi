﻿namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        public TAIKHOAN()
        {
            NHAN_VIEN = new HashSet<NHAN_VIEN>();
            SINH_VIEN = new HashSet<SINH_VIEN>();
        }

        [Display(Name = "Tài khoản")]
        [Key]
        public int ID_TAI_KHOAN { get; set; }

        [Display(Name = "UserName")]
        [StringLength(500)]
        public string USERNAME { get; set; }

        [Display(Name = "PassWord")]
        [StringLength(500)]
        public string PASS { get; set; }

        [Display(Name = "Quyền")]
        public int? ID_QUYEN { get; set; }

        public virtual ICollection<NHAN_VIEN> NHAN_VIEN { get; set; }

        public virtual QUYEN QUYEN { get; set; }

        public virtual ICollection<SINH_VIEN> SINH_VIEN { get; set; }
    }
}
