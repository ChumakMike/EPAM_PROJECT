using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using BLL.Services;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.UnitOfWork;

namespace WebApi.Ninject {
    /// <summary>
    /// Ninject bindings
    /// </summary>
    public class NinjectBindings : NinjectModule {
        
        /// <summary>
        /// Binding of Services, Repositories and UnitOfWork
        /// </summary>
        public override void Load() {
            Bind<IArticleService>().To<ArticleService>();
            Bind<IBlogService>().To<BlogService>();
            Bind<IUserService>().To<UserService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<IArticleRepository>().To<ArticleRepository>();
            Bind<IBlogRepository>().To<BlogRepository>();
            Bind<ICommentRepository>().To<CommentRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}