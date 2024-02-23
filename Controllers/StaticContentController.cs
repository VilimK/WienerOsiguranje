using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WienerOsiguranje.Controllers
{
    public class StaticContentController : Controller
    {
        // GET: StaticContent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ServeContent(string filename)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Content"), filename);

            if (System.IO.File.Exists(fullPath))
            {
                return Content(Url.Content($"~/Content/{filename}"));
            }
            else
            {
                return HttpNotFound(); 
            }
        }
    }
}