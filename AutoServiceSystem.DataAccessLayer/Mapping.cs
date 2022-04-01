using System;

namespace AutoServiceSystem.DataAccessLayer
{
    public static class Mapping
    {
        public static BusinessObject.Client ToBusinessEntity(DatabaseEntity.Client client)
        {
            var businessObject = new BusinessObject.Client
            {
                Id = client.id,
                FullName = client.FullName,
                Gender = client.Gender,
                Phone = client.Phone,
                Address = client.Address,
                Email = client.Email,
                NationalCardNumber = client.NationalCardNumber,
                PIN = client.PIN
            };
                
            return businessObject;
        }
        public static DatabaseEntity.Client ToDatabaseEntity(BusinessObject.Client client)
        {
            var databaseObject = new DatabaseEntity.Client
            {
                id = client.Id,
                FullName = client.FullName,
                Gender = client.Gender,
                Phone = client.Phone,
                Address = client.Address,
                Email = client.Email,
                NationalCardNumber = client.NationalCardNumber,
                PIN = client.PIN
            };

            return databaseObject;
        }
        public static BusinessObject.Vehicle ToBusinessEntity(DatabaseEntity.Vehicle vehicle)
        {
            var businessObject = new BusinessObject.Vehicle
            {
                Id = vehicle.id,
                VIN = vehicle.VIN,
                RegistrationPlate = vehicle.RegistrationPlate,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Color = vehicle.Color,
                Client = ToBusinessEntity(vehicle.Client)
            };

            return businessObject;
        }
        public static DatabaseEntity.Vehicle ToDatabaseEntity(BusinessObject.Vehicle vehicle)
        {
            var databaseObject = new DatabaseEntity.Vehicle
            {
                id = vehicle.Id,
                VIN = vehicle.VIN,
                RegistrationPlate = vehicle.RegistrationPlate,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Color = vehicle?.Color,
                Client = ToDatabaseEntity(vehicle.Client)
            };

            return databaseObject;
        }
        public static BusinessObject.Repair ToBusinessEntity(DatabaseEntity.Repair repair)
        {
            var businessObject = new BusinessObject.Repair
            {
                Id = repair.id,
                CreatedDate = (DateTime)repair.CreeatedDate,
                Description = repair.Description,
                Price = repair.Price,
                Vehicle = ToBusinessEntity(repair.Vehicle)
            };

            return businessObject;
        }
        public static DatabaseEntity.Repair ToDatabaseEntity(BusinessObject.Repair repair)
        {
            var databaseObject = new DatabaseEntity.Repair
            {
                id = repair.Id,
                CreeatedDate = repair.CreatedDate,
                Description = repair.Description,
                Price = repair.Price,
                Vehicle = ToDatabaseEntity(repair.Vehicle)
            };

            return databaseObject;
        }
    }
}
    

