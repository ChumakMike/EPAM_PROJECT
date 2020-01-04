using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories {
    public class ArticleRepository : Repository<Article>, IArticleRepository {

        public ArticleRepository(AppContext appContext)
           : base(appContext) { }

        public Task<IEnumerable<Article>> GetAllWithComments() {
            throw new NotImplementedException();
        }

        public Task<Article> GetWithCommentsById() {
            throw new NotImplementedException();
        }
    }
}
