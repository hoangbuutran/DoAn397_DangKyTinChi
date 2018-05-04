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
using PagedList;
namespace WebApplication1.Areas.GiaoVu.Controllers
{
    public class NamHocController : LoginChungController
    {
        CoSoDuLieuDbContext db = new CoSoDuLieuDbContext();
        NamHocDao namHocDao = new NamHocDao();
        // GET: GiaoVu/NamHoc
        public ActionResult Index(int? page)
        {
            ViewBag.NamHoc = new NamHocDao().ListNamHoc().Count();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(namHocDao.ListNamHoc().ToPagedList(pageNumber, pageSize));
        }

        //// GET: GiaoVu/NamHoc/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View(namHocDao.NamHocSinger(id));
        //}

        // GET: GiaoVu/NamHoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiaoVu/NamHoc/Create
        [HttpPost]
        public ActionResult Create(NAM_HOC model, FormCollection collection)
        {
            try
            {
                if (namHocDao.AddNamHoc(model) != 0)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: GiaoVu/NamHoc/Edit/5
        public ActionResult Edit(int id)
        {
            return View(namHocDao.NamHocSinger(id));
        }

        // POST: GiaoVu/NamHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(NAM_HOC model, FormCollection collection)
        {
            try
            {
                if (namHocDao.SuaNamHoc(model) != 0)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit", new { id = model.ID_NAM_HOC });
            }
            catch
            {
                return View("Edit", new { id = model.ID_NAM_HOC });
            }
        }

        // GET: GiaoVu/NamHoc/Delete/5
        public ActionResult KhoaMo(int id)
        {
            namHocDao.KhoaMo(id);
            return RedirectToAction("Index");
        }

        public FileResult DownloadExcel()
        {
            string path = "/FileExcel/NamHoc.xlsx";
            return File(path, "application/vnd.ms-excel", "NamHoc.xlsx");
        }

        [HttpGet]
        public ActionResult UploadExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadExcel(NAM_HOC users, HttpPostedFileBase FileUpload)
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
                    var artistAlbums = from a in excelFile.Worksheet<NAM_HOC>(sheetName) select a;

                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.TEN_NAM_HOC != "" && a.TRANGTHAI != null)
                            {
                                NAM_HOC TU = new NAM_HOC
                                {
                                    TEN_NAM_HOC = a.TEN_NAM_HOC,
                                    TRANGTHAI = a.TRANGTHAI,
                                };
                                db.NAM_HOC.Add(TU);
                                db.SaveChanges();
                            }
                            else
                            {
                                data.Add("<ul>");
                                if (a.TEN_NAM_HOC == "" || a.TEN_NAM_HOC == null) data.Add("<li> Tennamhoc is required</li>");
                                if (a.TRANGTHAI == null) data.Add("<li> trangthai is required</li>");

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
                    ModelState.AddModelError("",data.ToString());
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
