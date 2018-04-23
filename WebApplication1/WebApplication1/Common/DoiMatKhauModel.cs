using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Common
{
    public class DoiMatKhauModel
    {
        [Key]
        public int ID { get; set; }

        public string MatKhauCu { get; set; }

        public string MatKhauMoi { get; set; }
    }
}