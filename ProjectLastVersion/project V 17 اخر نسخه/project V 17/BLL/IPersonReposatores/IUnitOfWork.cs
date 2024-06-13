using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IPersonReposatores
{
    public interface IUnitOfWork
    {
        public IPersonalReposatores PersonalReposatores { get; set; }
        public IFatherReposatories FatherReposatories { get; set; }
        public IMotherReposatores MotherReposatores { get; set; }

        int Complete();
    }
}
