using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models {
    public class Blog {

        public Blog() {
            Articles = new Collection<Article>();
        }

        [Key]
        public int BlogId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Title length should be less than 100 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "Description length should be less than 100 characters")]
        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
