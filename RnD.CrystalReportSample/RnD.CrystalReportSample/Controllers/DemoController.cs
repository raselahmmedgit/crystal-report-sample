using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RnD.CrystalReportSample.Models;

namespace RnD.CrystalReportSample.Controllers
{
    public class DemoController : Controller
    {
        AppDbContext _db = new AppDbContext();

        //
        // GET: /Demo/

        public ActionResult Basic()
        {
            return View();
        }

        //BasicTtx
        public ActionResult BasicTtx()
        {
            return View();
        }

        //MasterDetails
        public ActionResult MasterDetails(int id)
        {
            return View();
        }

        //SubReport
        public void SubReport(int id)
        {
            Response.Redirect("~/WebViews/SubReport.aspx?catgoryId=" + id);
            //return View();
        }

        //SubReportTtx
        public void SubReportTtx(int id)
        {
            Response.Redirect("~/WebViews/SubReportTtx.aspx?catgoryId=" + id);
            //return View();
        }
    }
}
