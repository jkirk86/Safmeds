using Safmeds.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safmeds.Repo.Enums;

namespace Safmeds.Repo.Repositories
{
    public interface ISafmedRepository
    {
        List<Safmed> GetAllSafmeds();
        Safmed GetRandomQuestion(Tuple <Levels,Topics> category);
        bool IsAnswerCorrect(int questionId, int providedAnswer, out int actualAnswer);
        Safmed GetSafmed(int safmedId);
    }
}
