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
    public class CommentService : ICommentService {
        private IUnitOfWork UnitOfWork;
        private IMapper mapper;

        public CommentService(IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
            ConfigurateMapper();
        }
        public async Task Create(CommentDTO entity) {
            var comment = mapper.Map<Comment>(entity);
            await UnitOfWork.CommentRepository.Create(comment);
            UnitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<CommentDTO>> GetAll() {
            return mapper.Map<IEnumerable<CommentDTO>>(await UnitOfWork.CommentRepository.GetAll());
        }

        public CommentDTO GetById(int id) {
            return mapper.Map<CommentDTO>(UnitOfWork.CommentRepository.GetById(id));
        }

        public void Remove(int id) {
            UnitOfWork.CommentRepository.Remove(id);
        }

        public void Update(CommentDTO entity) {
            var commentToUpdate = mapper.Map<Comment>(entity);
            UnitOfWork.CommentRepository.Update(commentToUpdate);
        }

        public Task<CommentDTO> GetWithArticleById() {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<CommentDTO>> GetAllWithArticle() {
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
