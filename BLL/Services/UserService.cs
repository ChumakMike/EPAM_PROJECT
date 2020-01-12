using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ModelsDTO;
using DAL.Interfaces;
using DAL.UnitOfWork;
using DAL.Models;
using Microsoft.AspNet.Identity;
using AutoMapper;
    
namespace BLL.Services {

    public class UserService : IUserService {

        private IUnitOfWork UnitOfWork;
        private IMapper mapper;

        private IBlogService BlogService;

        public UserService() {
            this.UnitOfWork = new UnitOfWork();
            this.BlogService = new BlogService();
            ConfigurateMapper();
        }

        public async Task<UserDTO> Auth(string userName, string password) {
            ApplicationUser applicationUser = await UnitOfWork.AppUserManager.FindAsync(userName, password);
            return createNewUserDTO(applicationUser);
        }

        public async Task Create(UserDTO userDTO) {
            ApplicationUser existingUser = await UnitOfWork.AppUserManager.FindByEmailAsync(userDTO.Email);
            if(existingUser == null) {

                BlogDTO defaultBlogToCreate = new BlogDTO { Title = "Create new blog title", Description = "Create new description" };
                BlogService.Create(defaultBlogToCreate);

                BlogDTO createdBlog = BlogService.GetAll().Last();

                ApplicationUser userToCreate = new ApplicationUser { Email = userDTO.Email, UserName = userDTO.UserName, BlogRefId = createdBlog.BlogId };
                var resultOfCreation = await UnitOfWork.AppUserManager.CreateAsync(userToCreate, userDTO.Password);

                if (resultOfCreation.Errors.Count() > 0) throw new Exception();
                await UnitOfWork.SaveAsync();
            }
        }

        public IEnumerable<UserDTO> GetAll() {
            List<ApplicationUser> applicationUsers = UnitOfWork.AppUserManager.Users.ToList();
            List<UserDTO> userDTOs = new List<UserDTO>();
            for (int i = 0; i < applicationUsers.Count(); i++)
                userDTOs.Add(createNewUserDTO(applicationUsers[i]));
            return userDTOs;
        }

        public UserDTO GetUserById(string id) {
            ApplicationUser existingUser = UnitOfWork.AppUserManager.FindById(id);
            return createNewUserDTO(existingUser);
        }

        public void Remove(UserDTO userDTO) {
            var existingUser = UnitOfWork.AppUserManager.FindById(userDTO.Id);
            if (existingUser == null) throw new NullReferenceException();   
            UnitOfWork.AppUserManager.Delete(existingUser);
            UnitOfWork.SaveChanges();
        }

        public void Update(UserDTO userDTO) {
            var existingUser = UnitOfWork.AppUserManager.FindById(userDTO.Id);
            if (existingUser == null) throw new NullReferenceException();
            var userToUpdate = mapper.Map<UserDTO, ApplicationUser>(userDTO);
            UnitOfWork.AppUserManager.Update(userToUpdate);
            UnitOfWork.SaveChanges();
        }

        public void Dispose() {
            UnitOfWork.Dispose();
        }

        private void ConfigurateMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<UserDTO, ApplicationUser>();
            });
            mapper = new Mapper(config);
        }

        private UserDTO createNewUserDTO(ApplicationUser applicationUser) {
            return new UserDTO {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                Password = applicationUser.PasswordHash,
                UserName = applicationUser.UserName,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                BlogRefId = applicationUser.BlogRefId
            };
        }
    }
}
