using System;

namespace YASLMAT
{
    class Program
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
            private string id { get; }
            private string name { get; set; }
            private string shop { get; set; }
            private long fullItemCount { get; set; }

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
            private long itemCount { get; set; }
            private string itemName { get; set; }
            private string itemPriceForOne { get; set; }
            private string itemPriceForCount { get; set; }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            System.Console.WriteLine("Bye World");
        }
    }
}