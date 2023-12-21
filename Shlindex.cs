using System;
using System.Text.Json;
using Manuel;

namespace Sven
{
    class Shlindex
    {
        /** Added by: Sven
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

            public void RemoveMetadataById(string id)
            {
                for (int i = 0; i < this.MetadataShlindex.Count; i += 1)
                {
                    if (this.MetadataShlindex[i].Id == id)
                    {
                        this.MetadataShlindex.RemoveAt(i);
                        break;
                    }
                }
            }
        }


        /** Added by: Sven
         * 
         * function used to check if an shlindex file already exists
         * 
         */
        public static bool Check(Config.Content currentConfig)
        {
            string shlindexFileLocation = currentConfig.ShlindexFileLocation;
            return File.Exists(shlindexFileLocation);
        }


        /** Added by: Sven
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


        /** Added by: Sven
         * 
         * function used to write content into shlindex file
         * 
         */
        public static void Write(Config.Content currentConfig, Content newShlindex)
        {
            string shlindexFileLocation = currentConfig.ShlindexFileLocation;
            string writableJson = JsonSerializer.Serialize<Content>(newShlindex);
            using (StreamWriter streamWriter = File.CreateText(shlindexFileLocation))
            {
                streamWriter.Write(writableJson);
            }
        }


        /** Added by: Sven
         * 
         * function used to read all Shlindex content to Content object
         * 
         */
        public static Content Read(Config.Content currentConfig)
        {
            string shlindexFileLocation = currentConfig.ShlindexFileLocation;
            string shlindexString = "";
            using (StreamReader streamReader = new StreamReader(shlindexFileLocation))
            {
                string? currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    shlindexString += (currentLine + "\n");
                }
            }
            Content shlindex = JsonSerializer.Deserialize<Content>(shlindexString);
            return shlindex;
        }
    }
}