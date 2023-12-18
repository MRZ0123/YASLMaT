using System;
using System.IO;
using System.Text.Json;

namespace Manuel
{
    class ShoppingList
    {

        /** Added by: Manuel
         * 
         * struct used to describe each list inside the shlindex.json
         * also present at the start of each list
         * 
         */
        public struct Metadata
        {
            public string Id { get; }
            public string Name { get; set; }
            public string Shop { get; set; }
            public long FullItemCount { get; set; }

            // default constructor if a shop has been named
            public Metadata(string id, string name, string shop)
            {
                this.Id = id;
                this.Name = name;
                this.Shop = shop;
            }

            // constructor if no shop has been named
            public Metadata(string id, string name)
            {
                this.Id = id;
                this.Name = name;
                this.Shop = "";
            }

        }


        /** Added by: Manuel
         * 
         * struct used to describe one item inside a shopping list
         * 
         */
        public struct Item
        {
            public long ItemCount { get; set; }
            public string ItemName { get; set; }
            private float? ItemPriceForOne { get; set; }
            private float? ItemPriceForCount { get; set; }

            // default constructor if item has a price
            public Item(long itemCount, string itemName, float itemPriceForOne)
            {
                this.ItemCount = itemCount;
                this.ItemName = itemName;
                this.ItemPriceForOne = itemPriceForOne;
                this.ItemPriceForCount = itemCount * itemPriceForOne;
            }

            // constructor if item doesn't have a price
            public Item(long itemCount, string itemName)
            {
                this.ItemCount = itemCount;
                this.ItemName = itemName;
            }

            public void SetItemPriceForOne(float itemPriceForOne)
            {
                this.ItemPriceForOne = itemPriceForOne;
                this.ItemPriceForCount = ItemCount * itemPriceForOne;

            }

            public void RemovePrice()
            {
                this.ItemPriceForOne = null;
                this.ItemPriceForCount = null;
            }
        }


        /** Added by: Manuel
         * 
         * class used to describe an entire shopping list
         * 
         */
        public struct Content
        {
            public Metadata Metadata { get; set; }
            public List<Item> Items { get; set; }

            // constructor for all cases
            public Content(Metadata metadata)
            {
                this.Metadata = metadata;
                this.Items = new List<Item>();
            }

            public void AddItem(Item item)
            {
                this.Items.Add(item);
            }

            public void RemoveItemItem(Item item)
            {
                this.Items.Remove(item);
            }

            public void RemoveItemIndex(int index)
            {
                this.Items.RemoveAt(index);
            }
        }


        /** Added by: Manuel
         * 
         * function used to write a shopping list to disk and shlindex based on a ShoppingList.Content object
         * 
         */
        public static void Write(Config.Content currentConfig, Content content)
        {
            Shlindex.Content shlindex = Shlindex.Read(currentConfig);
            shlindex.AddMetadata(content.Metadata);
            Shlindex.Write(currentConfig, shlindex);
            string shlDirectory = currentConfig.ShoppingListDirectory.TrimEnd();
            string strippedShlDirectory = shlDirectory.EndsWith('/') ? shlDirectory.Remove(shlDirectory.Length - 1, 1) : shlDirectory;
            string fullShlFilePath = strippedShlDirectory + "/" + content.Metadata.Id + "__" + content.Metadata.Name + ".json";
            string writableJson = JsonSerializer.Serialize<Content>(content);
            using (StreamWriter streamWriter = File.CreateText(fullShlFilePath))
            {
                streamWriter.Write(writableJson);
            }
        }


        /** Added by: Manuel
         * 
         * function used to remove a shopping list based on a shopping list object
         * 
         */
        /** TODO:
         * TODO: check id
         * TODO: delete shlindex entry
         * TODO: delete file
         * 
         */
        public static void Remove(Config.Content currentConfig, string id)
        {
            string[] files = Directory.GetFiles(currentConfig.ShoppingListDirectory, id + "_*.json");
        }
    }
}