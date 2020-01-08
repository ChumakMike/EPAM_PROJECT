using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ModelsDTO;

namespace BLL.Interfaces {
    public interface ICommentService {
        CommentDTO GetById(int id);
        Task<IEnumerable<CommentDTO>> GetAll();
        void Create(CommentDTO entity);
        void Remove(int id);
        void Update(CommentDTO entity);
        Task<IEnumerable<CommentDTO>> GetAllWithArticle();
        Task<CommentDTO> GetWithArticleById();
    }
}
