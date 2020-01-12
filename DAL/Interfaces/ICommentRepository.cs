using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces {
    public interface ICommentRepository : IDisposable {
        Comment GetById(int id);
        IEnumerable<Comment> GetAll();
        void Create(Comment entity);
        void Remove(Comment entity);
        void Update(Comment entity);
        IEnumerable<Comment> GetByArticleId(int ArticleId);
    }
}
