using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TimKiemModel
    {
        [Display(Name = "Mã Môn Cần Tìm")]
        public string chuoitimkiem { get; set; }
        [Display(Name = "Mã Phiếu Đã Đăng Ký")]
        public int idPhieu { get; set; }
    }
}