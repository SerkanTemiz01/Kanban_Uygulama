using Entities.Concrete;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface IWork
    {
        int ID { get; set; }
        string WorkName { get; set; }

        State States { get; set; }

        int? UserID { get; set; }
        User User { get; set; }
    }
}
