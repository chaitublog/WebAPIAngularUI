using System;
using System.Collections.Generic;

namespace CustService.Models
{
    public partial class Customer
    {
        public int CustId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public string CustContactNum { get; set; }
        public string CustAddress { get; set; }
        public string CustCountry { get; set; }
        public DateTime CustRegisterData { get; set; }
    }
}
