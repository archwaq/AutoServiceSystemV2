using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSystem.DataAccessLayer
{
    /// <summary>
    /// Implementing an our interface of client.
    /// </summary>
    public class ClientRepository : IRepository<BusinessObject.Client>
    {
        // Client's method Create who accept as a parameter Business object.
        // To be able to use Entity Framework and add Client to the collection, it needs to be in Database format.
        public void Create(BusinessObject.Client client)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                var dbObject = Mapping.ToDatabaseEntity(client);
                db.Clients.Add(dbObject);
                db.SaveChanges();
            }
        }

        // Client's method Remove. Get property value and Remove it by id.
        public void Delete(BusinessObject.Client client)
        {
            Delete(client.Id);
        }

        // Client's method Remove by id functionality.
        public void Delete(int id)
        {
            // Entity Framework Initialize our entity.
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get first client using LINQ which id match.
                // Remove that client from collection and Save changes.
                var client = db.Clients.FirstOrDefault(x => x.id == id);
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        // Client's method Get by id functionality.
        public BusinessObject.Client Read(int id)
        {
            // Entity Framework Initialize our entity.
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get first client from collection using LINQ which id match.
                var client = db.Clients.FirstOrDefault(x => x.id == id);
                return Mapping.ToBusinessEntity(client);
            }
        }

        // Client's method Get all.
        public List<BusinessObject.Client> ReadAll()
        {
            // Entity Framework Initialize our entity.
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // From Database Entity get list of all clients.
                var clients = db.Clients.ToList();

                // Create new empty list of own BusinessObject.
                var result = new List<BusinessObject.Client>();

                // Using foreach statement to move through a collection of clients.
                foreach (var client in clients)
                {
                    // All Database Entities from client convert to Business Entity and added to the empty list.
                    result.Add(Mapping.ToBusinessEntity(client));
                }
                return result;
            }
        }

        // Client's method Update who accept as a parameter Business object.
        // To be able to use Entity Framework and update Client from to the collection, it needs to be in Database format.
        public void Update(BusinessObject.Client client)
        {
            using (var db = new DatabaseEntity.AutoServiceSystemEntities())
            {
                // Find and Get the client that we want to update from Database.
                var dbClient = db.Clients.FirstOrDefault(x => x.id == client.Id);
                dbClient.FullName = client.FullName;
                dbClient.Gender = client.Gender;
                dbClient.Phone = client.Phone;
                dbClient.Address = client.Address;
                dbClient.Email = client.Email;
                dbClient.NationalCardNumber = client.NationalCardNumber;
                dbClient.PIN = client.PIN;
                db.SaveChanges();
            }
        }
    }
}
