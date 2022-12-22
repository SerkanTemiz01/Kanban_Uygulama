using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class WorkMapping: EntityTypeConfiguration<Work>
    {
        public WorkMapping()
        {
            
        }
    }
}
