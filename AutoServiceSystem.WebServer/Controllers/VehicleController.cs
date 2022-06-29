using AutoServiceSystem.BusinessObject;
using AutoServiceSystem.DataAccessLayer;
using System.Web.Mvc;

namespace AutoServiceSystem.WebServer.Controllers
{
    [ValidateInput(false)]
    public class VehicleController : Controller
    {
        private VehicleRepository vehicleRepository = new VehicleRepository();

        [HttpGet]
        [Route("vehicle/index")]
        public ActionResult Index()
        {
            var vehicles = vehicleRepository.ReadAll();
            return View(vehicles);
        }

        [HttpGet]
        [Route("vehicle/create")]
        public ActionResult Create()
        {
            return View(new Vehicle());
        }

        [HttpPost]
        [Route("vehicle/create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            if (this.ModelState.IsValid)
            {
                vehicleRepository.Create(vehicle);
                return Redirect("/vehicle/index");
            }
            return View(vehicle);
        }

        [HttpGet]
        [Route("vehicle/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            var vehicle = vehicleRepository.Read(id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }
                
            return View(vehicle);
        }

        [HttpPost]
        [Route("vehicle/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Vehicle vehicleModel)
        {
            var vehicle = vehicleRepository.Read(id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }

            if (this.ModelState.IsValid)
            {
                vehicle.VIN = vehicleModel.VIN;
                vehicle.RegistrationPlate = vehicleModel.RegistrationPlate;
                vehicle.Make = vehicleModel.Make;
                vehicle.Model = vehicleModel.Model;
                vehicle.Color = vehicleModel.Color;
                vehicle.Client.Id = vehicleModel.Client.Id;

                vehicleRepository.Update(vehicle);
                return Redirect("/vehicle/index");
            }

            return View("Edit", vehicleModel);
        }

        [HttpGet]
        [Route("vehicle/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            var vehicle = vehicleRepository.Read(id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }

            return View(vehicle);
        }

        [HttpPost]
        [Route("vehicle/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            var vehicleModel = vehicleRepository.Read(id);

            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
                
            vehicleRepository.Delete(vehicleModel);

            return Redirect("/vehicle/index");
        }
    }
}