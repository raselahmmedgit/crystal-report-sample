using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RnD.CrystalReportSample.Models;
using RnD.CrystalReportSample.ViewModels;
using RnD.CrystalReportSample.Helpers;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace RnD.CrystalReportSample.WebViews
{
    public partial class SubReportTtx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AppDbContext _db = new AppDbContext();

            try
            {

                int catgoryId = Convert.ToInt32(Request.QueryString["catgoryId"]);

                //Get Data From Database
                var category = _db.Categories.Find(catgoryId);

                var categoryViewModel = new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.Name

                };

                DataTable catDataTable = ConvertHelper.ConvertObjectToDataTable<CategoryViewModel>(categoryViewModel);

                var productList = _db.Products.ToList().Where(x => x.CategoryId == category.CategoryId).Select(x => new ProductViewModel { ProductId = x.ProductId, ProductName = x.Name, ProductPrice = x.Price }).ToList();

                DataTable proDataTable = ConvertHelper.ConvertListObjectToDataTable<ProductViewModel>(productList);

                // Setting Report Data Source     
                var catReportSource = catDataTable;
                var proReportSource = proDataTable;

                ReportDocument catReportDocument = new ReportDocument();
                string strCatReportPath = Server.MapPath("~/CrystalReports/crptSubReport.rpt");

                //ReportDocument detailsReportDocument = new ReportDocument();
                //string strDetailsReportPath = Server.MapPath("~/CrystalReports/crptDetails.rpt");
                ////Loading Sub Report
                //detailsReportDocument.Load(strDetailsReportPath);
                //detailsReportDocument.SetDataSource(proReportSource);

                //Loading Report
                catReportDocument.Load(strCatReportPath);

                // Setting Report Data Source
                if (catReportSource != null)
                    catReportDocument.SetDataSource(catReportSource);

                ReportDocument detailsReportDocument = catReportDocument.Subreports["crptDetails"];
                detailsReportDocument.SetDataSource(proReportSource);

                this.crptSubReport.ReportSource = catReportDocument;
                //this.crptSubReport.DataBind();

            }
            catch (Exception ex)
            {
                var exp = ex;
                Response.Write(exp);
            }
        }
    }
}