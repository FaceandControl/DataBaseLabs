using DataBase3.Models;
using System;
using System.Collections.Generic;

namespace DataBase3
{
    public partial class Matches : IModel
    {
        public Matches()
        {
            Games = new HashSet<Games>();
            Goals = new HashSet<Goals>();
        }
        public override string ToString()
        {
            return DecorationLine() + $"|{MatchId,-15}|{StartTime,-15}|{StadiumId,-15}|";
        }

        public string Properties()
        {
            return DecorationLine() + $"|{"MatchId",-15}|{"StartTime",-15}|{"StadiumId",-15}|";
        }

        public string DecorationLine()
        {
            return "+" + new string('-', 15) + "+" + new string('-', 15) + "+" + new string('-', 15) + "+\n";
        }

        public int MatchId { get; set; }
        public DateTime StartTime { get; set; }
        public int StadiumId { get; set; }

        public virtual Stadiums Stadium { get; set; }
        public virtual ICollection<Games> Games { get; set; }
        public virtual ICollection<Goals> Goals { get; set; }
    }
}
