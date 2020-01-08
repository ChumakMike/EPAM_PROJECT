namespace DAL {
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using DAL.Models;
    using System.Configuration;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppContext : IdentityDbContext<ApplicationUser> {

        public AppContext()
            : base("Context") { }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Context"].ConnectionString);
        }*/
    }
}