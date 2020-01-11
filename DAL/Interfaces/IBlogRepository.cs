using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces {
    public interface IBlogRepository : IDisposable {
        Blog GetById(int id);
        IEnumerable<Blog> GetAll();
        void Create(Blog entity);
        void Remove(Blog entity);
        void Update(Blog entity);
    }
}
