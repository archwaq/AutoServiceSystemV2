using AutoServiceSystem.BusinessObject;
using AutoServiceSystem.DataAccessLayer;
using System.Web.Mvc;

namespace AutoServiceSystem.WebServer.Controllers
{
    [ValidateInput(false)]
    public class RepairController : Controller
    {
        private RepairRepository repairRepository = new RepairRepository();

        [HttpGet]
        [Route("repair/index")]
        public ActionResult Index()
        {
            var repairs = repairRepository.ReadAll();
            return View(repairs);
        }

        [HttpGet]
        [Route("repair/create")]
        public ActionResult Create()
        {
            return View(new Repair());
        }

        [HttpPost]
        [Route("repair/create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Repair repair)
        {
            if (this.ModelState.IsValid)
            {
                repairRepository.Create(repair);
                return Redirect("/repair/index");
            }
            return View(repair);
        }

        [HttpGet]
        [Route("repair/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            var repair = repairRepository.Read(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
                
            return View(repair);
        }

        [HttpPost]
        [Route("repair/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Repair repairModel)
        {
            var repair = repairRepository.Read(id);

            if (repair == null)
            {
                return HttpNotFound();
            }
                
            if (this.ModelState.IsValid)
            {
                repair.Description = repairModel.Description;
                repair.Price = repairModel.Price;
                repair.Vehicle.Id = repairModel.Vehicle.Id;

                repairRepository.Update(repair);
                return Redirect("/repair/index");
            }

            return View("Edit", repairModel);
        }

        [HttpGet]
        [Route("repair/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            var repair = repairRepository.Read(id);
            if (repair == null)
                return HttpNotFound();

            return View(repair);
        }

        [HttpPost]
        [Route("repair/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            var repairModel = repairRepository.Read(id);
            if (repairModel == null)
                return HttpNotFound();

            repairRepository.Delete(repairModel);
            return Redirect("/repair/index");
        }
    }
}