using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HW_Leah_Merzel.HW11_Exceptions
{
    public class ReadFile
    {
        public static void ReadFileTest()
        {
            foreach (string line in System.IO.File.ReadLines(
            #region txtfile
                         @"C:\Users\Owner\Desktop\C# HW Leah Merzel\C Sharp HW Leah Merzel\C Sharp HW Leah Merzel\HW11 Exceptions\test.txt"))
            #endregion
            {
                try
                {
                    Console.WriteLine(new DataTable().Compute(line, null).ToString());
                }

                catch (FileNotFoundException)
                {
                    Console.WriteLine("File Couldn't be Found");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Part of the filr or directory couldn't be found");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Format isn't a number");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                { }
            }
            Console.WriteLine("We're done printing");

        }
    }




}




