using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ModelsDTO;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services {
    public class UserService : IUserService {
        private IUnitOfWork UnitOfWork;

        public UserService(IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
        }

        public Task<IdentityUser> FindUser(string name, string password) {
            return UnitOfWork.UserRepository.FindUser(name, password);
        }

        public async Task<IdentityResult> Register(string name, string password) {
            return await UnitOfWork.UserRepository.Register(name, password);
        }
    }
}
