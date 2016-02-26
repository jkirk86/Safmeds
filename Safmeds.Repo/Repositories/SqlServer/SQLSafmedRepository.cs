using Safmeds.Repo.EntityFramework;
using Safmeds.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safmeds.Repo.Enums;

namespace Safmeds.Repo.Repositories.SqlServer
{
    public class SQLSafmedRepository : ISafmedRepository
    {
        private readonly SafmedsContext _context;

        public SQLSafmedRepository(SafmedsContext context)
        {
            _context = context;
        }

        public List<Safmed> GetAllSafmeds()
        {
            return _context.Safmeds.ToList();
        }

        public Safmed GetSafmed(int safmedId)
        {
            return _context.Safmeds.ToList().Where(x => x.SafmedId == safmedId).FirstOrDefault();
        }

        public Safmed GetRandomQuestion(Tuple<Levels, Topics> category)
        {
            var collection = GetAllSafmeds().Where(x => x.Level == (int)category.Item1 && x.Topic == category.Item2.ToString());

            Random randomiser = new Random();

            int r = randomiser.Next(collection.Count());

            return collection.ElementAt(r);
        }

        public bool IsAnswerCorrect(int questionId, int providedAnswer, out int actualAnswer)
        {
            Safmed safmed = GetSafmed(questionId);
            actualAnswer = int.Parse(safmed.Answer);

            

            return GetAllSafmeds().Any(x => x.SafmedId == questionId && x.Answer == providedAnswer.ToString().Trim());
        }
    }
}
