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

    }
}