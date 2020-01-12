using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using DAL.Identity;

namespace DAL.Interfaces {
    public interface IUnitOfWork : IDisposable {
        IArticleRepository ArticleRepository { get; }
        IBlogRepository BlogRepository { get; }
        AppUserManager AppUserManager { get; }
        ICommentRepository CommentRepository { get; }
        void SaveChanges();
        Task SaveAsync();
    }
}
