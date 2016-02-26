using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safmeds.Repo.Repositories;
using Safmeds.Repository.Models;
using Safmeds.Repo.Enums;

namespace Safmeds.Core
{
    public class DataService : IDataService
    {
        private readonly ISafmedSessionRepository _safmedSessionRepository;
        private readonly ISafmedRepository _safmedRepository;

        public DataService(ISafmedSessionRepository safmedSessionRepo, ISafmedRepository safmedRepo)
        {
            _safmedSessionRepository = safmedSessionRepo;
            _safmedRepository = safmedRepo;
        }

        public List<SafmedSession> GetAllSafmedSessions()
        {
            return _safmedSessionRepository.GetAllSafmedSessions();
        }

        public int CreateSafmedSession(SafmedSession session)
        {
            return _safmedSessionRepository.CreateSafmedSession(session);
        }

        public List<Safmed> GetAllSafmeds()
        {
            return _safmedRepository.GetAllSafmeds();
        }

        public bool IsAnswerCorrect(int questionId, int providedAnswer, out int actualAnswer)
        {
            return _safmedRepository.IsAnswerCorrect(questionId, providedAnswer, out actualAnswer);
        }

        public Safmed GetRandomQuestion(Tuple<Levels, Topics> category)
        {
            return _safmedRepository.GetRandomQuestion(category);
        }
    }
}
