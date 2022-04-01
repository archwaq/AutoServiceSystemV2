using AutoServiceSystem.DataAccessLayer;
using System;

namespace AutoServiceSystem.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientRepo = new ClientRepository();
            //var all = clientRepo.ReadAll();

            //foreach (var item in all)
            //{
            //    Console.WriteLine(item.FullName);
            //}
            var singleClient = clientRepo.Read(1);
            //Console.WriteLine(singleClient.FullName);

            //var client = new BusinessObject.Client();
            //client.FullName = "George";
            //client.Gender = "M";
            //client.Phone = "11111";
            //client.Address = "Germany";
            //client.Email = "teststreet";
            //client.NationalCardNumber = "11111";
            //client.PIN = "333";

            //clientRepo.Create(client);

            //var client = new BusinessObject.Client();
            //client.Id = 2002;
            //client.Phone = "08900000";
            //client.Address = "Varna";
            //clientRepo.Update(client);

            //var client = new BusinessObject.Client();
            //clientRepo.Delete(2002);

            var vehicleRepo = new VehicleRepository();
            //var all = vehicleRepo.ReadAll();

            //foreach (var item in all)
            //{
            //    Console.WriteLine(item.Model);
            //}
            //var single = vehicleRepo.Read(1);
            //Console.WriteLine(single.Client.Id); 

            var vehicle = new BusinessObject.Vehicle();
            //vehicle.VIN = "12S4Z902S";
            //vehicle.RegistrationPlate = "TO4321LM";
            //vehicle.Make = "TestMake";
            //vehicle.Model = "TestModel";
            //vehicle.Color = "Red";
            //vehicle.Client = singleClient;

            //vehicleRepo.Create(vehicle);
            //vehicle.Id = 1002;
            //vehicle.RegistrationPlate = "YO4321ML";
            //vehicle.Color = "Blue";
            //vehicle.Client = singleClient;

            //vehicleRepo.Update(vehicle);
            //vehicleRepo.Delete(1002);

            var singleVehicle = vehicleRepo.Read(1);
            
            var repairRepo = new RepairRepository();
            //var all = repairRepo.ReadAll();
            //foreach (var item in all)
            //{
            //    Console.WriteLine(item.Id);
            //}

            var singleRepair = repairRepo.Read(6);
            //Console.WriteLine(singleRepair.CreatedDate);

            var repair = new BusinessObject.Repair();
            repair.CreatedDate = DateTime.Now;
            repair.Description = "Car wash";
            repair.Price = 10;
            repair.Vehicle = singleVehicle;
            //repairRepo.Create(repair);
            repair.Id = 1003;
            //repairRepo.Update(repair);
            //repairRepo.Delete(1002);
        }

    }
}
