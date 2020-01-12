using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ModelsDTO;

namespace BLL.Interfaces {
    public interface ICommentService {
        CommentDTO GetById(int id);
        void Create(CommentDTO entity);
        void Remove(CommentDTO entity);
        IEnumerable<CommentDTO> GetByArticleId(int ArticleId);
    }
}
