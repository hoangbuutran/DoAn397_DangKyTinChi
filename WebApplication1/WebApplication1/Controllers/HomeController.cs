using Model.EF;
using Model.DAO;
using System;
using System.Web.Mvc;
using WebApplication1.Common;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : LoginChungController
    {

        CoSoDuLieuDbContext db = null;
        PhieuDangKyDao dao = null;
        MonHocDao daoMonHoc = null;
        CT_PhieuDangKyDao daoCTPhieuDK = null;
        /// <summary>
        /// hàm khởi tạo các đối tượng
        /// </summary>
        public HomeController()
        {
            db = new CoSoDuLieuDbContext();
            dao = new PhieuDangKyDao();
            daoMonHoc = new MonHocDao();
            daoCTPhieuDK = new CT_PhieuDangKyDao();
        }

        /// <summary>
        /// hàm trang chủ của sinh viên
        /// </summary>
        /// <returns>view trang chủ của sinh viên</returns>
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// action tạo phiếu đăng kí tín chỉ
        /// </summary>
        /// <returns></returns>
        public ActionResult TaoPhieuDangKy()
        {
            ViewBag.DSNamHoc = new SelectList(dao.ListNamHoc(), "ID_NAM_HOC", "TEN_NAM_HOC");
            ViewBag.DSHocKy = new SelectList(dao.ListHocKy(), "ID_HOC_KY", "TEN_HOC_KY");
            return View();
        }

        /// <summary>
        /// nhận kết quả đăng kí từ phiếu
        /// </summary>
        /// <param name="model"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Home/Create
        [HttpPost]
        public ActionResult TaoPhieuDangKy(PHIEU_DANG_KY model, FormCollection collection)
        {
            try
            {
                model.TONG_SO_TIN_CHI = 0;
                int i = dao.CreatePhieuDangKy(model);
                if (i != 0)
                {
                    return RedirectToAction("TimMonDangKy", "Home", new { id = i });
                }
                else
                {
                    return View("DaDangKyPhieu");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Tạo Phiếu không thành công");
                return View();
            }
        }

        /// <summary>
        /// action tìm môn đăng kí với mã môn học sinh viên tìm ở gian diện
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TimMonDangKy(int id)
        {
            ViewBag.IDPhieuDangKy = dao.PhieuDKSinger(id);
            ViewBag.DsMon = daoCTPhieuDK.DanhSachMonWithIdPhieu(id);
            return View();
        }

        [HttpPost]
        public ActionResult TimMonDangKy(TimKiemModel model)
        {
            return RedirectToAction("ThemMonVaoPhieuCTH", "Home", new { searchstring = model.chuoitimkiem, idphieu = model.idPhieu });
        }

        [HttpGet]
        public ActionResult ThemMonVaoPhieuCTH(string searchstring, int idphieu)
        {
            ViewBag.IDPhieuDangKy = dao.PhieuDKSinger(idphieu);
            var SinhVien = (SinhVienModel)Session["USER_SESSION"];
            var maSinhVien = SinhVien.MaSinhVien.Substring(0, 2);
            var soDu = int.Parse(maSinhVien) - 20;
            var ngayHienTai = DateTime.Now.Year;
            var soNamDangHoc = 0;
            switch (soDu)
            {
                case 0:
                    {
                        var namVaoHoc = 2014;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 1:
                    {
                        var namVaoHoc = 2015;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 2:
                    {
                        var namVaoHoc = 2016;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 3:
                    {
                        var namVaoHoc = 2017;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 4:
                    {
                        var namVaoHoc = 2018;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 5:
                    {
                        var namVaoHoc = 2019;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 6:
                    {
                        var namVaoHoc = 2020;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 7:
                    {
                        var namVaoHoc = 2021;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 8:
                    {
                        var namVaoHoc = 2022;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 9:
                    {
                        var namVaoHoc = 2023;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 10:
                    {
                        var namVaoHoc = 2024;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 11:
                    {
                        var namVaoHoc = 2025;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 12:
                    {
                        var namVaoHoc = 2026;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 13:
                    {
                        var namVaoHoc = 2027;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 14:
                    {
                        var namVaoHoc = 2028;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 15:
                    {
                        var namVaoHoc = 2029;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 16:
                    {
                        var namVaoHoc = 2030;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 17:
                    {
                        var namVaoHoc = 2031;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 18:
                    {
                        var namVaoHoc = 2032;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 19:
                    {
                        var namVaoHoc = 2033;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
                case 20:
                    {
                        var namVaoHoc = 2034;
                        soNamDangHoc = ngayHienTai - namVaoHoc;
                        break;
                    }
            }
            ViewBag.SoNamDangHoc = soNamDangHoc;
            var mon = daoMonHoc.MonHocSingerwithMaTimKiem(searchstring);
            if (mon != null)
            {
                ViewBag.MONHOC = mon;
            }
            else
            {
                return RedirectToAction("TimMonDangKy", "Home", new { id = idphieu });
            }

            var dsMon = daoCTPhieuDK.DanhSachMonWithIdPhieu(idphieu);
            ViewBag.DsMon = dsMon;
            ViewBag.KetQuaTrungNhomMon = 0;
            ViewBag.KetQuaMonChuyenNganh = 0;
            var KetQuaMonChuyenNganh = new ChuyenNganhMonHocDao().ChuyenNganhMonHocWithIdMonIdChuyenNganh(mon.ID_MON_HOC, (int)SinhVien.idChuyenNganh);
            if (KetQuaMonChuyenNganh == 0)
            {
                ViewBag.KetQuaMonChuyenNganh = 1;
            }
            foreach (var item in dsMon)
            {
                if (item.MON_HOC.TU_CHON == true && item.MON_HOC.NHOM_TU_CHON == mon.NHOM_TU_CHON)
                {
                    ViewBag.KetQuaTrungNhomMon = 1;
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult ThemMonVaoPhieuCTH(CT_PHIEU_DANG_KY model)
        {
            int i = daoCTPhieuDK.AddCTPHIEUDANGKY(model);
            if (i == 1)
            {
                return RedirectToAction("TimMonDangKy", "Home", new { id = model.ID_PHIEU_DANG_KY });
            }
            else if (i == 2)
            {
                return RedirectToAction("TimMonDangKy", "Home", new { id = model.ID_PHIEU_DANG_KY });
            }
            else
            {
                return RedirectToAction("TimMonDangKy", "Home", new { id = model.ID_PHIEU_DANG_KY });
            }
        }

        public ActionResult XemLichSuDangKy()
        {
            var SinhVien = (SinhVienModel)Session["USER_SESSION"];
            return View(dao.ListPhieuDangKy(SinhVien.IdSinhVien));
        }

        public ActionResult XemChiTietPhieu(int id)
        {
            ViewBag.DsMon = daoCTPhieuDK.DanhSachMonWithIdPhieu(id);
            var model = dao.PhieuDKSinger(id);
            return View(model);
        }

        public ActionResult XoaMonTrongPhieu(int idMon, int idCtPhieu, int idPhieuDK)
        {
            var monTrongPhieu = daoCTPhieuDK.MonTrongPhieuSinger(idCtPhieu);
            daoCTPhieuDK.XoaMonTrongPhieuSinger(monTrongPhieu);
            return RedirectToAction("XemChiTietPhieu", "Home", new { id = idPhieuDK });
        }
    }
}
