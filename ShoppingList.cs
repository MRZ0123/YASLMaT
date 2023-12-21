using System;
using System.IO;
using System.Text.Json;
using Sven;
using Jugi;

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
            public string Id { get; set; }
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

            public void UpdateItemCount(long count)
            {
                this.FullItemCount = count;
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

            public void UpdateItemCount()
            {
                this.Metadata.UpdateItemCount(this.Items.LongCount());
            }
        }


        /** Added by: Manuel
         * 
         * function from reading and returning the entire content of a shopping list from file
         * 
         */
        public static Content Read(Config.Content currentConfig, string id)
        {
            string dataDirLocation = currentConfig.ShoppingListDirectory;
            string[] files = Directory.GetFiles(dataDirLocation, id + "__*.json");
            if (files.Length == 0)
            {
                Menu.DisplayShlindexOnlyDeleteQuestion(currentConfig);
                if (Menu.GetYesNoUserInput(currentConfig, Menu.DisplayShlindexOnlyDeleteQuestion))
                {
                    Shlindex.Content shlindex = Shlindex.Read(currentConfig);
                    shlindex.RemoveMetadataById(id);
                    Shlindex.Write(currentConfig, shlindex);
                }
                return new Content(); //! IMPORTANT: check if this return is only new Content() or actually has data
            }
            else
            {
                string shoppingListString = "";
                using (StreamReader streamReader = new StreamReader(files[0]))
                {
                    string? currentLine;
                    while ((currentLine = streamReader.ReadLine()) != null)
                    {
                        shoppingListString += (currentLine + "\n");
                    }
                }
                Content shoppingList = JsonSerializer.Deserialize<Content>(shoppingListString);
                return shoppingList;
            }
        }


        /** Added by: Manuel
         * 
         * function used to write a shopping list to disk and shlindex based on a ShoppingList.Content object
         * 
         */
        public static void Write(Config.Content currentConfig, Content content)
        {
            content.UpdateItemCount();
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
         * function to create a new id
         * 
         */
        public static string GenerateNewId()
        {
            Random random = new Random();
            const string aplphaNumericCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(aplphaNumericCharacters, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }


        /** Added by: Manuel
         * 
         * function used to rename a shopping list
         * 
         */
        public static void Rename(Config.Content currentConfig, string id, string newName)
        {
            string[] files = Directory.GetFiles(currentConfig.ShoppingListDirectory, id + "__*.json");
            // TODO: get shopping list starting with {id}
            Shlindex.Content index = Shlindex.Read(currentConfig);
            bool check = false;
            foreach (Metadata metadata in index.MetadataShlindex)
            {
                if (metadata.Id == id)
                {
                    check = true;
                }
            }
            if (!check)
            {
                Console.WriteLine($"\n---------- German ----------\nDiese Liste wurde leider nicht in der Index Datei gefunden. Ein Eintrag dafür wird angelegt.\n\n---------- English ----------\nUnfortunately this list doesn't seem to appear in the index file. An entry will be created for it.");
                // TODO: Add Entry to index
            }

        }


        /** Added by: Manuel
         * 
         * function used to remove a shopping list based on a shopping list object
         * 
         */
        public static void Remove(Config.Content currentConfig, string id)
        {
            string[] files = Directory.GetFiles(currentConfig.ShoppingListDirectory, id + "__*.json");
            Shlindex.Content shlindex = Shlindex.Read(currentConfig);
            shlindex.RemoveMetadataById(id);
            Shlindex.Write(currentConfig, shlindex);
            if (files.Length != 0)
            {
                File.Delete(files[0]);
            }
        }
    }
}