using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using DAL.Models;

namespace DAL.Identity {
    public class AppUserManager : UserManager<ApplicationUser> {
        public AppUserManager(IUserStore<ApplicationUser> store) : base(store) { }
    }
}
