using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces {
    public interface IArticleRepository : IDisposable {
        Article GetById(int id);
        IEnumerable<Article> GetAll();
        void Create(Article entity);
        void Remove(Article entity);
        void Update(Article entity);
        IEnumerable<Article> GetByBlogId(int BlogId);
    }
}
