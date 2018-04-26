using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ThongKeDao
    {
        /// <summary>
        /// biến kết nối csdl
        /// </summary>
        private CoSoDuLieuDbContext db = null;
        
        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        public ThongKeDao()
        {
            db = new CoSoDuLieuDbContext();
        }
        /// <summary>
        /// trả về những phiếu đăng kí theo năm và học kỳ
        /// </summary>
        /// <param name="namhoc"></param>
        /// <param name="hocky"></param>
        /// <returns></returns>
        public List<PHIEU_DANG_KY> ThongKePhieuDangKy(int namhoc, int hocky)
        {
            var model = db.PHIEU_DANG_KY.Where(x => x.ID_NAM_HOC == namhoc && x.ID_HOC_KY == hocky).ToList();
            return model;
        }
        public List<CT_PHIEU_DANG_KY> ThongKeCT_PhieuDangKy(int namhoc, int hocky)
        {
            var model = db.CT_PHIEU_DANG_KY.Where(x => x.PHIEU_DANG_KY.ID_NAM_HOC == namhoc && x.PHIEU_DANG_KY.ID_HOC_KY == hocky).OrderByDescending(y=>y.ID_MON_HOC).ToList();
            return model;
        }

        public List<PHIEU_DANG_KY> ListThongKe()
        {
            return db.PHIEU_DANG_KY.ToList();
        }

        public List<CT_PHIEU_DANG_KY> THONGKETONGTINCHITHEOMON(int namhoc, int hocky)
        {
            object[] parameter =
            {
                new SqlParameter("@ID_NAM_HOC", namhoc),
                new SqlParameter("@ID_HOC_KY", hocky),
            };
            return db.Database.SqlQuery<CT_PHIEU_DANG_KY>("TONGTINCHICODUOC @ID_NAM_HOC, @ID_HOC_KY", parameter).ToList();
        }
    }
}
