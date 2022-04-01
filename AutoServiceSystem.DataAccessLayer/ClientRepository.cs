using System.Collections.Generic;
using System.Linq;

namespace AutoServiceSystem.DataAccessLayer
{
    public class ClientRepository : IRepository<BusinessObject.Client>
    {
        public void Create(BusinessObject.Client client)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbObject = Mapping.ToDatabaseEntity(client);
                db.Clients.Add(dbObject);
                db.SaveChanges();
            }
        }
        public void Delete(BusinessObject.Client client)
        {
            Delete(client.Id);
        }
        public void Delete(int id)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var client = db.Clients.FirstOrDefault(x => x.id == id);
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }
        public BusinessObject.Client Read(int id)
        {

            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var client = db.Clients.FirstOrDefault(x => x.id == id);
                return Mapping.ToBusinessEntity(client);
            }
        }
        public List<BusinessObject.Client> ReadAll()
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var clients = db.Clients.ToList();

                var result = new List<BusinessObject.Client>();

                foreach (var client in clients)
                {
                    result.Add(Mapping.ToBusinessEntity(client));
                }
                return result;
            }
        }
        public void Update(BusinessObject.Client client)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbClient = db.Clients.FirstOrDefault(x => x.id == client.Id);
                dbClient.Phone = client.Phone;
                dbClient.Address = client.Address;
                db.SaveChanges();
            }
        }
    }
}
