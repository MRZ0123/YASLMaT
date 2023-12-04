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
            public string indexFileLocation { get; set; }
            public string shoppingListDirectory { get; set; }

            public Content(string indexFileLocation, string shoppingListDirectory)
            {
                this.indexFileLocation = indexFileLocation;
                this.shoppingListDirectory = shoppingListDirectory;
            }

            public override string ToString()
            {
                return $"{{\n\t\"indexFileLocation\": \"{this.indexFileLocation}\",\n\t\"shoppingListDirectory\": \"{this.shoppingListDirectory}\"\n}}";
            }
        }


        /** Added by: Manuel
         * 
         * function used to check if there's a config present
         * ! Needs to be run every time the program starts
         * 
         * Call with :
         * string configFilePath = @"./config.json";
         * checkConfig(configFilePath);
         */
        public static void Check(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                Content defaultConfigContent = new Content("./index.json", "./data/");
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions() { WriteIndented = true };
                string writableJson = JsonSerializer.Serialize<Content>(defaultConfigContent, jsonOptions);
                using (StreamWriter streamWriter = File.CreateText(configFilePath))
                {
                    streamWriter.Write(writableJson);
                }
            }
        }

        /** Added by: Manuel
         * 
         * function to get config content into config object
         * 
         */
        public static Content Read(string configFilePath)
        {
            string configString = "";
            using (StreamReader streamReader = new StreamReader(configFilePath))
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