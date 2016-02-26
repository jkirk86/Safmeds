using Safmeds.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safmeds.Repo.Repositories
{
    public interface ISafmedSessionRepository
    {
        List<SafmedSession> GetAllSafmedSessions();
        int CreateSafmedSession(SafmedSession session);
    }
}
