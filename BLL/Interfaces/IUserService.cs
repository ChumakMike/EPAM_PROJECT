using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace BLL.Interfaces {
    public interface IUserService {
        Task<IdentityResult> Register(string name, string password);
        Task<IdentityUser> FindUser(string name, string password);
    }
}
