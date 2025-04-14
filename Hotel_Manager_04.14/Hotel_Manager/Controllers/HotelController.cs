using Hotel_Manager.Data;
using Hotel_Manager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Manager.Controllers
{
    public class HotelController
    {
        /*•	Да връща списък с име и фамилия на всички гости на хотела.
          •	Да се добавя нов гост.
          •	Да връща всички номера на стаи с цена от 80 до 100 лева включително. Да се подредят в низходящ ред по цената.
          •	Да се изтрива резервация, по подадено id, като параметър.
          •	Да връща брой на свободните стаи в хотела.
          •	Да връща минималната цена от цените на стаите, които са със статус, подаден като параметър.
          •	Да връща списък с id-та на резервациите, които още не са приключили.
        */
        HotelManagerContext context;
        public HotelController(HotelManagerContext context)
        {
            this.context = context;
        }

        public List<string> GetAllGuests()
        {
            return context.Guests.Select(g => g.FirstName + " " + g.LastName).ToList();
        }

        public bool AddGuest(string firstName, string lastName, string ucn, string phoneNumber)
        {
            var guest = new Guest
            {
                FirstName = firstName,
                LastName = lastName,
                Ucn = ucn,
                PhoneNumber = phoneNumber
            };
            context.Guests.Add(guest);
            context.SaveChanges();
            return true;
        }

        public List<int> GetRoomsByPriceRange()
        {
            return context.Rooms
                .Where(r => r.Price >= 80 && r.Price <= 100)
                .OrderByDescending(r => r.Price)
                .Select(x => x.Number)
                .ToList();
        }

        public bool DeleteReservation(int reservationId)
        {
            var reservation = context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                context.Reservations.Remove(reservation);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public int GetAvailableRoomsCount()
        {
            return context.Rooms.Count(r => r.Status == "free");
        }

        public decimal GetMinPriceByStatus(string status)
        {
            string[] statuses = {"free", "busy", "cleaning up" };

            if (!statuses.Contains(status))
            {
                return -1;
            }

            return context.Rooms
                .Where(r => r.Status == status)
                .Min(r => r.Price);
        }

        public List<int> GetActiveReservations()
        {
            DateTime date = DateTime.Now;
            DateOnly DateOnly = DateOnly.FromDateTime(date);

            return context.Reservations
                .Where(r => r.ReleaseDate > DateOnly)
                .Select(r => r.Id)
                .ToList();
        }
    }
}
