using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DateMD5
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer myTimer = new Timer();

            List<String> hashesList = new List<string>();

            DateTime myDate = DateTime.Now;

            long alreadyIn = 0;
            long counter = 0;

            myTimer.Elapsed += (sender, eventArgs) =>
            {
                myDate = myDate.AddSeconds(1);
                string toHash = myDate.ToString();

                string hashCode = String.Format("{0:X}", toHash.GetHashCode());

                if (hashesList.Contains(hashCode))
                {
                    alreadyIn++;
                }
                else
                {
                    hashesList.Add(hashCode);
                }

                if (counter%1000 == 0)
                {
                    Console.WriteLine($"{counter} - {toHash} : {hashCode}\t doublons: {alreadyIn}");
                }

                counter++;
            };

            myTimer.Interval = 1;
            myTimer.Enabled = true;

            Console.ReadKey();
        }
    }
}
