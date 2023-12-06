using System;
using System.Text.Json;

namespace Manuel
{
    class Shlindex
    {
        /** Added by: Manuel
         * 
         * struct used to define the content of the shlindex file
         * 
         */
        public struct Content
        {
            public List<ShoppingList.Metadata> MetadataShlindex { get; set; }

            // default constructor
            public Content()
            {
                this.MetadataShlindex = new List<ShoppingList.Metadata>();
            }

            public void AddMetadata(ShoppingList.Metadata metadata)
            {
                this.MetadataShlindex.Add(metadata);
            }

            public void RemoveMetadata(ShoppingList.Metadata metadata)
            {
                this.MetadataShlindex.Remove(metadata);
            }
        }


        /** Added by: Manuel
         * 
         * function used to check if an shlindex file already exists
         * 
         */
        public static bool Check(Config.Content currentConfig)
        {
            string shlindexFileLocation = currentConfig.ShlindexFileLocation;
            return File.Exists(shlindexFileLocation);
        }


        /** Added by: Manuel
         * 
         * function used to create a new shlindex file
         * 
         */
        public static void Create(Config.Content currentConfig)
        {
            string shlindexFileLocation = currentConfig.ShlindexFileLocation;
            Content shlindexContent = new Content();
            string writableJson = JsonSerializer.Serialize<Content>(shlindexContent);
            using (StreamWriter streamWriter = File.CreateText(shlindexFileLocation))
            {
                streamWriter.Write(writableJson);
            }
        }


        /** Added by: Manuel
         * 
         * function used to write content into shlindex file
         * 
         */
        public static void Write(Config.Content currentConfig, Content metadata)
        {
            string shlindexFileLocation = currentConfig.ShlindexFileLocation;
            string writableJson = JsonSerializer.Serialize<Content>(metadata);
            using (StreamWriter streamWriter = File.CreateText(shlindexFileLocation))
            {
                streamWriter.Write(writableJson);
            }
        }
    }
}