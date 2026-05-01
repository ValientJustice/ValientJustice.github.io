using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TrueNetFinalProject.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(Context context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Add(T item)
        {
            entities.Add(item);
            context.SaveChanges();
            int x = 0;
        }

        public IEnumerable<T> All()
        {
            return entities.ToList();
        }

        public void Delete(T item)
        {
            entities.Remove(item);
            context.SaveChanges();
        }

        public void Delete(object id)
        {
            T toDel = GetById(id);
            entities.Remove(toDel);
            context.SaveChanges();
        }

        public T GetById(object id)
        {
            return entities.Find(id);
        }

        public void Update(T item)
        {
            //Address existingItem = GetById(item.AddressId);
            //existingItem.City = item.City;
            //existingItem.State = item.State;
            //existingItem.Street = item.Street;
            //existingItem.Zip = item.Zip;



            context.Attach(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
