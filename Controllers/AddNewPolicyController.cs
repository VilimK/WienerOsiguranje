using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WienerOsiguranje.Controllers
{
    public class AddNewPolicyController : Controller
    {
        public bool AddNewPolicyWithPartnerNumber(string partnerNumber, string amount)
        {
            DataAccess db = new DataAccess();
            decimal amount_dec = decimal.Parse(amount);
            db.CreateNewPolicy(partnerNumber, amount_dec);
            return true;
        }
    }
}