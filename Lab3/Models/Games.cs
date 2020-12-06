using DataBase3.Models;
using System;
using System.Collections.Generic;

namespace DataBase3
{
    public partial class Games : IModel
    {
        public override string ToString()
        {
            return DecorationLine() + $"|{GameId,-15}|{MatchId,-15}|{TeamId,-15}|";
        }

        public string Properties()
        {
            return DecorationLine() + $"|{"GameId",-15}|{"MatchId",-15}|{"TeamId",-15}|";
        }

        public string DecorationLine()
        {
            return "+" + new string('-', 15) + "+" + new string('-', 15) + "+" + new string('-', 15) + "+\n";
        }
        public int GameId { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }

        public virtual Matches Match { get; set; }
        public virtual Teams Team { get; set; }
    }
}
