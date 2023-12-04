using System;
using System.IO;
using System.Text.Json;
using Manuel;

namespace YASLMAT
{

    class Program
    {

        /**
         * TODO: Check -> if not -> Create
         * TODO: Read -> beide dinger in Config.Content variable rein.
         */
        static void Main(string[] args)
        {
            string configFileLocation = "./conf.ig";
            if(! Config.Check(configFileLocation) )
            {
                Config.Create(configFileLocation);
            }
            Config.Content currentConfig = Config.Read(configFileLocation);

            Console.WriteLine(currentConfig.ToString());
            ShoppingList.Remove(currentConfig, "12345");
        }

    }
}