using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29._04
{
  class Program
  {
    static void Main(string[] args)
    {
      TrainTicketStore ticketStore = new TrainTicketStore();

      using (var context = new KtzhContext())
      {
        context.Tickets.Add(new Ticket
        {
          From = "Astana",
          To = "Almaty",
          DepartureDate = new DateTime(2019, 01, 02, 03, 50, 50),
          ArrivalDate = new DateTime(2019, 01, 07, 12, 10, 30),
          Price = 12000
        });
        context.Tickets.Add(new Ticket
        {
          From = "Aktobe",
          To = "Kokshetau",
          DepartureDate = new DateTime(2019, 01, 02, 03, 50, 50),
          ArrivalDate = new DateTime(2019, 01, 07, 12, 10, 30),
          Price = 12000
        });
        context.Tickets.Add(new Ticket
        {
          From = "Semey",
          To = "Taraz",
          DepartureDate = new DateTime(2019, 01, 02, 03, 50, 50),
          ArrivalDate = new DateTime(2019, 01, 07, 12, 10, 30),
          Price = 12000
        });
        context.SaveChanges();
      }
      ticketStore.Run();
      Console.ReadLine();
    }
  }
}
