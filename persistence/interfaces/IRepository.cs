using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.model;

namespace app.persistence.interfaces
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);
        List<E> FindAll();
        E Save(E entity);
    }
}
