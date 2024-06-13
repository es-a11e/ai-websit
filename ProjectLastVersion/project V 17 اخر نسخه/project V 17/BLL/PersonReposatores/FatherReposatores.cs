using BLL.IPersonReposatores;
using DAL.AppDbContext;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PersonReposatores
{
    public class FatherReposatores: GenaricReposatores<Father>, IFatherReposatories
    {
        public FatherReposatores(AppDbContextClass appDbContextClass) :base(appDbContextClass)
        {

        }


        
    }
}
