using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ModelsDTO;

namespace BLL.Interfaces {
    public interface IArticleService {
        ArticleDTO GetById(int id);
        Task<IEnumerable<ArticleDTO>> GetAll();
        Task Create(ArticleDTO entity);
        void Remove(int id);
        void Update(ArticleDTO entity);
        Task<IEnumerable<ArticleDTO>> GetAllWithComments();
        Task<ArticleDTO> GetWithCommentsById();
    }
}
