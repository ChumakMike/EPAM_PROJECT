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
    public class CommentRepository : ICommentRepository {

        private ApplicationContext appContext;

        public CommentRepository(ApplicationContext appContext) {
            this.appContext = appContext;
        }

        public void Create(Comment entity) {
            appContext.Comments.Add(entity);
        }

        public IEnumerable<Comment> GetAll() {
            return appContext.Comments;
        }

        public Comment GetById(int id) {
            return appContext.Comments.Find(id);
        }

        public void Remove(Comment entity) {
            var local = appContext.Set<Comment>()
                         .Local
                         .FirstOrDefault(x => x.CommentId == entity.CommentId);
            if (local != null) {
                appContext.Entry(local).State = EntityState.Detached;
            }
            appContext.Comments.Attach(entity);
            appContext.Entry(entity).State = EntityState.Deleted;
            appContext.Comments.Remove(entity);
        }

        public void Update(Comment entity) {
            var local = appContext.Set<Comment>()
                        .Local
                        .FirstOrDefault(x => x.CommentId == entity.CommentId);
            if (local != null) {
                appContext.Entry(local).State = EntityState.Detached;
            }
            appContext.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose() {
            appContext.Dispose();
        }

        public IEnumerable<Comment> GetByArticleId(int ArticleId) {
            return appContext.Comments.Where(x => x.ArticleRefId == ArticleId);
        }
    }
}
