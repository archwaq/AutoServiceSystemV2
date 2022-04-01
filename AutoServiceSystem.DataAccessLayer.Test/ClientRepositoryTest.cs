using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoServiceSystem.DataAccessLayer.Test
{
    [TestClass]
    public class ClientRepositoryTest
    {
        [TestMethod]
        public void ReadAll()
        {
            var clientRepo = new ClientRepository();
            var allClients = clientRepo.ReadAll();

            foreach (var client in allClients)
            {
                Console.WriteLine(client.Id);
            }
        }

        [TestMethod]
        public void ReadById()
        {
            var clientRepo = new ClientRepository();
            var singleClient = clientRepo.Read(1);
            Console.WriteLine(singleClient.Id); 
        }

        [TestMethod]
        public void Create()
        {
            var clientRepo = new ClientRepository();
            var client = new BusinessObject.Client();
            client.FullName = "George";
            client.Gender = "M";
            client.Phone = "11111";
            client.Address = "Germany";
            client.Email = "mayer@test.ok";
            client.NationalCardNumber = "11111";
            client.PIN = "333";

            clientRepo.Create(client);
        }

        [TestMethod]
        public void Update()
        {
            var clientRepo = new ClientRepository();
            var client = new BusinessObject.Client();

            client.Id = 2009;
            client.Phone = "2440000";
            client.Address = "Leiblfing";

            clientRepo.Update(client);
        }

        [TestMethod]
        public void Delete()
        {
            var clientRepo = new ClientRepository();
            var client = new BusinessObject.Client();

            clientRepo.Delete(2010);
        }
    }
}
