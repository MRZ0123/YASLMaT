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
            if (DEBUG) { Console.WriteLine($"Checking for config file at \"{configFileLocation}\"."); }
            // **   -**#####**-   **

            if (!Config.Check(configFileLocation))
            {

                // ***** DEBUG MSG *****
                if (DEBUG) { Console.WriteLine($"No config present.\nCreating config at \"{configFileLocation}\"."); }
                // **   -**#####**-   **

                Config.Create(configFileLocation);
            }
            else
            {
                // ***** DEBUG MSG *****
                if (DEBUG) { Console.WriteLine($"A config has been found."); }
                // **   -**#####**-   **
            }
            
            // ***** DEBUG MSG *****
            if (DEBUG) {Console.WriteLine($"Reading from config."); }
            // **   -**#####**-   **
            
            Config.Content currentConfig = Config.Read(configFileLocation);

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"Current config content is:\n{currentConfig}"); }
            // **   -**#####**-   **

            
            // ***** DEBUG MSG *****
            if (DEBUG) {Console.WriteLine($"Checking if there's an Shlindex file."); }
            // **   -**#####**-   **
            
            if (!Shlindex.Check(currentConfig))
            {
                
                // ***** DEBUG MSG *****
                if (DEBUG) {Console.WriteLine($"No Shlindexfile found at\"{currentConfig.ShlindexFileLocation}\""); }
                // **   -**#####**-   **
                
                Console.WriteLine(currentConfig.Language == "DE" ? "Es scheint, als wäre es das erste Mal, dass Sie dieses Programm gestartet haben.\nViel Spaß beim Benutzen dieses Programmes!" : "This seems to be the first time you have started this application.\nHave fun using this application!");
            }
        }

    }
}