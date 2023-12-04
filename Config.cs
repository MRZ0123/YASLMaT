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
        public struct ConfigContent
        {
            public string indexFileLocation { get; } // TODO: test if privatable
            private string shoppingListDirectory { get; } // TODO: test if privatable

            public ConfigContent(string indexFileLocation, string shoppingListDirectory)
            {
                this.indexFileLocation = indexFileLocation;
                this.shoppingListDirectory = shoppingListDirectory;
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
        void checkConfig(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                ConfigContent defaultConfigContent = new ConfigContent("./index.json", "./data/");
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions() { WriteIndented = true };
                string writableJson = JsonSerializer.Serialize<ConfigContent>(defaultConfigContent, jsonOptions);
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
        static ConfigContent readConfig(string configFilePath)
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
            ConfigContent config = JsonSerializer.Deserialize<ConfigContent>(configString);
            return config;
        }
    }
}