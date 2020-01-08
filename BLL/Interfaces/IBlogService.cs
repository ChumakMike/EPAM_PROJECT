using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ModelsDTO;

namespace BLL.Interfaces {
    public interface IBlogService {
        BlogDTO GetById(int id);
        Task<IEnumerable<BlogDTO>> GetAll();
        void Create(BlogDTO entity);
        void Remove(int id);
        void Update(BlogDTO entity);
        Task<IEnumerable<BlogDTO>> GetAllWithArticles();
        Task<BlogDTO> GetWithCommentsById(int id);
    }
}
