using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bangaubong.Models
{
    [Table("Orderdetails")]
    public class Morderdetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }

    }
}