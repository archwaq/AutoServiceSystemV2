using AutoServiceSystem.BusinessObject;
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

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View(new Client());
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (this.ModelState.IsValid)
            {
                clientRepository.Create(client);
                return Redirect("/");
            }
            return View(client);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var client = clientRepository.Read(id);
            if(client == null)
                return HttpNotFound();

            return View(client);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Client clientModel)
        {
            var client = clientRepository.Read(id);
            if (client == null)
                return HttpNotFound();

            if (this.ModelState.IsValid)
            {
                client.FullName = clientModel.FullName;
                client.Gender = clientModel.Gender;
                client.Phone = clientModel.Phone;
                client.Address = clientModel.Address;
                client.Email = clientModel.Email;
                client.NationalCardNumber = clientModel.NationalCardNumber;
                client.PIN = clientModel.PIN;

                clientRepository.Update(client);
                return Redirect("/");
            }

            return View("Edit", clientModel);
        }
    }
}