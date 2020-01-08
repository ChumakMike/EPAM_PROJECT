using BLL.Interfaces;
using BLL.ModelsDTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using AutoMapper;

namespace BLL.Services {
    public class BlogService : IBlogService {
        private IUnitOfWork UnitOfWork;
        private IMapper mapper;

        public BlogService(IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
            ConfigurateMapper();
        }

        public void Create(BlogDTO entity) {
            var blog = mapper.Map<Blog>(entity);
            UnitOfWork.BlogRepository.Create(blog);
            UnitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<BlogDTO>> GetAll() {
            return mapper.Map<IEnumerable<BlogDTO>>(await UnitOfWork.BlogRepository.GetAll());
        }
        
        public BlogDTO GetById(int id) {
            return mapper.Map<BlogDTO>(UnitOfWork.BlogRepository.GetById(id));
        }

        public void Remove(int id) {
            UnitOfWork.BlogRepository.Remove(id);
        }

        public void Update(BlogDTO entity) {
            var blogToUpdate = mapper.Map<Blog>(entity);
            UnitOfWork.BlogRepository.Update(blogToUpdate);
        }

        public Task<IEnumerable<BlogDTO>> GetAllWithArticles() {
            throw new NotImplementedException();
        }

        public Task<BlogDTO> GetWithCommentsById(int id) {
            throw new NotImplementedException();
        }

        private void ConfigurateMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Blog, BlogDTO>();
                cfg.CreateMap<BlogDTO, Blog>();
            });
            mapper = new Mapper(config);
        }
    }
}
