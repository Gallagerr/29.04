using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29._04
{
  public class Ticket : Entity
  {

    public string HolderName { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Price { get; set; }
    public bool IsAvailable
    {
      get
      {
        if (!string.IsNullOrWhiteSpace(HolderName))
        {
          return true;
        }
        return false;
      }
    }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }

    public void Print()
    {
      Console.WriteLine($"From: {From}");
      Console.WriteLine($"Where: {To}");
      Console.WriteLine($"Price: {Price}");
      Console.WriteLine($"Departure date: {DepartureDate}");
      Console.WriteLine($"Arrival date: {ArrivalDate}");
      if (!string.IsNullOrWhiteSpace(HolderName))
      {
        Console.WriteLine($"Addressed: {HolderName}");
      }
    }
  }
}
