using AutoServiceSystem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoServiceSystem.Web.Controllers
{
    [ValidateInput(false)]
    public class ClientController : Controller
    {
        private ClientRepository clientRepository = new ClientRepository();

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var clients = clientRepository.ReadAll();
            return View(clients);
        }
    }
}