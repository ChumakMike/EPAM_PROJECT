using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories {
    public class Repository<T> : IRepository<T> where T : class {

        public Task Create(T entity) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id) {
            throw new NotImplementedException();
        }

        public void Remove(int id) {
            throw new NotImplementedException();
        }

        public void Update(T entity) {
            throw new NotImplementedException();
        }
    }
}
