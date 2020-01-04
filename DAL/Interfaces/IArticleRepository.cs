﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces {
    public interface IArticleRepository : IRepository<Article> {
        Task<IEnumerable<Article>> GetAllWithComments();
        Task<Article> GetWithCommentsById();
    }
}