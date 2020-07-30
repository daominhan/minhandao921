using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bangaubong.Models
{
    [Table("Orders")]
    public class Morders
    {
        public int Id { get; set; }
        public int CustemerId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExportDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryName { get; set; }
        public int Status { get; set; }
    }
}