using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WienerOsiguranje.Models;

namespace WienerOsiguranje.Controllers
{
    public class AddNewPartnerController : Controller
    {
        public ActionResult PreparePartnerAddingForm()
        {
            string relativePath = "~/Views/Content/addNewPartner.html";
            string absolutePath = Url.Content(relativePath);
            return Content(absolutePath, "text/html");
        }

        public void CreateNewPartner(string firstName, string lastName, string address,string partnerNumber, string croatianPIN,string partnerTypeID,string createdByUser,bool isForeign, string externalCode,char gender)
        {
            //Filter
            int PartnerTypeID = 0;

            if (partnerTypeID == "1") PartnerTypeID = 1;
            else if (partnerTypeID == "2") PartnerTypeID = 2;

            DataAccess database = new DataAccess();
            database.InsertNewPartnerInDatabase(firstName,lastName,address,partnerNumber,croatianPIN,PartnerTypeID,createdByUser,isForeign,externalCode,gender);
        }
    }
}