using System;
using System.Globalization;
using System.Threading;

namespace DataBaseLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.ControllerLoop();
        }
    }
}
