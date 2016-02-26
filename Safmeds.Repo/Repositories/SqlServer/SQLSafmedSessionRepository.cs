using Safmeds.Repo.EntityFramework;
using Safmeds.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safmeds.Repo.Repositories.SqlServer
{
    public class SQLSafmedSessionRepository : ISafmedSessionRepository
    {
        private readonly SafmedsContext _context;

        public SQLSafmedSessionRepository(SafmedsContext context)
        {
            _context = context;
        }

        public List<SafmedSession> GetAllSafmedSessions()
        {
            return _context.SafmedSessions.ToList();
        }

        public int CreateSafmedSession(SafmedSession newSession)
        {

            newSession.SessionTime = DateTime.Now;
            _context.SafmedSessions.Add(newSession);
            _context.SaveChanges();

            return newSession.SafmedSessionId;
        }
    }
}
