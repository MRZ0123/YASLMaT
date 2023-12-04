using System;
using System.IO;
using System.Text.Json;
using Manuel;

namespace YASLMAT
{

    class Program
    {

        /**
         * TODO: checkConfig
         * TODO: readConfig -> beide dinger in Config.ConfigContent variable rein.
         */
        static void Main(string[] args)
        {
            string configFilePath = "./conf.ig";
            Config.Check(configFilePath);
            Config.Content currentConfig = Config.Read(configFilePath);
            System.Console.WriteLine(currentConfig.ToString());
            ShoppingList.Remove(currentConfig, "12345");
        }

    }
}