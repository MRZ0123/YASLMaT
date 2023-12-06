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
            public string Language { get; set; }
            public string ShlindexFileLocation { get; set; }
            public string ShoppingListDirectory { get; set; }

            public Content(string language, string shlndexFileLocation, string shoppingListDirectory)
            {
                switch (language.ToUpper())
                {
                    case "DE":
                        this.Language = language.ToUpper();
                        break;
                    case "EN":
                        this.Language = language.ToUpper();
                        break;
                    default:
                        System.Console.WriteLine("Default reached in language switch.");
                        throw new ArgumentException($"---------- German ----------\n{language} ist keine der unterstützten Sprachen: Deutsch | Englisch\nBitte tragen Sie die gewollte Sprache, wie in dem internationalem Standard ISO 639-1 beschrieben, ein.\n\n---------- English ----------\n{language} is not one of the valid languages: German | English\nPlease insert the Language you want as described in the ISO 639-1 international standard.");
                }
                this.ShlindexFileLocation = shlndexFileLocation;
                this.ShoppingListDirectory = shoppingListDirectory;
            }

            public override string ToString()
            {
                return $"{{\n\t\"Language\": \"{this.Language}\"\n\t\"ShlindexFileLocation\": \"{this.ShlindexFileLocation}\",\n\t\"ShoppingListDirectory\": \"{this.ShoppingListDirectory}\"\n}}";
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
            Content defaultConfigContent = new Content("DE", "./shlindex.json", "./data/");
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