using System;
using System.IO;
using System.Text.Json;
using Manuel;

namespace YASLMAT
{

    class Program
    {

        /**
         * TODO: checkConfig
         * TODO: readConfig -> beide dinger in Config.ConfigContent variable rein.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            System.Console.WriteLine("Bye World");

        }


        /**
         * Added by: Manuel
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
        static void removeShoppingList(ShoppingList shoppingList)
        {
            string shoppingListId = shoppingList.metadata.id;
        }
    }
}