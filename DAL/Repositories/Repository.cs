using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories {
    public class Repository<T> : IRepository<T> where T : class {

        private AppContext AppContext;
       
        public Repository(AppContext appContext) {
            this.AppContext = appContext;
        }

        public async Task Create(T entity) {
            await AppContext.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAll() {
            return await AppContext.Set<T>().ToListAsync();
        }

        public ValueTask<T> GetById(int id) {
            return AppContext.Set<T>().FindAsync(id);
        }

        public async void Remove(int id) {
            T entityToRemove = await GetById(id);
            AppContext.Set<T>().Remove(entityToRemove);
        }

        public void Update(T entity) {
            AppContext.Set<T>().Attach(entity);
            AppContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
