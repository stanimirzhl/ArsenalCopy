
using Hotel_Manager.Controllers;
using Hotel_Manager.Data;

HotelManagerContext db = new HotelManagerContext();
HotelController controller = new HotelController(db);

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("1. Показване на всички гости");
    Console.WriteLine("2. Добавяне на нов гост");
    Console.WriteLine("3. Стаи с цена между 80 и 100 лв (в низходящ ред)");
    Console.WriteLine("4. Изтриване на резервация по ID");
    Console.WriteLine("5. Брой свободни стаи");
    Console.WriteLine("6. Минимална цена по статус");
    Console.WriteLine("7. ID-та на активни резервации");
    Console.WriteLine("0. Изход");
    Console.Write("Моля, въведете избора си:");
    int choice = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (choice)
    {
        case 1:
            foreach (var names in controller.GetAllGuests())
            {
                Console.WriteLine($"{names}");
            }
            Console.WriteLine();
            break;
        case 2:
            Console.Write("Въведете първо име на госта: ");
            string firstName = Console.ReadLine()!;
            Console.Write("Въведете фамилия на госта: ");
            string lastName = Console.ReadLine()!;
            Console.Write("Въведете ЕГН: ");
            string egn = Console.ReadLine()!;
            Console.Write("Въведете телефонен номер: ");
            string phoneNumber = Console.ReadLine()!;
            controller.AddGuest(firstName, lastName, egn, phoneNumber);
            Console.WriteLine();
            break;
        case 3:
            foreach(var number in controller.GetRoomsByPriceRange())
            {
                Console.WriteLine($"Room number: {number}");
            }
            Console.WriteLine();
            break;
        case 4:
            Console.WriteLine($"Съществуващи ID-та на резервации: {string.Join(", ", db.Reservations.Select(x => x.Id))}");
            Console.Write("Въведете ID на резервацията, която искате да изтриете: ");
            int id = int.Parse(Console.ReadLine()!);
            if (controller.DeleteReservation(id))
            {
                Console.WriteLine($"Резервацията с ID {id} е изтрита успешно.");
            }
            else
            {
                Console.WriteLine($"Неуспешно изтриване на резервация с ID {id}.");
            }
            Console.WriteLine();
            break;
        case 5:
            Console.WriteLine($"Free rooms count: {controller.GetAvailableRoomsCount()}");
            break;
        case 6:
            Console.Write("Въведете статус(възможни статуси: free, busy, cleaning up): ");
            string status = Console.ReadLine()!;
            decimal price = controller.GetMinPriceByStatus(status);
            if(price == -1)
            {
                Console.WriteLine("Невалиден статус!");
                Console.WriteLine();
                break;
            }
            Console.WriteLine($"Минимална цена на стая със статус {status}: {price}");
            Console.WriteLine();
            break;
        case 7:
            foreach (var activeId in controller.GetActiveReservations())
            {
                Console.WriteLine($"Acitve reservation ID: {activeId}");
            }
            Console.WriteLine();
            break;
        case 0:
            Console.WriteLine("Exiting program....");
            return;
        default:
            Console.WriteLine("Invalid choice :(");
            Console.WriteLine();
            break;
    }
}


