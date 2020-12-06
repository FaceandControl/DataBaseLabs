using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase3.Models
{
    interface IModel
    {
        public string ToString();
        public string Properties();
        public string DecorationLine();
    }
}
