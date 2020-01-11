using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models {
    public class Comment {
        public Comment() { }

        [Key]
        public int CommentId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Comment's length should be less than 100 characters")]
        public string CommentBody { get; set; }

        [ForeignKey("Article")]
        public int ArticleRefId { get; set; }
        public Article Article { get; set; }
    }
}
