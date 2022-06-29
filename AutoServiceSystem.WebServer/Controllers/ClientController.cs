using AutoServiceSystem.BusinessObject;
using AutoServiceSystem.DataAccessLayer;
using System.Web.Mvc;

namespace AutoServiceSystem.WebServer.Controllers
{
    [ValidateInput(false)]
    public class ClientController : Controller
    {
        private ClientRepository clientRepository = new ClientRepository();

        [HttpGet]
        [Route("client/index")]
        public ActionResult Index()
        {
            var clients = clientRepository.ReadAll();
            return View(clients);
        }

        [HttpGet]
        [Route("client/create")]
        public ActionResult Create()
        {
            return View(new Client());
        }

        [HttpPost]
        [Route("client/create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (this.ModelState.IsValid)
            {
                clientRepository.Create(client);
                return Redirect("/client/index");
            }

            return View(client);
        }

        [HttpGet]
        [Route("client/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            var client = clientRepository.Read(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        [HttpPost]
        [Route("client/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Client clientModel)
        {
            var client = clientRepository.Read(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            if (this.ModelState.IsValid)
            {
                client.Phone = clientModel.Phone;
                client.Address = clientModel.Address;

                clientRepository.Update(client);
                return Redirect("/client/index");
            }

            return View("Edit", clientModel);
        }

        [HttpGet]
        [Route("client/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            var client = clientRepository.Read(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        [HttpPost]
        [Route("client/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            var clientModel = clientRepository.Read(id);

            if (clientModel == null)
            {
                return HttpNotFound();
            }

            clientRepository.Delete(clientModel);

            return Redirect("/client/index");
        }
    }
}