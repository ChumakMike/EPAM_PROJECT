using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {

        private AppContext appContext;
        private ArticleRepository articleRepository;
        private BlogRepository blogRepository;
        private CommentRepository commentRepository;

        public IArticleRepository ArticleRepository => articleRepository = articleRepository ?? new ArticleRepository(appContext);

        public IBlogRepository BlogRepository => blogRepository = blogRepository ?? new BlogRepository(appContext);

        public ICommentRepository CommentRepository => commentRepository = commentRepository ?? new CommentRepository(appContext);

        public void Dispose() {
            appContext.Dispose();
        }

        public void SaveChanges() {
            appContext.SaveChanges();
        }
    }
}
