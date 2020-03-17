using GestionOffers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        protected Context _context { get; set; }

        public BaseRepository(Context appDbContext)
        {
            _context = appDbContext;
        }


        public T Add(T entity)
        {
            try
            {
                var res = _context.Set<T>().Add(entity);
                Console.WriteLine(res);
                _context.SaveChanges();
                return res.Entity;

            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                return null;
            }
            
        }

        public bool DeleteById(int id)
        {
            try
            {
                var entity = GetById(id);
                var res = _context.Set<T>().Remove(entity);

                _context.SaveChanges();
                return true;

            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                return false;
            }
        }

        public IEnumerable<T> GetList()
        {
            IEnumerable<T> res = _context.Set<T>().ToList<T>();
            return res;
        }

        public T GetById(int id)
        {
            var res = _context.Set<T>().Find(id);
            return res;
        }

        public bool Delete (T entity) 
        {
            try
            {
                var res = _context.Set<T>().Remove(entity);

                _context.SaveChanges();
                return true;
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message + e.StackTrace);
                return false;
            }
        }

        public T Search(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).First();
        }

        public bool Update(T entity)
        {
            try
            {
                Console.WriteLine(entity);
                
               
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

            return true;
        }


    }
}

