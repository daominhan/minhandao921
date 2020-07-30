namespace BanGiayNam.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBBanGiayNam : DbContext
    {
        public DBBanGiayNam()
            : base("name=DBBanGiayNam")
        {
        }

        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.Avartar)
                .IsUnicode(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Img)
                .IsUnicode(false);
        }
    }
}
