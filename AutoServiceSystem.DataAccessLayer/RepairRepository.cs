using System.Collections.Generic;
using System.Linq;

namespace AutoServiceSystem.DataAccessLayer
{
    public class RepairRepository : IRepository<BusinessObject.Repair>
    {
        public void Create(BusinessObject.Repair repair)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbObject = Mapping.ToDatabaseEntity(repair);
                db.Repairs.Add(dbObject);
                db.SaveChanges();
            }
        }

        public void Delete(BusinessObject.Repair repair)
        {
            Delete(repair.Id);
        }

        public void Delete(int? id)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var repair = db.Repairs.FirstOrDefault(x => x.id == id);
                db.Repairs.Remove(repair);
                db.SaveChanges();
            }
        }

        public BusinessObject.Repair Read(int? id)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var repair = db.Repairs.FirstOrDefault(x => x.id == id);
                return Mapping.ToBusinessEntity(repair);
            }
        }
        public List<BusinessObject.Repair> ReadAll()
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var repairs = db.Repairs.ToList();

                var result = new List<BusinessObject.Repair>();

                foreach (var repair in repairs)
                {
                    result.Add(Mapping.ToBusinessEntity(repair));
                }
                return result;
            }
        }

        public void Update(BusinessObject.Repair repair)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbRepair = db.Repairs.FirstOrDefault(x => x.id == repair.Id);
                dbRepair.Description = repair.Description;
                dbRepair.Price = repair.Price;
                dbRepair.Vehicle = Mapping.ToDatabaseEntity(repair.Vehicle);
                db.SaveChanges();
            }
        }
    }
}
