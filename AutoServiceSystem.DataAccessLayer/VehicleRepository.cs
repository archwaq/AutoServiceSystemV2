using System.Collections.Generic;
using System.Linq;

namespace AutoServiceSystem.DataAccessLayer
{
    public class VehicleRepository : IRepository<BusinessObject.Vehicle>
    {
        public void Create(BusinessObject.Vehicle vehicle)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbObject = Mapping.ToDatabaseEntity(vehicle);
                db.Vehicles.Add(dbObject);
                db.SaveChanges();
            }
        }

        public void Delete(BusinessObject.Vehicle vehicle)
        {
            Delete(vehicle.Id);
        }

        public void Delete(int id)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var vehicle = db.Vehicles.FirstOrDefault(x => x.id == id);
                db.Vehicles.Remove(vehicle);
                db.SaveChanges();
            }
        }

        public BusinessObject.Vehicle Read(int id)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var vehicle = db.Vehicles.FirstOrDefault(x => x.id == id);
                return Mapping.ToBusinessEntity(vehicle);
            }
        }

        public List<BusinessObject.Vehicle> ReadAll()
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var vehicles = db.Vehicles.ToList();

                var result = new List<BusinessObject.Vehicle>();

                foreach (var vehicle in vehicles)
                {
                    result.Add(Mapping.ToBusinessEntity(vehicle));
                }
                return result;
            }
        }

        public void Update(BusinessObject.Vehicle vehicle)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbVehicle = db.Vehicles.FirstOrDefault(x => x.id == vehicle.Id);
                dbVehicle.RegistrationPlate = vehicle.RegistrationPlate;
                dbVehicle.Color = vehicle.Color;
                dbVehicle.Client = Mapping.ToDatabaseEntity(vehicle.Client);
                db.SaveChanges();
            }
        }
    }
}
