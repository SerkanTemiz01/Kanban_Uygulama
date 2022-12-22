using Entities.Abstract;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IBaseEntity, IUser
    {
        public int ID {get;set; }
        public string FirstName {get;set; }
        public string LastName {get;set; }
        public string UserName {get;set; }
        public string Password {get;set; }
        public DateTime CreatedDate {get;set; }=DateTime.Now;
        public DateTime? ModifiedDate {get;set; }
        public DateTime? DeletedDate {get;set; }
        public string CreatedBy {get;set; }
        public string DeletedBy {get;set; }
        public string ModifiedBy {get;set; }

        public Status Status { get; set; } = Status.Active;
        public List<Work> works { get ; set ; }
    }
}
