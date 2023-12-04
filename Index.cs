using System;
using System.Runtime.CompilerServices;

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

        public void CreateIndexFile(Config.Content currentConfig)
        {

        }
    }
}