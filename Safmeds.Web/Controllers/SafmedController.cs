using Safmeds.Repo.Repositories;
using Safmeds.Repository.Models;
using Safmeds.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safmeds.Web.Controllers
{
    public class SafmedController : Controller
    {
        private readonly ISafmedRepository _safmedRepository;

        public SafmedController(ISafmedRepository safmedRepo)
        {
            _safmedRepository = safmedRepo;
        }

        // GET: Safmed
        public ActionResult Index()
        {
            //auto map safmed to vmsafmed then feed index
            var safmeds = _safmedRepository.GetAllSafmeds();
            var safmedsViewModel = AutoMapper.Mapper.Map<List<Safmed>, List<SafmedViewModel>>(safmeds);
            return View(safmedsViewModel);
        }
    }
}