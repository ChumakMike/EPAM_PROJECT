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
using AutoMapper;


namespace BLL.Services {
    public class BlogService : IBlogService {

        private IUnitOfWork UnitOfWork;
        private IMapper mapper;

        public BlogService() {
            this.UnitOfWork = new UnitOfWork();
            ConfigurateMapper();
        }

        public void Create(BlogDTO entity) {
            var blog = mapper.Map<Blog>(entity);
            UnitOfWork.BlogRepository.Create(blog);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<BlogDTO> GetAll() {
            return mapper.Map<IEnumerable<BlogDTO>>(UnitOfWork.BlogRepository.GetAll());
        }

        public BlogDTO GetById(int id) {
            return mapper.Map<BlogDTO>(UnitOfWork.BlogRepository.GetById(id));
        }

        public void Remove(BlogDTO entity) {
            var existingBlog = GetById(entity.BlogId);
            if (existingBlog == null) throw new NullReferenceException();
            var blogToRemove = mapper.Map<BlogDTO, Blog>(entity);
            UnitOfWork.BlogRepository.Remove(blogToRemove);
            UnitOfWork.SaveChanges();
        }

        public void Update(BlogDTO entity) {
            var existingBlog = GetById(entity.BlogId);
            if (existingBlog == null) throw new NullReferenceException();
            var blogToUpdate = mapper.Map<BlogDTO, Blog>(entity);
            UnitOfWork.BlogRepository.Update(blogToUpdate);
            UnitOfWork.SaveChanges();
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
