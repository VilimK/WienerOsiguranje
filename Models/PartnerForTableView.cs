using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WienerOsiguranje.Models
{
    public class PartnerForTableView
    {
        public int PartnerId { get; set; }
        public string FullName { get; set; }
        public string PartnerNumber { get; set; }
        public string CroatianPIN { get; set;}
        public string PartnerTypeID { get; set; }
        public DateTime CreatedAtUtc { get; set; }  
        public string IsForeign { get; set; }
        public string Gender { get; set; }

        public PartnerForTableView(Partner partner)
        {
            this.PartnerId = partner.PartnerId;
            this.FullName = partner.FirstName + " " + partner.LastName;
            this.FullName = AddStarToFullNameIfNeeded(this.FullName, partner.PartnerNumber);
            this.PartnerNumber = (partner.PartnerNumber).ToString();
            this.CroatianPIN = partner.CroatianPIN;
            if (partner.PartnerTypeId == 1) this.PartnerTypeID = "Personal";
            else if (partner.PartnerTypeId == 2) this.PartnerTypeID = "Legal";
            this.CreatedAtUtc = partner.CreatedAtUtc;
            if (partner.IsForeign) this.IsForeign = "Yes";
            else this.IsForeign = "No";
            if (partner.Gender == 'M') this.Gender = "Male";
            else if (partner.Gender == 'F') this.Gender = "Female";
            else this.Gender = "Non-binary";
        }

        public string AddStarToFullNameIfNeeded(string fullName, string partnerNumber)
        {
            DataAccess db = new DataAccess();
            decimal amount = db.GetPartnerPolicyAmount(partnerNumber);
            int numberOfPolicies = db.GetPartnersNumberOfPolicies(partnerNumber);
            if(numberOfPolicies > 5 || amount > 5000)  fullName = fullName.Insert(0, "*");
            return fullName; 
        }
    }
}