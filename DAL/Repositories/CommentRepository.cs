using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;


namespace DAL.Repositories {
    public class CommentRepository : Repository<Comment>, ICommentRepository  {

        public CommentRepository(AppContext appContext)
         : base(appContext) { }

        public Task<IEnumerable<Comment>> GetAllWithArticle() {
            throw new NotImplementedException();
        }

        public Task<Comment> GetWithArticleById() {
            throw new NotImplementedException();
        }
    }
}
