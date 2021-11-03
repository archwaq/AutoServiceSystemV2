using AutoServiceSystem.BusinessObject;
using AutoServiceSystem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServiceSystem.AdminConsole
{
    public enum Options
    {
        ReadAllClients = 1,
        GetClientByID = 2,
        CreateClient = 3,
        UpdateClient = 4,
        DeleteClientByID = 5,
        ReadAllVehicles = 6,
        GetVehicleByID = 7,
        CreateVehicle = 8,
        UpdateVehicle = 9,
        DeleteVehicleByID = 10,
        ReadAllRepairs = 11,
        GetRepairByID = 12,
        CreateRepair = 13,
        UpdateRepair = 14,
        DeleteRepairByID = 15,
        Quit = 16
    }
    class AdminConsole
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(140, 30);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string title = @"
   _____            __             _________                       .__                   _________                  __                    
  /  _  \   __ __ _/  |_   ____   /   _____/  ____  _______ ___  __|__|  ____    ____   /   _____/ ___.__.  _______/  |_   ____    _____  
 /  /_\  \ |  |  \\   __\ /  _ \  \_____  \ _/ __ \ \_  __ \\  \/ /|  |_/ ___\ _/ __ \  \_____  \ <   |  | /  ___/\   __\_/ __ \  /     \ 
/    |    \|  |  / |  |  (  <_> ) /        \\  ___/  |  | \/ \   / |  |\  \___ \  ___/  /        \ \___  | \___ \  |  |  \  ___/ |  Y Y  \
\____|__  /|____/  |__|   \____/ /_______  / \___  > |__|     \_/  |__| \___  > \___  >/_______  / / ____|/____  > |__|   \___  >|__|_|  /
        \/                               \/      \/                         \/      \/         \/  \/          \/             \/       \/ 
";
            Console.WriteLine(title);

            Console.WriteLine("\t\t\t\tLoaded session as admin granding full CRUD privileges over categories\n\n");



            Console.WriteLine("Select request that will be send to system database:");

            Console.WriteLine("1) List all clients");
            Console.WriteLine("2) Get single client");
            Console.WriteLine("3) Create a new client");
            Console.WriteLine("4) Update client");
            Console.WriteLine("5) Delete client");
            Console.WriteLine("6) List all vehicles");
            Console.WriteLine("7) Get single vehicle");
            Console.WriteLine("8) Create a new vehicle");
            Console.WriteLine("9) Update vehicle");
            Console.WriteLine("10) Delete vehicle");
            Console.WriteLine("11) List all repairs");
            Console.WriteLine("12) Get single repair");
            Console.WriteLine("13) Create a new repair");
            Console.WriteLine("14) Update repair");
            Console.WriteLine("15) Delete repair");
            Console.WriteLine("16) Disconnect");

            bool openProcess = true;

            while (openProcess)
            {
                Console.Write("\r\nSelect an option: ");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case ((int)Options.ReadAllClients):
                        {
                            ReadAllClients();

                            break;
                        }
                    case ((int)Options.GetClientByID):
                        {
                            GetClientByID();

                            break;
                        }
                    case ((int)Options.CreateClient):
                        {
                            CreateClient();

                            break;
                        }
                    case ((int)Options.UpdateClient):
                        {
                            UpdateClient();

                            break;
                        }
                    case ((int)Options.DeleteClientByID):
                        {
                            DeleteClientByID();

                            break;
                        }
                    case ((int)Options.ReadAllVehicles):
                        {
                            ReadAllVehicles();

                            break;
                        }
                    case ((int)Options.GetVehicleByID):
                        {
                            GetVehicleByID();

                            break;
                        }
                    case ((int)Options.CreateVehicle):
                        {
                            CreateVehicle();

                            break;
                        }
                    case ((int)Options.UpdateVehicle):
                        {
                            UpdateVehicle();

                            break;
                        }
                    case ((int)Options.DeleteVehicleByID):
                        {
                            DeleteVehicleByID();

                            break;
                        }
                    case ((int)Options.ReadAllRepairs):
                        {
                            ReadAllRepairs();

                            break;
                        }
                    case ((int)Options.GetRepairByID):
                        {
                            GetRepairByID();

                            break;
                        }
                    case ((int)Options.CreateRepair):
                        {
                            CreateRepair();

                            break;
                        }
                    case ((int)Options.UpdateRepair):
                        {
                            UpdateRepair();

                            break;
                        }
                    case ((int)Options.DeleteRepairByID):
                        {
                            DeleteRepairByID();

                            break;
                        }
                    case ((int)Options.Quit):
                        {
                            Console.WriteLine("Press any key to quit");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                }
            }

        }
        private static void ReadAllClients()
        {
            var clientRepository = new ClientRepository();
            var allClients = clientRepository.ReadAll();

            foreach (var client in allClients)
            {
                Console.WriteLine($"{client.Id} { client.FullName} { client.Gender} {client.Phone} {client.Address} {client.Email} {client.NationalCardNumber} {client.PIN}");
            }
        }
        private static void GetClientByID()
        {
            var clientRepository = new ClientRepository();

            Console.Write("Input Client ID: ");
            string clientIDInput = Console.ReadLine();

            int convertedClientID = int.Parse(clientIDInput);

            var single = clientRepository.Read(convertedClientID);
            Console.WriteLine($"{single.Id} { single.FullName} { single.Gender} {single.Phone} {single.Address} {single.Email} {single.NationalCardNumber} {single.PIN}");

        }
        private static void CreateClient()
        {
            var clientRepository = new ClientRepository();
            var client = new BusinessObject.Client();

            Console.WriteLine("Create Client FullName");
            string fullNameInput = Console.ReadLine();
            client.FullName = fullNameInput;

            Console.WriteLine("Create Client Gender (Example: Male (M) Female (F) Both (B) Unknown (U))");
            string genderInput = Console.ReadLine();
            client.Gender = genderInput;

            Console.WriteLine("Create Client Phone");
            string phoneInput = Console.ReadLine();
            client.Phone = phoneInput;

            Console.WriteLine("Create Client Address");
            string addressInput = Console.ReadLine();
            client.Address = addressInput;

            Console.WriteLine("Create Client Email");
            string emailInput = Console.ReadLine();
            client.Email = emailInput;

            Console.WriteLine("Create Client National Card Number");
            string nationalCardNumberInput = Console.ReadLine();
            client.NationalCardNumber = nationalCardNumberInput;

            Console.WriteLine("Create Client PIN");
            string pinInput = Console.ReadLine();
            client.PIN = pinInput;

            clientRepository.Create(client);

        }
        private static void UpdateClient()
        {
            var clientRepository = new ClientRepository();
            var client = new BusinessObject.Client();

            ReadAllClients();
            Console.WriteLine();
            Console.WriteLine("Update Client");

            Console.Write("Input Client ID: ");
            string clientIDInput = Console.ReadLine();

            int convertedClientID = int.Parse(clientIDInput);
            client.Id = convertedClientID;

            Console.WriteLine("Update Client FullName");
            string fullNameInput = Console.ReadLine();
            client.FullName = fullNameInput;

            Console.WriteLine("Update Client Gender (Example: Male (M) Female (F) Both (B) Unknown (U))");
            string genderInput = Console.ReadLine();
            client.Gender = genderInput;

            Console.WriteLine("Update Client Phone");
            string phoneInput = Console.ReadLine();
            client.Phone = phoneInput;

            Console.WriteLine("Update Client Address");
            string addressInput = Console.ReadLine();
            client.Address = addressInput;

            Console.WriteLine("Update Client Email");
            string emailInput = Console.ReadLine();
            client.Email = emailInput;

            Console.WriteLine("Update Client National Card Number");
            string nationalCardNumberInput = Console.ReadLine();
            client.NationalCardNumber = nationalCardNumberInput;

            Console.WriteLine("Update Client PIN");
            string pinInput = Console.ReadLine();
            client.PIN = pinInput;

            clientRepository.Update(client);

        }
        private static void DeleteClientByID()
        {
            var clientRepository = new ClientRepository();

            ReadAllClients();
            Console.WriteLine();
            Console.WriteLine("Delete Client");

            Console.Write("Input Client ID: ");
            string clientIDInput = Console.ReadLine();

            int convertedClientID = int.Parse(clientIDInput);
            clientRepository.Delete(convertedClientID);
            Console.WriteLine();

            ReadAllClients();
        }
        private static void ReadAllVehicles()
        {
            var vehicleRepository = new VehicleRepository();
            var allVehicles = vehicleRepository.ReadAll();

            foreach (var vehicle in allVehicles)
            {
                Console.WriteLine($"{vehicle.Id} {vehicle.VIN} {vehicle.RegistrationPlate} {vehicle.Make} {vehicle.Model} {vehicle.Color} {vehicle.ClientID}");
            }
        }
        private static void GetVehicleByID()
        {
            var vehicleRepository = new VehicleRepository();

            Console.Write("Input Vehicle ID: ");
            string vehicleIDInput = Console.ReadLine();

            int convertedVehicleID = int.Parse(vehicleIDInput);

            var single = vehicleRepository.Read(convertedVehicleID);
            Console.WriteLine($"{single.Id} {single.VIN} {single.RegistrationPlate} {single.Make} {single.Model} {single.Color} {single.ClientID}");
        }
        public static void CreateVehicle()
        {
            var vehicleRepository = new VehicleRepository();
            var vehicle = new BusinessObject.Vehicle();

            Console.WriteLine("Create VIN");
            string vinInput = Console.ReadLine();
            vehicle.VIN = vinInput;

            Console.WriteLine("Create Registration Plate");
            string registrationPlate = Console.ReadLine();
            vehicle.RegistrationPlate = registrationPlate;

            Console.WriteLine("Create Make");
            string makeInput = Console.ReadLine();
            vehicle.Make = makeInput;

            Console.WriteLine("Create Model");
            string modelInput = Console.ReadLine();
            vehicle.Model = modelInput;

            Console.WriteLine("Create Color");
            string colorInput = Console.ReadLine();
            vehicle.Color = colorInput;

            Console.WriteLine("Create Vehicle Ownership (Client his/her respective identifier)");
            vehicle.ClientID = int.Parse(Console.ReadLine());

            //vehicle.VIN = "4444";
            //vehicle.RegistrationPlate = "1111";
            //vehicle.Make = "Fiat";
            //vehicle.Model = "Punto";
            //vehicle.Color = "Yellow";

            //vehicle.ClientID = 1;

            vehicleRepository.Create(vehicle);

        }
        private static void UpdateVehicle()
        {
            var vehicleRepository = new VehicleRepository();
            var vehicle = new BusinessObject.Vehicle();

            ReadAllVehicles();
            Console.WriteLine();

            Console.WriteLine("Update Vehicle");

            Console.Write("Input Vehicle ID: ");
            string vehicleIDInput = Console.ReadLine();
            int convertedVehicleID = int.Parse(vehicleIDInput);
            vehicle.Id = convertedVehicleID;

            Console.WriteLine("Update Vehicle VIN");
            string vinInput = Console.ReadLine();
            vehicle.VIN = vinInput;

            Console.WriteLine("Update Vehicle RegistrationPlate");
            string registrationPlateInput = Console.ReadLine();
            vehicle.RegistrationPlate = registrationPlateInput;

            Console.WriteLine("Update Vehicle Make");
            string makeInput = Console.ReadLine();
            vehicle.Make = makeInput;

            Console.WriteLine("Update Vehicle Model");
            string modelInput = Console.ReadLine();
            vehicle.Model = modelInput;

            Console.WriteLine("Update Vehicle Color");
            string colorInput = Console.ReadLine();
            vehicle.Color = colorInput;

            Console.WriteLine("Update Vehicle Ownership (Client his/her respective ID)");
            string ownerIDInput = Console.ReadLine();
            int convertedOwnerID = int.Parse(ownerIDInput);
            vehicle.ClientID = convertedOwnerID;

            vehicleRepository.Update(vehicle);

        }
        private static void DeleteVehicleByID()
        {
            var vehicleRepository = new VehicleRepository();

            ReadAllVehicles();
            Console.WriteLine();
            Console.WriteLine("Delete Vehicle");

            Console.Write("Input Vehicle ID: ");
            string vehicleIDInput = Console.ReadLine();
            int convertedVehicleID = int.Parse(vehicleIDInput);

            vehicleRepository.Delete(convertedVehicleID);
            Console.WriteLine();

            ReadAllVehicles();

        }
        private static void ReadAllRepairs()
        {
            var repairRepository = new RepairRepository();
            var allRepairs = repairRepository.ReadAll();

            foreach (var repair in allRepairs)
            {
                Console.WriteLine($"{repair.Id} {repair.CreatedDate} {repair.Description} {repair.Price} {repair.VehicleID}");
            }
        }
        private static void GetRepairByID()
        {
            var repairRepository = new RepairRepository();

            Console.Write("Input Repair ID: ");
            string repairIDInput = Console.ReadLine();

            int convertedRepairID = int.Parse(repairIDInput);

            var single = repairRepository.Read(convertedRepairID);
            Console.WriteLine($"{single.Id} {single.CreatedDate} {single.Description} {single.Price} {single.VehicleID}");
        }
        private static void CreateRepair()
        {
            var repairRepository = new RepairRepository();
            var repair = new BusinessObject.Repair();

            Console.WriteLine("Create Repair CreatedDate (mm/dd/yy)");
            string dateInput = Console.ReadLine();
            DateTime convertedDate = DateTime.Parse(dateInput);
            repair.CreatedDate = convertedDate.Date;

            Console.WriteLine("Create Repair Description");
            string descriptionInput = Console.ReadLine();
            repair.Description = descriptionInput;

            Console.WriteLine("Create Repair Price");
            string priceInput = Console.ReadLine();
            decimal convertedPrice = decimal.Parse(priceInput);
            repair.Price = convertedPrice;

            Console.WriteLine("Input Repair Ownership (Vehicle respective ID)");
            string vehicleIDInput = Console.ReadLine();
            int convertedVehicleID = int.Parse(vehicleIDInput);
            repair.VehicleID = convertedVehicleID;

            repairRepository.Create(repair);

        }
        private static void UpdateRepair()
        {
            var repairRepository = new RepairRepository();
            var repair = new BusinessObject.Repair();

            GetRepairByID();
            Console.WriteLine();

            Console.WriteLine("Update Repair");

            Console.WriteLine("Update Repair CreatedDate (mm/dd/yy)");
            string dateInput = Console.ReadLine();
            DateTime convertedDate = DateTime.Parse(dateInput);
            repair.CreatedDate = convertedDate.Date;

            Console.WriteLine("Update Repair Description");
            string descriptionInput = Console.ReadLine();
            repair.Description = descriptionInput;

            Console.WriteLine("Update Repair Price");
            string priceInput = Console.ReadLine();
            decimal convertedPrice = decimal.Parse(priceInput);
            repair.Price = convertedPrice;

            Console.WriteLine("Update Repair Ownership (Vehicle respective ID)");
            string vehicleIDInput = Console.ReadLine();
            int convertedVehicleID = int.Parse(vehicleIDInput);
            repair.VehicleID = convertedVehicleID;

            repairRepository.Update(repair);
        }
        private static void DeleteRepairByID()
        {
            var repairRepository = new RepairRepository();

            ReadAllRepairs();
            Console.WriteLine();
            Console.WriteLine("Delete Repair");

            Console.Write("Input Repair ID: ");
            string repairIDInput = Console.ReadLine();

            int convertedRepairID = int.Parse(repairIDInput);
            repairRepository.Delete(convertedRepairID);
            Console.WriteLine();

            ReadAllRepairs();

        }


    }
}
