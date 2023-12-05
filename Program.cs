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
            bool DEBUG = true;
            string configFileLocation = "./conf.ig";

            // ***** DEBUG MSG *****
            if (DEBUG) {Console.WriteLine($"Checking for config file at \"{configFileLocation}\"."); }
            // **   -**#####**-   **

            if (!Config.Check(configFileLocation))
            {
                
                // ***** DEBUG MSG *****
                if (DEBUG) { Console.WriteLine($"No config present.\nCreating config at \"{configFileLocation}\"."); }
                // **   -**#####**-   **

                Config.Create(configFileLocation);
            }
            Config.Content currentConfig = Config.Read(configFileLocation);

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"Current config content is:\n{currentConfig}"); }
            // **   -**#####**-   **

            if (!Shlindex.Check(currentConfig))
            {
                Console.WriteLine(currentConfig.Language == "DE" ? "" : "");
            }
            ShoppingList.Remove(currentConfig, "12345");
        }

    }
}