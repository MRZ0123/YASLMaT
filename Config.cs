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
            private string? _Language;
            public string Language
            {
                get
                {
                    return _Language;
                }
                set
                {
                    switch (value.ToUpper())
                    {
                        case "DE":
                            _Language = value.ToUpper();
                            break;
                        case "EN":
                            _Language = value.ToUpper();
                            break;
                        default:
                            Console.WriteLine($"\n---------- German ----------\n\"{value}\" ist keine der unterstützten Sprachen: DE | EN\nBitte tragen Sie die gewollte Sprache, wie in dem internationalem Standard ISO 639-1 beschrieben, ein.\n\n---------- English ----------\n\"{value}\" is not one of the valid languages: DE | EN\nPlease insert the Language you want as described in the ISO 639-1 international standard.");
                            Environment.Exit(1);
                            break;
                    }
                }
            }
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
                        Console.WriteLine($"\n---------- German ----------\n\"{language}\" ist keine der unterstützten Sprachen: DE | EN\nBitte tragen Sie die gewollte Sprache, wie in dem internationalem Standard ISO 639-1 beschrieben, ein.\n\n---------- English ----------\n\"{language}\" is not one of the valid languages: DE | EN\nPlease insert the Language you want as described in the ISO 639-1 international standard.");
                        Environment.Exit(1);
                        break;
                }
                this.ShlindexFileLocation = shlndexFileLocation;
                this.ShoppingListDirectory = shoppingListDirectory;
            }

            public override string ToString()
            {
                return $"{{\n\t\"Language\": \"{this.Language}\",\n\t\"ShlindexFileLocation\": \"{this.ShlindexFileLocation}\",\n\t\"ShoppingListDirectory\": \"{this.ShoppingListDirectory}\"\n}}";
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


        /** Added by: Manuel
         * 
         * function used to create the default config and write it to disk
         * ? TODO: rewrite into create default config -> Write function
         * 
         */
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
            if (string.IsNullOrWhiteSpace(config.Language))
            {
                Console.WriteLine($"\n---------- German ----------\n\"Es ist keine der unterstützten Sprachen (DE | EN) in der Konfigurationsdatei festgelegt.\nBitte tragen Sie die gewollte Sprache, wie in dem internationalem Standard ISO 639-1 beschrieben, ein.\n\n---------- English ----------\nThere is no language (DE | EN) specified inside of the config file.\nPlease insert the Language you want as described in the ISO 639-1 international standard.");
                Environment.Exit(1);
            }
            return config;
        }
    }
}