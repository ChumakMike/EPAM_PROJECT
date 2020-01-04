using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;

namespace DAL.Repositories {
    public class BlogRepository : Repository<Blog>, IBlogRepository {

        public BlogRepository(AppContext appContext)
            : base(appContext) { }

        public Task<IEnumerable<Blog>> GetAllWithArticles() {
            throw new NotImplementedException();
        }

        public Task<Blog> GetWithCommentsById(int id) {
            throw new NotImplementedException();
        }
    }
}
