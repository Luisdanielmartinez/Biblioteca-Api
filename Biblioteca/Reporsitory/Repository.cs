using Biblioteca.DbContextAplication;
using Biblioteca.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Reporsitory
{
    //esta es la clase  donde le pasaremos que tablas queremos y los metodos para buscar en la db
    public class Repository <T> : IReporsitory <T> where T:BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error"+ex.Message);
            }
        }

        public IEnumerable<T> GetAllData()
        {
            return entities.AsEnumerable();
        }

        public T GetById(long id)
        {
            return entities.SingleOrDefault(t => t.Id == id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity==null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write("error" + ex.Message);
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity==null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error"+ex.Message);
            }
        }
    }
}
