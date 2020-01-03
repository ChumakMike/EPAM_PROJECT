using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDTO {
    public class BlogDTO {

        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ArticleDTO> ArticleDTOs { get; set; }
    }
}
