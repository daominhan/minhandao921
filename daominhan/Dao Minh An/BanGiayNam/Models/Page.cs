namespace BanGiayNam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Page
    {
        public int Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Title { get; set; }

        [Required]
        [StringLength(40)]
        public string Content { get; set; }

        [Required]
        [StringLength(100)]
        public string Avartar { get; set; }

        [Required]
        [StringLength(255)]
        public string Slug { get; set; }
    }
}
