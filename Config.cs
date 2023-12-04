using System;
using System.IO;
using System.Text.Json;

namespace Manuel
{
    class Config
    {

        /** Added by: Manuel
         * 
         * struct used to represent the config content
         * 
         */
        public struct Content
        {
            public string IndexFileLocation { get; set; }
            public string ShoppingListDirectory { get; set; }

            public Content(string indexFileLocation, string shoppingListDirectory)
            {
                this.IndexFileLocation = indexFileLocation;
                this.ShoppingListDirectory = shoppingListDirectory;
            }

            public override string ToString()
            {
                return $"{{\n\t\"indexFileLocation\": \"{this.IndexFileLocation}\",\n\t\"shoppingListDirectory\": \"{this.ShoppingListDirectory}\"\n}}";
            }
        }


        /** Added by: Manuel
         * 
         * function used to check if there's a config present
         * ! Needs to be run every time the program starts
         * 
         * Call with :
         * string configFileLocation = @"./config.json";
         * checkConfig(configFileLocation);
         */
        public static bool Check(string configFileLocation)
        {
            return File.Exists(configFileLocation);
        }

        public static void Create(string configFileLocation)
        {
            Content defaultConfigContent = new Content("./index.json", "./data/");
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions() { WriteIndented = true };
            string writableJson = JsonSerializer.Serialize<Content>(defaultConfigContent, jsonOptions);
            using (StreamWriter streamWriter = File.CreateText(configFileLocation))
            {
                streamWriter.Write(writableJson);
            }
        }
        /** Added by: Manuel
         * 
         * function to get config content into config object
         * 
         */
        public static Content Read(string configFileLocation)
        {
            string configString = "";
            using (StreamReader streamReader = new StreamReader(configFileLocation))
            {
                string? currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    configString += (currentLine + "\n");
                }
            }
            Content config = JsonSerializer.Deserialize<Content>(configString);
            return config;
        }
    }
}