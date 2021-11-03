using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSystem.DataAccessLayer
{
    public static class Mapping
    {
        /// <summary>
        /// Client method that get Database object as parameter and returns business object.
        /// </summary>
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

        /// <summary>
        /// Client method that get Business object as parameter and returns database object.
        /// </summary>
        public static DatabaseEntity.Client ToDatabaseEntity(BusinessObject.Client client)
        {
            var databaseObject = new DatabaseEntity.Client();
            databaseObject.id = client.Id;
            databaseObject.FullName = client.FullName;
            databaseObject.Gender = client.Gender;
            databaseObject.Phone = client.Phone;
            databaseObject.Address = client.Address;
            databaseObject.Email = client.Email;
            databaseObject.NationalCardNumber = client.NationalCardNumber;
            databaseObject.PIN = client.PIN;
            return databaseObject;
        }

        /// <summary>
        /// Vehicle method that get Database object as parameter and returns business object.
        /// </summary>
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
                ClientID = vehicle.ClientId
            };
            return businessObject;
        }

        /// <summary>
        /// Vehicle method that get Business object as parameter and returns database object.
        /// </summary>
        public static DatabaseEntity.Vehicle ToDatabaseEntity(BusinessObject.Vehicle vehicle)
        {
            var databaseObject = new DatabaseEntity.Vehicle
            {
                id = vehicle.Id,
                VIN = vehicle.VIN,
                RegistrationPlate = vehicle.RegistrationPlate,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Color = vehicle.Color,
                ClientId = vehicle.ClientID
            };

            return databaseObject;
        }

        /// <summary>
        /// Repair method that get Database object as parameter and returns business object.
        /// </summary>
        public static BusinessObject.Repair ToBusinessEntity(DatabaseEntity.Repair repair)
        {
            var businessObject = new BusinessObject.Repair
            {
                Id = repair.id,
                CreatedDate = (DateTime)repair.CreeatedDate,
                Description = repair.Description,
                Price = repair.Price,
                VehicleID = repair.VehicleId
            };
            return businessObject;
        }

        /// <summary>
        /// Repair method that get Business object as parameter and returns database object.
        /// </summary>
        public static DatabaseEntity.Repair ToDatabaseEntity(BusinessObject.Repair repair)
        {
            var databaseObject = new DatabaseEntity.Repair
            {
                id = repair.Id,
                CreeatedDate = repair.CreatedDate,
                Description = repair.Description,
                Price = repair.Price,
                VehicleId = repair.VehicleID
            };
            return databaseObject;
        }
    }
}
    

