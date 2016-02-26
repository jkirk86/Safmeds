using Safmeds.Core;
using Safmeds.Repository.Models;
using Safmeds.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safmeds.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDataService _service;

        public AdminController(IDataService service)
        {
            _service = service;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var dbSafmeds = _service.GetAllSafmeds();

            var safmedSessionViewModelList = AutoMapper.Mapper.Map<List<Safmed>, List<SafmedViewModel>>(dbSafmeds);
            return View(safmedSessionViewModelList);
        }
    }
}