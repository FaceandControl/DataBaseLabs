using DataBase3.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace DataBase3
{
    static class View
    {
        static View() {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }
        static public void ShowRead(IModel reader)
        {
            Console.WriteLine(reader.Properties());
            Console.WriteLine(reader.ToString());
            Console.WriteLine(reader.DecorationLine());
        }
            static public void ShowRead(IList<IModel> reader)
        {
            if (reader.Count != 0) {
                Console.WriteLine(reader[0].Properties());
                foreach (var i in reader)
                    Console.WriteLine(i.ToString());
                Console.WriteLine(reader[0].DecorationLine());
            }
        }

        static public void MainMenu()
        {
            Console.WriteLine("Insert: 1");
            Console.WriteLine("Update: 2");
            Console.WriteLine("Delete: 3");
            Console.WriteLine("Read: 4");
        }

        static public void ReportError(string ExMessage) {
            Console.WriteLine("Error: " + ExMessage);
        }

        static public void ReportErrors(string ExMessage1, string ExMessage2)
        {
            Console.WriteLine("Error: " + ExMessage1 + " or " + ExMessage2);
        }

        static public void InsertInfo()
        {
           Console.WriteLine("TableName Parameters:");
        }

        static public void UpdateInfo()
        {
            Console.WriteLine("TableName New_parameters:");
        }

        static public void DeleteInfo()
        {
            Console.WriteLine("TableName ID OR TableName:");
        }

        static public void ReadInfo()
        {
            Console.WriteLine("TableName:");
        }

        static public void DeleteReport(int counter)
        {
            Console.WriteLine("Deleted " + counter + " rows");
        }

    }
}
