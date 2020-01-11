using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ModelsDTO;

namespace BLL.Interfaces {
    public interface IBlogService {
        BlogDTO GetById(int id);
        IEnumerable<BlogDTO> GetAll();
        void Create(BlogDTO entity);
        void Remove(BlogDTO entity);
        void Update(BlogDTO entity);
    }
}
