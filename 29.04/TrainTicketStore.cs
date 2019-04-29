using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29._04
{
  internal class TrainTicketStore
  {
    const string STORE_NAME = "K.T.ZH";

    private List<Ticket> tickets;
    private List<Ticket> cart;


    private List<Ticket> GetTickets()
    {
      List<Ticket> result = new List<Ticket>();
      using (var context = new KtzhContext())
      {
        result = context.Tickets.ToList();
      }
      return result;
    }

    public void Run()
    {
      cart = new List<Ticket>();
      tickets = GetTickets();
      Console.WriteLine($"Welcome to the train ticket store\"{STORE_NAME}\"");
      while (true)
      {
        int menu;
        int toBuyTicketIndex;

        int innerMenu;

        Console.WriteLine("ВSelect an action:\n " + "1) Buy tickets\n" + "2) Go out ");

        if (int.TryParse(Console.ReadLine(), out menu))
        {
          switch (menu)
          {
            case 1:
              {
                if (tickets.Count > 0)
                {
                  while (true)
                  {
                    Console.WriteLine("1) Buy");
                    Console.WriteLine("2) Go to the payment");
                    if (int.TryParse(Console.ReadLine(), out innerMenu))
                    {
                      if (innerMenu == 2)
                      {
                        break;
                      }
                    }

                    for (int i = 0; i < tickets.Count; i++)
                    {
                      Console.WriteLine($"{i + 1})");
                      tickets[i].Print();
                      Console.WriteLine();
                    }

                    Console.WriteLine("Choose a ticket number: ");
                    if (int.TryParse(Console.ReadLine(), out toBuyTicketIndex))
                    {
                      if (toBuyTicketIndex > 0 && toBuyTicketIndex <= tickets.Count)
                      {
                        Console.WriteLine("Enter full name:");
                        Ticket newTicket = tickets[toBuyTicketIndex - 1];
                        newTicket.HolderName = Console.ReadLine();
                        cart.Add(newTicket);
                        Guid id = newTicket.Id;
                        tickets.Remove(tickets.Where(t => t.Id == id).FirstOrDefault());
                        using (var context = new KtzhContext())
                        {
                          var ticket = context.Tickets.Where(t => t.Id == id).FirstOrDefault();
                          context.Tickets.Remove(ticket);
                          context.SaveChanges();
                        }
                      }
                    }
                  }
                  if (cart.Count > 0)
                  {
                    int sum = 0;
                    Console.WriteLine("Your ticket: ");
                    foreach (var t in cart)
                    {
                      t.Print();
                      Console.WriteLine();
                      sum += t.Price;
                    }
                    Console.WriteLine($"To pay: {sum}");
                    cart.Clear();
                  }
                }
                else
                {
                  Console.WriteLine("Sorry no tickets!");
                }
                break;
              }
            case 2:
              {
                Environment.Exit(0);
                break;
              }
          }
        }
      }
    }
  }
}
