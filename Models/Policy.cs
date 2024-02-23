using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WienerOsiguranje.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public int PartnerId { get; set; }
        public decimal PolicyAmount { get; set; }
    }
}