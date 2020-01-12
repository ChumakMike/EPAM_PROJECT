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
    public class ArticleService : IArticleService {

        private IUnitOfWork UnitOfWork;
        private IMapper mapper;

        public ArticleService() {
            this.UnitOfWork = new UnitOfWork();
            ConfigurateMapper();
        }


        public void Create(ArticleDTO entity) {
            var article = mapper.Map<Article>(entity);
            UnitOfWork.ArticleRepository.Create(article);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<ArticleDTO> GetAll() {
            return mapper.Map<IEnumerable<ArticleDTO>>(UnitOfWork.ArticleRepository.GetAll());
        }

        public IEnumerable<ArticleDTO> GetByBlogId(int BlogId) {
            return mapper.Map<IEnumerable<ArticleDTO>>(UnitOfWork.ArticleRepository.GetByBlogId(BlogId));
        }

        public ArticleDTO GetById(int id) {
            return mapper.Map<ArticleDTO>(UnitOfWork.ArticleRepository.GetById(id));
        }

        public void Remove(ArticleDTO entity) {
            var existingArticle = GetById(entity.ArticleId);
            if (existingArticle == null) throw new NullReferenceException();
            var articleToRemove = mapper.Map<ArticleDTO, Article>(entity);
            UnitOfWork.ArticleRepository.Remove(articleToRemove);
            UnitOfWork.SaveChanges();

        }

        public void Update(ArticleDTO entity) {
            var existingArticle = GetById(entity.ArticleId);
            if (existingArticle == null) throw new NullReferenceException();
            var articleToUpdate = mapper.Map<ArticleDTO, Article>(entity);
            UnitOfWork.ArticleRepository.Update(articleToUpdate);
            UnitOfWork.SaveChanges();
        }

        private void ConfigurateMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Article, ArticleDTO>();
                cfg.CreateMap<ArticleDTO, Article>();
            });
            mapper = new Mapper(config);
        }
    }
}
