using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoServiceSystem.DataAccessLayer.Test
{
    [TestClass]
    public class RepairRepositoryTest
    {
        [TestMethod]
        public void ReadAll()
        {
            var repairRepository = new RepairRepository();
            var allRepairs = repairRepository.ReadAll();

            foreach (var repair in allRepairs)
            {
                Console.WriteLine(repair.Id);
            }
        }

        [TestMethod]
        public void ReadById()
        {
            var repairRepository = new RepairRepository();
            var singleRepair = repairRepository.Read(1003);

            Console.WriteLine(singleRepair.Id);
        }

        [TestMethod]
        public void Create()
        {
            var repairRepository = new RepairRepository();
            var repair = new BusinessObject.Repair();

            var vehicleRepository = new VehicleRepository();
            var singleVehicle = vehicleRepository.Read(1005);

            repair.CreatedDate = DateTime.Now;
            repair.Description = "Oil change";
            repair.Price = 60;
            repair.Vehicle = singleVehicle;

            repairRepository.Create(repair);
        }

        [TestMethod]
        public void Update()
        {
            var repairRepository = new RepairRepository();
            var repair = new BusinessObject.Repair();

            var vehicleRepository = new VehicleRepository();
            var singleVehicle = vehicleRepository.Read(1005);

            repair.Id = 1004;
            repair.Description = "Brakes change";
            repair.Price = 460;
            repair.Vehicle = singleVehicle;

            repairRepository.Update(repair);
        }

        [TestMethod]
        public void Delete()
        {
            var repairRepository = new RepairRepository();
            repairRepository.Delete(7);
        }
    }
}
