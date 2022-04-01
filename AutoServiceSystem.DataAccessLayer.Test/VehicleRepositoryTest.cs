using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoServiceSystem.DataAccessLayer.Test
{
    [TestClass]
    public class VehicleRepositoryTest
    {
        [TestMethod]
        public void ReadAll()
        {
            var vehicleRepo = new VehicleRepository();
            var allVehicles = vehicleRepo.ReadAll();

            foreach (var vehicle in allVehicles)
            {
                Console.WriteLine(vehicle.Id);
            }
        }

        [TestMethod]
        public void ReadById()
        {
            var vehicleRepo = new VehicleRepository();
            var singleVehicle = vehicleRepo.Read(1004);

            Console.WriteLine(singleVehicle.Id);
        }

        [TestMethod]
        public void Create()
        {
            var vehicleRepo = new VehicleRepository();
            var vehicle = new BusinessObject.Vehicle();

            var clientRepo = new ClientRepository();
            var singleClient = clientRepo.Read(2004);

            vehicle.VIN = "12S4Z902S";
            vehicle.RegistrationPlate = "TO4321LM";
            vehicle.Make = "TestMake";
            vehicle.Model = "TestModel";
            vehicle.Color = "Red";
            vehicle.Client = singleClient;

            vehicleRepo.Create(vehicle);
        }

        [TestMethod]
        public void Update()
        {
            var vehicleRepo = new VehicleRepository();
            var vehicle = new BusinessObject.Vehicle();

            var clientRepo = new ClientRepository();
            var singleClient = clientRepo.Read(2004);

            vehicle.Id = 1003;
            vehicle.RegistrationPlate = "YO4321ML";
            vehicle.Color = "Blue";
            vehicle.Client = singleClient;

            vehicleRepo.Update(vehicle);
        }

        [TestMethod]
        public void Delete()
        {
            var vehicleRepo = new VehicleRepository();
            vehicleRepo.Delete(1006);
        }
    }
}
