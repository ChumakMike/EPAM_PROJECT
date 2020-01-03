using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace DAL.Models {
    public class Article {

        public Article() {
            Comments = new Collection<Comment>();
        }

        [Key]
        public int ArticleId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Title length should be less than 100 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Artecle's length should be less than 1000 characters")]
        public string ArticleBody { get; set; }

        [ForeignKey("Blog")]
        public int BlogRefId { get; set; }
        public Blog Blog { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
