using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ModelsDTO;

namespace BLL.Interfaces {
    public interface IArticleService {
        ArticleDTO GetById(int id);
        IEnumerable<ArticleDTO> GetAll();
        void Create(ArticleDTO entity);
        void Remove(ArticleDTO entity);
        void Update(ArticleDTO entity);
        IEnumerable<ArticleDTO> GetByBlogId(int BlogId);
    }
}
