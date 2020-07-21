using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot.Domain
{
    public static class SExtended
    {
        //Ausgabe der Scooter Attribute
        public static string AsString(this Scooter scooter)
        {
            return ($"id     {scooter.Id}\n"+
                    $"Marke  {scooter.Make}\n"+
                    $"Modell {scooter.Model}\n");
        }

        //Ausgabe der ScootersToSearch Attribute
        public static string AsString(this ScootersToSearch scootersToSearch)
        {
            return ($"Marke  {scootersToSearch.Make}\n" +
                    $"Modell {scootersToSearch.Model}\n");
        }
    }
}
