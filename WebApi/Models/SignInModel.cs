using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models {
    /// <summary>
    /// Sign-In Model
    /// </summary>
    public class SignInModel {
        /// <summary>
        /// Sign-In Model UserName
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        /// <summary>
        /// Sign-In Model Password
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}