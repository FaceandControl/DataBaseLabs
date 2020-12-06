using DataBase3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase3
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.ControllerLoop();
            //Model m = new Model();
            //m.UpdateStadium("name", 100000, "new dads", 100157);

            ////View.ShowRead(m.InsertStadium("MyStadium", 30000, "Myadrs"));

            ////View.ShowRead(m.UpdateStadium("MyNewStadium", 40000, "MyNewadrs", 100179));

            //View.Report(m.DeleteStadiums().ToString());

            //View.ShowRead(m.ReadData<Stadiums>().ToList<IModel>());
            //View.ShowRead(m.ReadData<Teams>().ToList<IModel>());
            //View.ShowRead(m.ReadData<Goals>().ToList<IModel>());
            //View.ShowRead(m.ReadData<Matches>().ToList<IModel>());
            //View.ShowRead(m.ReadData<Games>().ToList<IModel>());
            //Console.ReadKey();
        }
    }
}