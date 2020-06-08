using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Net.Models
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        public Product Product { get; set; }
    }
}
