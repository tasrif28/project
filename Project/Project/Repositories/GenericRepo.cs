using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class GenericRepo<T> : IRepo<T> where T : BaseEntity
    {
        private readonly IList<T> data;
        public GenericRepo()
        {
            this.data = new List<T>();
        }
        public List<T> GetAll()
        {
            return this.data.ToList();
        }
        public T Get(int id)
        {
            return this.data.FirstOrDefault(x => x.Id == id);
        }
        public void Add(T entity)
        {
            this.data.Add(entity);

        }
        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.data.Add(entity);
            }
        }
        public void Update(T entity)
        {
            int i = this.data.IndexOf(entity);
            this.data.RemoveAt(i);
            this.data.Add(entity);
        }
        public void Delete(int id)
        {
            var entity = this.data.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                this.data.Remove(entity);
            }
        }
    }
}
