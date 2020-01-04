namespace DAL {
    using System;
    using System.Data.Entity;
    using System.Linq;
    using DAL.Models;

    public class AppContext : DbContext {
        
        public AppContext()
            : base("name=Context") {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}