using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models {
    public class ApplicationUser : IdentityUser {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [ForeignKey("Blog")]
        public int BlogRefId { get; set; }
        public Blog Blog { get; set; }
    }
}
