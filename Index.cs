using System;
using System.Text.Json;

namespace Manuel
{
    class Index
    {
        /** Added by: Manuel
         * 
         * struct used to define the content of the index file
         * 
         */
        public struct Content
        {
            public List<ShoppingList.Metadata> Metadata { get; set; }

            // default constructor
            public Content()
            {
                this.Metadata = new List<ShoppingList.Metadata>();
            }

            public void AddMetadata(ShoppingList.Metadata metadata)
            {
                this.Metadata.Add(metadata);
            }

            public void RemoveMetadata(ShoppingList.Metadata metadata)
            {
                this.Metadata.Remove(metadata);
            }
        }


        /** Added by: Manuel
         * 
         * function used to create an index file
         * 
         */
        public void CreateIndexFile(Config.Content currentConfig)
        {
            string indexFileLocation = currentConfig.IndexFileLocation;
            Content indexContent = new Content();
            string writableJson = JsonSerializer.Serialize<Content>(indexContent);
            using (StreamWriter streamWriter = File.CreateText(indexFileLocation))
            {
                streamWriter.Write(writableJson);
            }
        }
    }
}