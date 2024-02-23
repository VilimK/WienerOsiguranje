using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WienerOsiguranje.Models;

namespace WienerOsiguranje.Controllers
{
    public class HomeController : Controller
    {
 
        public ActionResult Index()
        {
            DataAccess database = new DataAccess();
            List<Partner> partners = database.GetAllPartnersData();
            List<PartnerForTableView> partnersForTableView = PreparePartnersForTableView(partners);
            string partnersJson = Newtonsoft.Json.JsonConvert.SerializeObject(partnersForTableView);
            string htmlContent = System.IO.File.ReadAllText(Server.MapPath("~/Views/Content/home.html"));
            htmlContent = htmlContent.Replace("{{PartnersData}}", partnersJson);
            return Content(htmlContent, "text/html");
        }

        public ActionResult GetPartnerDetails(string id)
        {
            var id_int = Int32.Parse(id);
            DataAccess database = new DataAccess();
            Partner partner = database.GetDataAboutPartnerWithID(id_int);
            return Json(partner);  
        }

        public List<PartnerForTableView> PreparePartnersForTableView(List<Partner> partners)
        {
            List<PartnerForTableView> partnersForTableView= new List<PartnerForTableView>();
            foreach(Partner partner in partners)
            {
                partnersForTableView.Add(new PartnerForTableView(partner)); 
            }
            partnersForTableView = partnersForTableView.OrderBy(o => o.CreatedAtUtc).ToList();
            partnersForTableView.Reverse();
            return partnersForTableView; 
        } 
    }
}