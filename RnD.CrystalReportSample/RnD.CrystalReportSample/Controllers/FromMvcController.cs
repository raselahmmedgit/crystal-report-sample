using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using RnD.CrystalReportSample.Models;
using RnD.CrystalReportSample.ViewModels;

namespace RnD.CrystalReportSample.Controllers
{
    public class FromMvcController : Controller
    {
        AppDbContext _db = new AppDbContext();

        //
        // GET: /FromMvc/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormSample()
        {
            return View();
        }

        public ActionResult JavaScriptSample()
        {
            return View();
        }

        //Used for showing simple report
        public void ShowSimple()
        {

            using (ReportClass reportClass = new ReportClass())
            {

                var productList = _db.Products.ToList().Select(x => new ProductViewModel { ProductId = x.ProductId, ProductName = x.Name, ProductPrice = x.Price });

                reportClass.FileName = Server.MapPath("~/") + "//CrystalReports//simple.rpt";
                reportClass.SetDataSource(productList);
                reportClass.Load();
                reportClass.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crystalReport");
            }

        }

    }
}
