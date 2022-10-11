using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.model;

namespace app.persistence.interfaces
{
    public interface IUserRepository : IRepository<long, User>
    {
        User GetUser(String username, String password);
    }
}
