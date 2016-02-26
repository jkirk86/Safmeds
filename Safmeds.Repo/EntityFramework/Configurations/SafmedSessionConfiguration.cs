using Safmeds.Repository;
using Safmeds.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safmeds.Repo.EntityFramework.Configurations
{
    class SafmedSessionConfiguration : EntityTypeConfiguration<SafmedSession>
    {
        public SafmedSessionConfiguration()
        {
            HasKey(x => x.SafmedSessionId);
        }
    }
}
