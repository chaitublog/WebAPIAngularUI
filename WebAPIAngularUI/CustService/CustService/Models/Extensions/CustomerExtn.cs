using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations.Schema;
namespace CustService.Models
{
    public partial class Customer
    {
        
        [NotMapped]
        public double NumMonthsCustomer {
            get {
                return Math.Round(System.DateTime.Now.Subtract(CustRegisterData).TotalDays / 365, 3);
            }
         }

        [NotMapped]
        public string UserFullName
        {
            get { return (CustFirstName + "  " + CustLastName);
            }

        }
    }
}
