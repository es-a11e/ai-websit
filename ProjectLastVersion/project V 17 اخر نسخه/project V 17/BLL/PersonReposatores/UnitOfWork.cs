using BLL.IPersonReposatores;
using DAL.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PersonReposatores
{
    public class UnitOfWork : IUnitOfWork   ,IDisposable
    {
        private readonly AppDbContextClass _appDbContextClass;

        public IPersonalReposatores PersonalReposatores { get ; set; }
        public IFatherReposatories FatherReposatories { get; set; }
        public IMotherReposatores MotherReposatores { get; set; }
        public UnitOfWork(AppDbContextClass appDbContextClass)
        {
            PersonalReposatores = new PersonalReposatores(appDbContextClass);
            FatherReposatories = new FatherReposatores(appDbContextClass);
            MotherReposatores = new MotherReposatores(appDbContextClass);
            _appDbContextClass = appDbContextClass;
        }

        public int Complete()
        {
            return _appDbContextClass.SaveChanges(); 
        }

        public void Dispose()
        {
           _appDbContextClass.Dispose();
        }
    }
}
