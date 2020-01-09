using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces {
    public interface IUserRepository {
        Task<IdentityResult> Register(string name, string password);
        Task<IdentityUser> FindUser(string name, string password);
    }
}
