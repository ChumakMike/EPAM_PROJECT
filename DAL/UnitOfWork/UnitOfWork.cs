using System;
using System.Threading.Tasks;
using DAL.Identity;
using DAL.Models;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.DBContext;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.UnitOfWork {

    public class UnitOfWork : IUnitOfWork {

        private ApplicationContext appContext;
        private ArticleRepository articleRepository;
        private BlogRepository blogRepository;
        private CommentRepository commentRepository;
        private AppUserManager userManager;


        public UnitOfWork() {
            appContext = new ApplicationContext();
            articleRepository = new ArticleRepository(appContext);
            blogRepository = new BlogRepository(appContext);
            userManager = new AppUserManager(new UserStore<ApplicationUser>(appContext));
            commentRepository = new CommentRepository(appContext);
        }

        public IArticleRepository ArticleRepository {
            get {
                return articleRepository;
            }
        }

        public IBlogRepository BlogRepository {
            get {
                return blogRepository;
            }
        }

        public AppUserManager AppUserManager {
            get {
                return userManager;
            }
        }

        public ICommentRepository CommentRepository {
            get {
                return commentRepository;
            }
        }

        private bool disposed = false;

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if(!this.disposed) {
                if(disposing) {
                    articleRepository.Dispose();
                    blogRepository.Dispose();
                    userManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync() {
            await appContext.SaveChangesAsync();
        }

        public void SaveChanges() {
            appContext.SaveChanges();
        }
    }
}
