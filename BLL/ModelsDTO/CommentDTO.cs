using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDTO {
    public class CommentDTO {

        public int CommentId { get; set; }
        public string CommentBody { get; set; }

        public int ArticleRefId { get; set; }
    }
}
