using System;
using System.IO;

namespace Manuel
{
    class ShoppingList
    {

        /** Added by: Manuel
         * 
         * struct used to describe each list inside the index.json
         * also present at the start of each list
         * 
         */
        public struct Metadata
        {
            public string id { get; }
            public string name { get; set; }
            public string shop { get; set; }
            public long fullItemCount { get; set; }

            //default constructor if a shop has been named
            public Metadata(string id, string name, string shop)
            {
                this.id = id;
                this.name = name;
                this.shop = shop;
            }

            // constructor if no shop has been named
            public Metadata(string id, string name)
            {
                this.id = id;
                this.name = name;
                this.shop = "";
            }

        }


        /** Added by: Manuel
         * 
         * struct used to describe one item inside a shopping list
         * 
         */
        public struct Item
        {
            public long itemCount { get; set; }
            public string itemName { get; set; }
            private float? itemPriceForOne { get; set; }
            private float? itemPriceForCount { get; set; }

            // default constructor if item has a price
            public Item(long itemCount, string itemName, float itemPriceForOne)
            {
                this.itemCount = itemCount;
                this.itemName = itemName;
                this.itemPriceForOne = itemPriceForOne;
                this.itemPriceForCount = itemCount * itemPriceForOne;
            }

            // constructor if item doesn't have a price
            public Item(long itemCount, string itemName)
            {
                this.itemCount = itemCount;
                this.itemName = itemName;
            }

            public void RetItemPriceForOne(float itemPriceForOne)
            {
                this.itemPriceForOne = itemPriceForOne;
                this.itemPriceForCount = itemCount * itemPriceForOne;

            }

            public void RemovePrice()
            {
                this.itemPriceForOne = null;
                this.itemPriceForCount = null;
            }
        }


        /** Added by: Manuel
         * 
         * class used to describe an entire shopping list
         * 
         */
        public struct Content
        {
            public Metadata metadata { get; set; }
            public List<Item> items { get; set; }

            // constructor for all cases
            public Content(Metadata metadata)
            {
                this.metadata = metadata;
                this.items = new List<Item>();
            }

            public void AddItem(Item item)
            {
                this.items.Add(item);
            }

            public void ReadConfigemoveItem(Item item)
            {
                this.items.Remove(item);
            }

            public void RemoveItemIndex(int index)
            {
                this.items.RemoveAt(index);
            }
        }

        /** Added by: Manuel
         * 
         * function used to remove a shopping list based on a shopping list object
         * 
         */
        /** 
         * TODO: check id
         * TODO: delete index entry
         * TODO: delete file
         * 
         */
        public static void Remove(Config.Content currentConfig, string id)
        {
            string[] files = Directory.GetFiles(currentConfig.shoppingListDirectory, id + "*.json");
        }
    }
}