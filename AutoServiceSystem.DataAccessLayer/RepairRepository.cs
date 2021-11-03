using AutoServiceSystem.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSystem.DataAccessLayer
{
    /// <summary>
    /// Implementing an our interface of repair.
    /// </summary>
    public class RepairRepository : IRepository<BusinessObject.Repair>
    {
        // Repair's method Create who accept as a parameter Business object.
        // To be able to use Entity Framework and add Repair to the collection, it needs to be in Database format.
        public void Create(BusinessObject.Repair repair)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbObject = Mapping.ToDatabaseEntity(repair);
                db.Repairs.Add(dbObject);
                db.SaveChanges();
            }
        }

        // Repair's method Remove. Get property value and Remove it by id.
        public void Delete(BusinessObject.Repair repair)
        {
            Delete(repair.Id);
        }

        // Repair's method Remove by id functionality.
        public void Delete(int id)
        {
            // Entity Framework Initialize our entity.
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get first repair using LINQ which id match.
                // Remove that repair from collection and Save changes.
                var repair = db.Repairs.FirstOrDefault(x => x.id == id);
                db.Repairs.Remove(repair);
                db.SaveChanges();
            }
        }

        // Repair's method Get by id functionality.
        public BusinessObject.Repair Read(int id)
        {
            // Entity Framework Initialize our entity.
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get first repair from collection using LINQ which id match.
                var repair = db.Repairs.FirstOrDefault(x => x.id == id);
                return Mapping.ToBusinessEntity(repair);
            }
        }

        // Repair's method Get all.
        public List<BusinessObject.Repair> ReadAll()
        {
            // Entity Framework Initialize our entity
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get list of all repairs.
                var repairs = db.Repairs.ToList();

                // Create new empty list of own BusinessObject.
                var result = new List<BusinessObject.Repair>();

                // Using foreach statement to move through a collection of repairs.
                foreach (var repair in repairs)
                {
                    // All Database Entities from repairs convert to Business Entity and added to the empty list.
                    result.Add(Mapping.ToBusinessEntity(repair));
                }
                return result;
            }
        }

        // Repair's method Update who accept as a parameter Business object.
        // To be able to use Entity Framework and update Repair from the collection, it needs to be in Database format.
        public void Update(BusinessObject.Repair repair)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // Find and Get the repair that we want to update from Database.
                var dbRepair = db.Repairs.FirstOrDefault(x => x.id == repair.Id);
                dbRepair.Description = repair.Description;
                dbRepair.Price = repair.Price;
                dbRepair.VehicleId = repair.VehicleID;
                db.SaveChanges();
            }
        }
    }
}
