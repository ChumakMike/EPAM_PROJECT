using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDTO {
    public class ArticleDTO {

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string ArticleBody { get; set; }

        public int BlogRefId { get; set; }
        public BlogDTO BlogDTO { get; set; }

        public virtual ICollection<CommentDTO> CommentDTOs { get; set; }
    }
}
