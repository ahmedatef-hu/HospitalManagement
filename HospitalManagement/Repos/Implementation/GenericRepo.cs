using HospitalManagement.Data;
using HospitalManagement.Repos.Interface;

namespace HospitalManagement.Repos.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext context;
        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return context.Set<T>().Find(Id);
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
