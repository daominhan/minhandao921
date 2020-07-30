using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bangaubong.Models
{
    [Table("Sliders")]
    public class Mslider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Position { get; set; }
        public string Img { get; set; }
        public int Orders { get; set; }
        public DateTime Created_at { get; set; }
        public int Created_by { get; set; }
        public DateTime Updated_at { get; set; }
        public int Updated_by { get; set; }
        public int Status { get; set; }
    }
}