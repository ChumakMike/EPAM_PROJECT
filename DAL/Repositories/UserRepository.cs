using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories {
    public class UserRepository : IUserRepository {

        private AppContext AppContext;
        private UserManager<IdentityUser> userManager; 

        public UserRepository() {
            this.AppContext = new AppContext();
        }

        public async Task<IdentityUser> FindUser(string name, string password) {
            IdentityUser userToFind = await userManager.FindByNameAsync(name);
            return userToFind;
        }

        public async Task<IdentityResult> Register(string name, string password) {
            ApplicationUser user = new ApplicationUser {
                UserName = name
            };
            IdentityResult resultOfRegistration = await userManager.CreateAsync(user, password);
            return resultOfRegistration;
        }
    }
}
