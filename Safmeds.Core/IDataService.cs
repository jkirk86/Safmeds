using Safmeds.Repo.Enums;
using Safmeds.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safmeds.Core
{
    public interface IDataService
    {
        //SafmedSessions
        List<SafmedSession> GetAllSafmedSessions();
        int CreateSafmedSession(SafmedSession session);

        //Safmeds
        List<Safmed> GetAllSafmeds();
        bool IsAnswerCorrect(int questionId, int providedAnswer, out int actualAnswer);
        Safmed GetRandomQuestion(Tuple<Levels, Topics> category);
        
    }
}
