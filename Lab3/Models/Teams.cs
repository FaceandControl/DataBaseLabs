using DataBase3.Models;
using System;
using System.Collections.Generic;

namespace DataBase3
{
    public partial class Teams : IModel
    {
        public Teams()
        {
            Games = new HashSet<Games>();
            Goals = new HashSet<Goals>();
        }
        public override string ToString()
        {
            return DecorationLine() + $"|{TeamId,-15}|{TName,-15}|{Trainer,-15}|";
        }

        public string Properties()
        {
            return DecorationLine() + $"|{"TeamId",-15}|{"TName",-15}|{"Trainer",-15}|";
        }

        public string DecorationLine()
        {
            return "+" + new string('-', 15) + "+" + new string('-', 15) + "+" + new string('-', 15) + "+\n";
        }

        public int TeamId { get; set; }
        public string TName { get; set; }
        public string Trainer { get; set; }

        public virtual ICollection<Games> Games { get; set; }
        public virtual ICollection<Goals> Goals { get; set; }
    }
}
