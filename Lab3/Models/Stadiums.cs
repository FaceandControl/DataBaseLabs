using DataBase3.Models;
using System;
using System.Collections.Generic;

namespace DataBase3
{
    public partial class Stadiums : IModel
    {
        public Stadiums()
        {
            Matches = new HashSet<Matches>();
        }
        public override string ToString()
        {
            return DecorationLine() + $"|{StadiumId,-15}|{SName,-15}|{Capacity,-15}|{Address,-15}|";
        }

        public string Properties()
        {
            return DecorationLine() + $"|{"StadiumId",-15}|{"SName",-15}|{"Capacity",-15}|{"Address",-15}|";
        }

        public string DecorationLine() 
        {
            return "+" + new string('-', 15) + "+" + new string('-', 15) + "+" + new string('-', 15) + "+" + new string('-', 15) + "+\n";
        }

        public int StadiumId { get; set; }
        public string SName { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Matches> Matches { get; set; }
    }
}
