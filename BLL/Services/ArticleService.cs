using System;
using System.Collections.Generic;
using BLL.Interfaces;
using BLL.ModelsDTO;
using DAL.Interfaces;
using BLL.Exceptions;
using DAL.Models;
using AutoMapper;

namespace BLL.Services {
    public class ArticleService : IArticleService {

        private IUnitOfWork UnitOfWork;
        private IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
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
            if (existingArticle == null) throw new NoSuchEntityFoundException("Article with such id does not exist! Nothing to remove!");
            var articleToRemove = mapper.Map<ArticleDTO, Article>(entity);
            UnitOfWork.ArticleRepository.Remove(articleToRemove);
            UnitOfWork.SaveChanges();
        }

        public void Update(ArticleDTO entity) {
            var existingArticle = GetById(entity.ArticleId);
            if (existingArticle == null) throw new NoSuchEntityFoundException("Article with such id does not exist! Nothing to update!");
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
