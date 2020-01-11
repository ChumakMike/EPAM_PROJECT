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
    public class ArticleRepository : IArticleRepository {
        private ApplicationContext appContext;
        
        public ArticleRepository(ApplicationContext appContext) {
            this.appContext = appContext;
        }

        public void Create(Article entity) {
            appContext.Articles.Add(entity);
        }

        public IEnumerable<Article> GetAll() {
            return appContext.Articles;
        }

        public Article GetById(int id) {
            return appContext.Articles.Find(id);
        }

        public void Remove(Article entity) {
            var local = appContext.Set<Article>()
                        .Local
                        .FirstOrDefault(x => x.ArticleId == entity.ArticleId);
            if (local != null) {
                appContext.Entry(local).State = EntityState.Detached;
            }
            appContext.Articles.Attach(entity);
            appContext.Entry(entity).State = EntityState.Deleted;
            appContext.Articles.Remove(entity);
        }

        public void Update(Article entity) {
            var local = appContext.Set<Article>()
                         .Local
                         .FirstOrDefault(x => x.ArticleId == entity.ArticleId);
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
