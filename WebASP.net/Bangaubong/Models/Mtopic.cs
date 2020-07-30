using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bangaubong.Models
{
    [Table("Topics")]
    public class Mtopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ParentId { get; set; }
        public int Orders { get; set; }
        public string Metadesc { get; set; }
        public string Metakey { get; set; }
        public DateTime Created_at { get; set; }
        public int Created_by { get; set; }
        public DateTime Updated_at { get; set; }
        public int Updated_by { get; set; }
        public int Status { get; set; }
    }
}