using Entities.Abstract;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Work : IBaseEntity, IWork
    {
        public int ID {get;set; }
       
        public string WorkName { get;set; }

        public State States {get;set; }
        public DateTime CreatedDate {get;set; }= DateTime.Now;
        public DateTime? ModifiedDate {get;set; }
        public DateTime? DeletedDate {get;set; }
        public string CreatedBy {get;set; }
        public string DeletedBy {get;set; }
        public string ModifiedBy {get;set; }
        public Status Status { get; set; } = Status.Active;

        public virtual User User { get; set; }
        public int? UserID { get ; set ; }

       
    }
}
