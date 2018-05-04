using LinqToExcel;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Common;
using PagedList;

namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class SinhVienController : LoginChungController
    {
        CoSoDuLieuDbContext db = null;
        SinhVienDao dao = null;
        ChuyenNganhDao DaoChuyenNganh = null;
        TaiKhoanDao DaoTaiKhoan = null;
        public SinhVienController()
        {
            db = new CoSoDuLieuDbContext();
            dao = new SinhVienDao();
            DaoChuyenNganh = new ChuyenNganhDao();
            DaoTaiKhoan = new TaiKhoanDao();

        }
        // GET: GiaoVu/SinhVien
        [HttpGet]
        public ActionResult Index(string ChuoiTimKiem, int? page)
        {
            ViewBag.sinhvien = new SinhVienDao().ListSinhVien().Count();
            if (ChuoiTimKiem == null)
            {
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(dao.ListSinhVien().ToPagedList(pageNumber, pageSize));
            }
            else
            {
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(dao.ListSinhVienByCondition(ChuoiTimKiem).ToPagedList(pageNumber, pageSize));
            }
            
        }

        // GET: GiaoVu/SinhVien/Details/5
        public ActionResult Details(int id)
        {
            return View(dao.SinhVienSinger(id));
        }

        // GET: GiaoVu/SinhVien/Create
        public ActionResult Create()
        {
            ViewBag.DsChuyenNganh = new SelectList(DaoChuyenNganh.ListChuyenNganh(), "ID_CHUYEN_NGANH", "TEN_CHUYEN_NGANH");
            return View();
        }

        // POST: GiaoVu/SinhVien/Create
        [HttpPost]
        public ActionResult Create(SINH_VIEN model, FormCollection collection)
        {
            try
            {
                var tentaikhoan1 = model.TEN_SINH_VIEN.ToLower();
                var tentaikhoan2 = dao.RejectMarks(tentaikhoan1);
                var tentaikhoan3 = tentaikhoan2.Replace(" ", "");
                var pass = model.MA_SINH_VIEN.Substring(6);//2121114026
                var taikhoan = new TAIKHOAN
                {
                    USERNAME = tentaikhoan3,
                    PASS = pass,
                    ID_QUYEN = 3
                };
                int i = DaoTaiKhoan.AddTaiKhoan(taikhoan);
                if (i != 0)
                {
                    model.ID_TAI_KHOAN = i;
                    int j = dao.AddSinhVien(model);
                    if (j == 1)
                    {
                        return RedirectToAction("Index");
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
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return RedirectToAction("Index");
        }

        // GET: GiaoVu/SinhVien/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DsChuyenNganh = new SelectList(DaoChuyenNganh.ListChuyenNganh(), "ID_CHUYEN_NGANH", "TEN_CHUYEN_NGANH");
            return View(dao.SinhVienSinger(id));
        }

        // POST: GiaoVu/SinhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(SINH_VIEN model, FormCollection collection)
        {
            try
            {
                int i = dao.SuaSinhVien(model);
                if (i == 1)
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Loi error");
            }
            return View("Index");
        }



        // POST: GiaoVu/SinhVien/Delete/5
        [HttpGet]
        public ActionResult KhoaMo(int id)
        {

            dao.KhoaMo(id);
            return RedirectToAction("Index");
        }


        public FileResult DownloadExcel()
        {
            string path = "/FileExcel/SinhVien.xlsx";
            return File(path, "application/vnd.ms-excel", "SinhVien.xlsx");
        }

        [HttpGet]
        public ActionResult UploadExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadExcel(SINH_VIEN users, HttpPostedFileBase FileUpload)
        {
            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/FileExcel/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();

                    adapter.Fill(ds, "ExcelTable");

                    DataTable dtable = ds.Tables["ExcelTable"];

                    string sheetName = "Sheet1";

                    var excelFile = new ExcelQueryFactory(pathToExcelFile);
                    var artistAlbums = from a in excelFile.Worksheet<SINH_VIEN>(sheetName) select a;

                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.TEN_SINH_VIEN != "" && a.TRANG_THAI != null
                                && a.CMND != "" && a.DIA_CHI != ""
                                && a.DIEN_THOAI != "" && a.MA_SINH_VIEN != ""
                                && a.NGAY_SINH != null
                                && a.EMAIL != "" && a.ID_CHUYEN_NGANH != null)
                            {
                                SINH_VIEN TU = new SINH_VIEN
                                {
                                    TEN_SINH_VIEN = a.TEN_SINH_VIEN,
                                    CMND = a.CMND,
                                    DIEN_THOAI = a.DIEN_THOAI,
                                    DIA_CHI = a.DIA_CHI,
                                    EMAIL = a.EMAIL,
                                    MA_SINH_VIEN = a.MA_SINH_VIEN,
                                    NGAY_SINH = a.NGAY_SINH,
                                    ID_CHUYEN_NGANH = a.ID_CHUYEN_NGANH,
                                    TRANG_THAI = a.TRANG_THAI,
                                };
                                //Trần Hoàng Bửu
                                var tentaikhoan1 = TU.TEN_SINH_VIEN.ToLower();//trần hoàng bửu
                                var tentaikhoan2 = dao.RejectMarks(tentaikhoan1);//tran hoang buu
                                var tentaikhoan3 = tentaikhoan2.Replace(" ", "");//tranhoangbuu
                                var pass = TU.MA_SINH_VIEN.Substring(6);
                                var taikhoan = new TAIKHOAN
                                {
                                    USERNAME = tentaikhoan3,
                                    PASS = pass,
                                    ID_QUYEN = 3
                                };
                                int i = DaoTaiKhoan.AddTaiKhoan(taikhoan);
                                TU.ID_TAI_KHOAN = i;
                                dao.AddSinhVien(TU);
                            }
                            else
                            {
                                data.Add("<ul>");
                                if (a.TEN_SINH_VIEN == "" || a.TEN_SINH_VIEN == null) data.Add("<li> ten sinh vien is required</li>");
                                if (a.TRANG_THAI == null) data.Add("<li> trangthai is required</li>");

                                data.Add("</ul>");
                                data.ToArray();
                                return Json(data, JsonRequestBehavior.AllowGet);
                            }
                        }

                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {
                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                }
                            }
                        }
                    }
                    //deleting excel file from folder  
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    //alert message for invalid file format  
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    ModelState.AddModelError("", data.ToString());
                    return View();
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                ModelState.AddModelError("", data.ToString());
                return View();
            }
        }

    }
}
