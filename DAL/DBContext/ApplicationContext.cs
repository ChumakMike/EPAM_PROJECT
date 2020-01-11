using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Models;


namespace DAL.DBContext {
    public class ApplicationContext : IdentityDbContext<ApplicationUser> {

        public ApplicationContext()
            : base("AppContext") { }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
