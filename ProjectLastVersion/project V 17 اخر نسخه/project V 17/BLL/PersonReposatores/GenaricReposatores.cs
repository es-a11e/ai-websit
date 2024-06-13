using BLL.IPersonReposatores;
using DAL.AppDbContext;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PersonReposatores
{
    public class GenaricReposatores<T> : IGenaricReposatores<T> where T : class
    {
        private readonly AppDbContextClass _appDbContextClass;

        public GenaricReposatores(AppDbContextClass appDbContextClass)
        {
            _appDbContextClass = appDbContextClass;
        }



        public void Add(T entity)
        {
           _appDbContextClass.Add(entity);
        }

        public void Delete(T entity)
        {
            _appDbContextClass.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            
           if (typeof(T) == typeof(Person))
            {
               return (IEnumerable<T>)_appDbContextClass.Persons.Include(Fa=> Fa.Father).Include(Ma=>Ma.Mother).ToList();
            }
                return _appDbContextClass.Set<T>().ToList();
        }
        public IQueryable<T> GetListOfMissing()
        {
            if (typeof(T) == typeof(Person))
            {
                return (IQueryable<T>)_appDbContextClass.Persons.Where(P => P.Is_he_missing == true).Include(Fa => Fa.Father).Include(Ma => Ma.Mother);
            }
            //return (IQueryable<T>)_appDbContextClass.Persons.Where(P => P.Is_he_missing == true).Include(Fa => Fa.Father).Include(Ma => Ma.Mother);
            return _appDbContextClass.Set<T>();
        }

        public T GetByFatherId(long FatherId)
        {
            

            return _appDbContextClass.Set<T>().Find(FatherId);
        }

        public T GetById(long id)
        {
            if (typeof(T) == typeof(Person))
            {
                return (T)(object)_appDbContextClass.Set<Person>()
                    .Include(Fa => Fa.Father)
                       .Include(Ma => Ma.Mother)
                    .FirstOrDefault(p => p.NationalPerson_Id == id);
            }
            return _appDbContextClass.Set<T>().Find(id);
        }

        //public T GetById(int id)
        //{
        //    return _appDbContextClass.Set<Person>()
        //            .Include(Fa => Fa.Father)
        //            .Include(Ma => Ma.Mother)
        //            .FirstOrDefault(p => p.id == id);


        //    //return _appDbContextClass.Set<T>().Find(id);
        //}



        public void Update(T entity)
        {

            _appDbContextClass.Update(entity);
        }
    }
}
