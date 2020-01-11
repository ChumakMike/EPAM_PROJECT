using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.DBContext;
using DAL.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories {
    public class BlogRepository : IBlogRepository {

        private ApplicationContext appContext;

        public BlogRepository(ApplicationContext appContext) {
            this.appContext = appContext;
        }

        public void Create(Blog entity) {
            appContext.Blogs.Add(entity);
        }

        public IEnumerable<Blog> GetAll() {
            return appContext.Blogs;
        }

        public Blog GetById(int id) {
            return appContext.Blogs.Find(id);
        }

        public void Remove(Blog entity) {
            var local = appContext.Set<Blog>()
                         .Local
                         .FirstOrDefault(x => x.BlogId == entity.BlogId);
            if (local != null) {
                appContext.Entry(local).State = EntityState.Detached;
            }
            appContext.Blogs.Attach(entity);
            appContext.Entry(entity).State = EntityState.Deleted;
            appContext.Blogs.Remove(entity);
        }

        public void Update(Blog entity) {
            var local = appContext.Set<Blog>()
                         .Local
                         .FirstOrDefault(x => x.BlogId == entity.BlogId);
            if (local != null) {
                appContext.Entry(local).State = EntityState.Detached;
            }
            appContext.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose() {
            appContext.Dispose();
        }
    }
}
