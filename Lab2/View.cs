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

        
    }
}
