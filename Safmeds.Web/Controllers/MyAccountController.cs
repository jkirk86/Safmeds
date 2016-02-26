using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Safmeds.Repo.Repositories;
using Safmeds.Repository.Models;
using Safmeds.Web.ViewModels;
using Safmeds.Core;
using Safmeds.Repo.Enums;
using Microsoft.AspNet.Identity;


namespace Safmeds.Web.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly IDataService _service;

        public MyAccountController(IDataService service)
        {
            _service = service;
        }

        // GET: MyAccount (Overview of progress)
        public ActionResult Index()
        {
            List<SafmedSession> usersSafmedsSessionsList = _service.GetAllSafmedSessions();
            usersSafmedsSessionsList.RemoveAll(x => x.UserName != User.Identity.Name);

            //var lastFiveProducts = products.OrderByDescending(p => p.ProductDate).Take(5);

            var safmedSessionViewModelList = AutoMapper.Mapper.Map<List<SafmedSession>, List<SafmedSessionViewModel>>(usersSafmedsSessionsList);

            safmedSessionViewModelList = safmedSessionViewModelList.OrderByDescending(x => x.SafmedSessionId).Take(5).ToList();

            if (User.Identity.IsAuthenticated)
            {
                return View(safmedSessionViewModelList);
            }
            else
                return View("MustAuthenticate");

            
        }

        //before we load the partial view, we need to know which questions to ask
        public ActionResult GetSafmedDialog()
        {    
            return PartialView("_SafmedDialog");            
        }

        public ActionResult GetSafmedQuestion(Levels level, Topics topic)
        {
            //get random safmed as viewmodel            

            var safmed = _service.GetRandomQuestion(new Tuple<Levels, Topics>(level, topic));
            var safmedViewModel = AutoMapper.Mapper.Map<Safmed, SafmedViewModel>(safmed);
            safmedViewModel.Answer = null;

            return PartialView("_SafmedQuestion", safmedViewModel);    
        }

        public ActionResult CheckAnswerIsCorrect(int questionId, int suppliedAnswer)
        {
            int correctAnswer;
            var result = _service.IsAnswerCorrect(questionId, suppliedAnswer, out correctAnswer);

            string answerMessage;

            if (result)
            {
                answerMessage = string.Format("{0} is correct!", suppliedAnswer.ToString());
            }
            else
            {
                answerMessage = string.Format("Not yet! The correct answer was: {0}", correctAnswer.ToString());
            }

            ViewBag.Correct = result;

            return PartialView("_QuestionResult", answerMessage);
        }

        [HttpPost]
        public ActionResult SaveSafmedSession(Guid userId, int countCorrect, int countIncorrect)
        {
            var userGuid = User.Identity.GetUserId() ?? "USER0000-NOT0-AUTH0-ENTI-CATED0000000";

            //STORE IN SAFMEDSESSION TABLE

            SafmedSessionViewModel sessionViewModel = new SafmedSessionViewModel();
            sessionViewModel.UserId = userId;
            sessionViewModel.Correct = countCorrect;
            sessionViewModel.NotYet = countIncorrect;

            //TODO: Capture information off the page, not static as below
            
            sessionViewModel.Level = 1;
            sessionViewModel.Topic = "Adding";
            sessionViewModel.UserName = "test_user@safmeds.co.uk";

            int lastSession = _service.CreateSafmedSession(AutoMapper.Mapper.Map<SafmedSessionViewModel, SafmedSession>(sessionViewModel));

            //REDIRECT TO INDEX, REFRESH DATA TO SHOW LAST SESSION ETC

            return RedirectToAction("Index");
        }
    }
}