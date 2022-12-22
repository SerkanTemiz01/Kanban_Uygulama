using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface IUser
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

        string UserName { get; set; }
        string Password { get; set; }

        List<Work> works { get; set; }
    }
}
