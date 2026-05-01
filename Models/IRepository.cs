namespace TrueNetFinalProject.Models
{
    public interface IRepository<T>
    {
        public T GetById(object id);
        IEnumerable<T> All();
        public void Add(T item);
        public void Update(T item);
        public void Delete(T item);
        public void Delete(object id);
    }
}
