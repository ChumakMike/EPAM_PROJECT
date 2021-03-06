﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ModelsDTO;
using DAL.Interfaces;
using DAL.Models;
using AutoMapper;
using BLL.Exceptions;

namespace BLL.Services {
    public class CommentService : ICommentService {

        private IUnitOfWork UnitOfWork;
        private IMapper mapper;

        public CommentService(IUnitOfWork unitOfWork) {
            this.UnitOfWork = unitOfWork;
            ConfigurateMapper();
        }

        public void Create(CommentDTO entity) {
            var comment = mapper.Map<Comment>(entity);
            UnitOfWork.CommentRepository.Create(comment);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<CommentDTO> GetByArticleId(int ArticleId) {
            return mapper.Map<IEnumerable<CommentDTO>>(UnitOfWork.CommentRepository.GetByArticleId(ArticleId));
        }

        public CommentDTO GetById(int id) {
            return mapper.Map<CommentDTO>(UnitOfWork.CommentRepository.GetById(id));
        }

        public void Remove(CommentDTO entity) {
            var existingComment = GetById(entity.CommentId);
            if (existingComment == null) throw new NoSuchEntityFoundException("Blog with such id does not exist! Nothing to remove!");
            var commentToRemove = mapper.Map<CommentDTO, Comment>(entity);
            UnitOfWork.CommentRepository.Remove(commentToRemove);
            UnitOfWork.SaveChanges();
        }

        private void ConfigurateMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<CommentDTO, Comment>();
            });
            mapper = new Mapper(config);
        }
    }
}
