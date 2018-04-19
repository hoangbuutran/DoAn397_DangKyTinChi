using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CT_PhieuDangKyDao
    {/// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public CT_PhieuDangKyDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        public int AddCTPHIEUDANGKY(CT_PHIEU_DANG_KY phieu)
        {
            int i = 0;
            try
            {
                var daomon = new MonHocDao().MonHocSinger((int)phieu.ID_MON_HOC);
                var daophieu = new PhieuDangKyDao().PhieuDKSinger((int)phieu.ID_PHIEU_DANG_KY);
                if (daophieu.TONG_SO_TIN_CHI + daomon.SO_CHI <= 20)
                {
                    var timlai = db.CT_PHIEU_DANG_KY.Count(x => x.ID_MON_HOC == phieu.ID_MON_HOC && x.ID_PHIEU_DANG_KY == phieu.ID_PHIEU_DANG_KY);
                    if (timlai == 0)
                    {
                        db.CT_PHIEU_DANG_KY.Add(phieu);
                        db.SaveChanges();
                        i = 1;
                    }
                    else
                    {
                        i = 2;
                    }

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return i;
        }

        public List<CT_PHIEU_DANG_KY> DanhSachMonWithIdPhieu(int id)
        {
            return db.CT_PHIEU_DANG_KY.Where(x => x.ID_PHIEU_DANG_KY == id).ToList();
        }
        public CT_PHIEU_DANG_KY MonTrongPhieuSinger(int idCtPhieu)
        {
            return db.CT_PHIEU_DANG_KY.Where(x => x.ID_CT_PHIEU_DANG_KY == idCtPhieu).SingleOrDefault();
        }


        public void XoaMonTrongPhieuSinger(CT_PHIEU_DANG_KY Mon)
        {
            db.CT_PHIEU_DANG_KY.Remove(Mon);
            db.SaveChanges();
        }

    }
}
