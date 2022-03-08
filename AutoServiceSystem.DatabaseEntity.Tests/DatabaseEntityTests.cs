using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;

namespace AutoServiceSystem.DatabaseEntity.Tests
{
    [TestClass]
    public class DatabaseEntityTests
    {
        [TestMethod]
        public void SavesClientToDatabase()
        {
            var client = new Client()
            {
                FullName = "Full Name",
                Gender = "Gender",
                Phone = "Phone",
                Address = "Address",
                Email = "Email",
                NationalCardNumber = "NationalCardNumber",
                PIN = "PIN"
            };

            using(var db = new AutoServiceSystemEntities())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }

            using (var db = new AutoServiceSystemEntities())
            {
                var savedClient = db.Clients.Add(client);
                Assert.AreEqual(client.FullName, savedClient.FullName);
            }
        }
    }

    public class AutoServiceSystemEntities : DbContext
    {
        public AutoServiceSystemEntities()
        {

        }

        public  DbSet<Client> Clients { get; set; }
    }
}
