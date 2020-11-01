using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace DataBaseLab2
{
    static class View
    {
        static View() {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }
        static public void ShowRead(NpgsqlDataReader reader)
        {
            
            if (reader.HasRows)
            {
                const int part_size = 15;
                string title_part = "+" + new string('-', part_size);
                string title = "";
                for (int i = 0; i < reader.FieldCount; i++)
                    title += title_part;
                title += "+";
                Console.WriteLine(title);
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.Write($"|{reader.GetName(i),-part_size}");
                Console.WriteLine("|");
                Console.WriteLine(title);

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write($"|{reader[i],-part_size}");
                    Console.WriteLine("|");
                    Console.WriteLine(title);
                }
            }
            reader.Close();
        }
        static public void Report(string message)
        {
            Console.WriteLine(message);
        }

        static public void MainMenu()
        {
            Console.WriteLine("Insert: 1");
            Console.WriteLine("Update: 2");
            Console.WriteLine("Delete: 3");
            Console.WriteLine("Read: 4");
            Console.WriteLine("Select: 5");
            Console.WriteLine("RandomInsert: 6");
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

        static public void SelectInfo()
        {
            Console.WriteLine("Select t_name, trainer, s_name WHERE first char in t_name and s_name what you LIKE: 1");
            Console.WriteLine("Select MatchID WHERE goals >= count up to minute: 2");
            Console.WriteLine("Select TeamID WHERE max goals in match: 3");
        }

        static public void RandomSelectInfo()
        {
            Console.WriteLine("TableName Counter:");
        }

        static public void DeleteReport(int counter)
        {
            Console.WriteLine("Deleted " + counter + " rows");
        }

        static public void InsertReport(int counter)
        {
            Console.WriteLine("Inserted " + counter + " rows");
        }

        static public void TimerReport(TimeSpan time)
        {
            Console.WriteLine("Time taken: (" + time.ToString("ss'.'fff") + ") s.");
        }

    }
}
