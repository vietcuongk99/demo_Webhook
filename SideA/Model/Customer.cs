using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideA.Model
{
    public class Customer
    {

        public static List<Customer> ListCustomer = new List<Customer>()
        {
            new Customer(){CustomerName ="Nguyễn Văn A"},
            new Customer(){CustomerName ="Nguyễn Văn B"},
            new Customer(){CustomerName ="Nguyễn Văn C"},


        };

        /// <summary>
        /// Constructor
        /// </summary>
        public Customer()
        {
            CustomerID = Guid.NewGuid();
        }

        /// <summary>
        /// ID khach hang
        /// </summary>
        public Guid CustomerID { get; set; }

        /// <summary>
        /// Ten khach hang
        /// </summary>
        public string CustomerName { get; set; }

       
    }
}
