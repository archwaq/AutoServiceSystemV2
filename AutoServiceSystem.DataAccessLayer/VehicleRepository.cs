using AutoServiceSystem.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSystem.DataAccessLayer
{
    /// <summary>
    /// Implementing an our interface of vehicle.
    /// </summary>
    public class VehicleRepository : IRepository<BusinessObject.Vehicle>
    {
        // Vehicle's method Create who accept as a parameter Business object.
        // To be able to use Entity Framework and add Vehicle to the collection, it needs to be in Database format.
        public void Create(BusinessObject.Vehicle vehicle)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbObject = Mapping.ToDatabaseEntity(vehicle);
                db.Vehicles.Add(dbObject);
                db.SaveChanges();
            }
        }

        // Vehicle's method Remove. Get property value and Remove it by id.
        public void Delete(BusinessObject.Vehicle vehicle)
        {
            Delete(vehicle.Id);
        }

        // Vehicle's method Remove by id functionality.
        public void Delete(int id)
        {
            // Entity Framework Initialize our entity.
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get first vehicle using LINQ which id match.
                // Remove that vehicle from collection and Save changes.
                var vehicle = db.Vehicles.FirstOrDefault(x => x.id == id);
                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
            }
        }

        // Vehicle's method Get by id functionality.
        public BusinessObject.Vehicle Read(int id)
        {
            // Entity Framework Initialize our entity.
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get first vehicle from collection using LINQ which id match.
                var vehicle = db.Vehicles.FirstOrDefault(x => x.id == id);
                return Mapping.ToBusinessEntity(vehicle);
            }
        }

        // Vehicle's method Get all.
        public List<BusinessObject.Vehicle> ReadAll()
        {
            // Entity Framework Initialize our entity
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get list of all vehicles.
                var vehicles = db.Vehicles.ToList();

                // Create new empty list of own BusinessObject.
                var result = new List<BusinessObject.Vehicle>();

                // Using foreach statement to move through a collection of vehicles.
                foreach (var vehicle in vehicles)
                {
                    // All Database Entities from vehicle convert to Business Entity and added to the empty list.
                    result.Add(Mapping.ToBusinessEntity(vehicle));
                }
                return result;
            }
        }

        // Vehicle's method Update who accept as a parameter Business object.
        // To be able to use Entity Framework and update Vehicle from the collection, it needs to be in Database format.
        public void Update(BusinessObject.Vehicle vehicle)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // Find and Get the vehicle that we want to update from Database.
                var dbVehicle = db.Vehicles.FirstOrDefault(x => x.id == vehicle.Id);
                dbVehicle.VIN = vehicle.VIN;
                dbVehicle.RegistrationPlate = vehicle.RegistrationPlate;
                dbVehicle.Make = vehicle.Make;
                dbVehicle.Model = vehicle.Model;
                dbVehicle.Color = vehicle.Color;
                dbVehicle.ClientId = vehicle.ClientID;
                db.SaveChanges();
            }
        }
    }
}
