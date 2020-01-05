using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ModelsDTO;
using DAL.Interfaces;
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

        public async Task Create(ArticleDTO entity) {
            var article = mapper.Map<Article>(entity);
            await UnitOfWork.ArticleRepository.Create(article);
            UnitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<ArticleDTO>> GetAll() {
            return mapper.Map<IEnumerable<ArticleDTO>>(await UnitOfWork.ArticleRepository.GetAll());
        }

        public ArticleDTO GetById(int id) {
            return mapper.Map<ArticleDTO>(UnitOfWork.ArticleRepository.GetById(id));
        }

        public void Remove(int id) {
            UnitOfWork.ArticleRepository.Remove(id);
        }

        public void Update(ArticleDTO entity) {
            var articleToUpdate = mapper.Map<Article>(entity);
            UnitOfWork.ArticleRepository.Update(articleToUpdate);
        }

        public Task<IEnumerable<ArticleDTO>> GetAllWithComments() {
            throw new NotImplementedException();
        }

        public Task<ArticleDTO> GetWithCommentsById() {
            throw new NotImplementedException();
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
