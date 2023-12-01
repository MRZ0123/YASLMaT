using System;
using System.Text.Json.Serialization;

namespace YASLMAT
{
    /*
    * Added by: Manuel
    * 
    * struct used to describe each list inside the index.json
    * also present at the start of each list
    * 
    */
    struct Metadata
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

    /*
    * Added by: Manuel
    * 
    * struct used to describe one item inside a shopping list
    * 
    */
    struct Item
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

        public void SetItemPriceForOne(float itemPriceForOne)
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

    /*
    * Added by: Manuel
    * 
    * class used to describe an entire shopping list
    * 
    */
    class ShoppingList
    {
        public Metadata metadata;
        public List<Item> items;

        // constructor for all cases
        public ShoppingList(Metadata metadata)
        {
            this.metadata = metadata;
            this.items = new List<Item>();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            System.Console.WriteLine("Bye World");

        }
    }
}