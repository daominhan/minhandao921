using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bangaubong.Models
{
    public class BangaubongDBContext : DbContext
    {
        public BangaubongDBContext() : base("Name=ChuoiKetNoi")
        {
        }
        public virtual DbSet<Mproduct> Products { get; set; }
        public virtual DbSet<Mcategory> Categories { get; set; }
        public virtual DbSet<Mcontact> Contact { get; set; }
        public virtual DbSet<Mmenu> Menus { get; set; }
        public virtual DbSet<Morderdetail> Orderdetails { get; set; }
        public virtual DbSet<Morders> Orders { get; set; }
        public virtual DbSet<Mpost> Posts { get; set; }
        public virtual DbSet<Mslider> Sliders { get; set; }
        public virtual DbSet<Mtopic> Topics { get; set; }
        public virtual DbSet<Muser> Users { get; set; }

        public virtual DbSet<Mlink> Links { get; set; }
    }
}