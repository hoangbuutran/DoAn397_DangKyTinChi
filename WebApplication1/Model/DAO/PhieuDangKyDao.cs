using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PhieuDangKyDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public PhieuDangKyDao()
        {
            db = new CoSoDuLieuDbContext();
        }

        /// <summary>
        /// trả về phiếu đăng kí của sinh viên nàm đó
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PHIEU_DANG_KY PhieuDKSinger(int id)
        {
            return db.PHIEU_DANG_KY.SingleOrDefault(x => x.ID_PHIEU_DANG_KY == id);
        }

        /// <summary>
        /// trả về danh sách năm học
        /// </summary>
        /// <returns></returns>
        public List<NAM_HOC> ListNamHoc()
        {
            return db.NAM_HOC.Where(x => x.TRANGTHAI == true).ToList();
        }

        /// <summary>
        /// trả về dánh sách học kì
        /// </summary>
        /// <returns></returns>
        public List<HOC_KY> ListHocKy()
        {
            return db.HOC_KY.ToList();
        }

        /// <summary>
        /// trả về ds phiếu của sinh viên nàm đó
        /// </summary>
        /// <param name="IDSinhVien"></param>
        /// <returns></returns>
        public List<PHIEU_DANG_KY> ListPhieuDangKy(int IDSinhVien)
        {
            return db.PHIEU_DANG_KY.Where(x => x.ID_SINHVIEN == IDSinhVien).ToList();
        }

        /// <summary>
        /// tạo mới phiếu đăng kí
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreatePhieuDangKy(PHIEU_DANG_KY model)
        {
            int i = 0;
            try
            {
                var timlai = db.PHIEU_DANG_KY.Count(x => x.ID_SINHVIEN == model.ID_SINHVIEN && x.ID_NAM_HOC == model.ID_NAM_HOC && x.ID_HOC_KY == model.ID_HOC_KY);
                if (timlai == 0)
                {
                    db.PHIEU_DANG_KY.Add(model);
                    db.SaveChanges();
                    i = model.ID_PHIEU_DANG_KY;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return i;
        }
    }
}
