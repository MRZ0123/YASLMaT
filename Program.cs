using System;
using System.IO;
using System.Text.Json;
using Manuel;
using Team;

namespace YASLMAT
{

    class Program
    {

        /**
         * TODO: Check -> if not -> Create
         * TODO: Read -> beide dinger in Config.Content variable rein.
         */
        static void Main(string[] args)
        {
            bool DEBUG = false;
            string configFileLocation = "./conf.ig";

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"DEBUG:\tChecking for config file at \"{configFileLocation}\"."); }
            // **   -**#####**-   **

            if (!Config.Check(configFileLocation))
            {

                // ***** DEBUG MSG *****
                if (DEBUG) { Console.WriteLine($"DEBUG:\tNo config present.\nCreating config at \"{configFileLocation}\"."); }
                // **   -**#####**-   **

                Config.Create(configFileLocation);
            }
            else
            {
                // ***** DEBUG MSG *****
                if (DEBUG) { Console.WriteLine($"DEBUG:\tA config has been found."); }
                // **   -**#####**-   **
            }

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"DEBUG:\tReading from config."); }
            // **   -**#####**-   **

            Config.Content currentConfig = Config.Read(configFileLocation);

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"DEBUG:\tCurrent config content is:\n{currentConfig}"); }
            // **   -**#####**-   **

            if (!Directory.Exists(currentConfig.ShoppingListDirectory))
            {
                Directory.CreateDirectory(currentConfig.ShoppingListDirectory);
            }

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"DEBUG:\tChecking if there's a Shlindex file."); }
            // **   -**#####**-   **

            if (!Shlindex.Check(currentConfig))
            {

                // ***** DEBUG MSG *****
                if (DEBUG) { Console.WriteLine($"DEBUG:\tNo Shlindexfile found at\"{currentConfig.ShlindexFileLocation}\""); }
                // **   -**#####**-   **

                Console.WriteLine(currentConfig.Language == "DE" ? "Es scheint, als wäre es das erste Mal, dass Sie dieses Programm gestartet haben.\nViel Spaß beim Benutzen dieses Programmes!" : "This seems to be the first time you have started this application.\nHave fun using this application!");

                // ***** DEBUG MSG *****
                if (DEBUG) { Console.WriteLine($"DEBUG:\tCreating empty Shlindex file."); }
                // **   -**#####**-   **

                Shlindex.Create(currentConfig);
            }
            else
            {

                // ***** DEBUG MSG *****
                if (DEBUG) { Console.WriteLine($"DEBUG:\tA shlindex has been found."); }
                // **   -**#####**-   **

            }

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"DEBUG:\tReading all Shopping lists from shlindex."); }
            // **   -**#####**-   **

            Shlindex.Content allShlistMetadata = Shlindex.Read(currentConfig);

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"DEBUG:\tDisplaying all Shopping lists."); }
            // **   -**#####**-   **

            Menu.DisplayShoppingLists(currentConfig, allShlistMetadata);

            // ***** DEBUG MSG *****
            if (DEBUG) { Console.WriteLine($"DEBUG:\tDisplaying main menu."); }
            // **   -**#####**-   **

            string userInput = "";
            while (userInput != "3")
            {
                Menu.DisplayMainMenuCombo(currentConfig);
                userInput = Menu.GetRealUserInput(currentConfig, Menu.DisplayMainMenuCombo);
                if (userInput != "1" && userInput != "2" && userInput != "3")
                {
                    Menu.DisplayOptionError(currentConfig);
                }
                else if (userInput == "1")  // Create new list
                {
                    string listNameFromUserInput = Menu.GetListName(currentConfig);
                    string? shopNameFromUserInput = Menu.GetShopName(currentConfig);
                    string generatedId = ShoppingList.GenerateNewId();
                    ShoppingList.Metadata newListMetadata;
                    if (shopNameFromUserInput == null || shopNameFromUserInput == "")
                    {
                        newListMetadata = new ShoppingList.Metadata(generatedId, listNameFromUserInput);
                    }
                    else
                    {
                        newListMetadata = new ShoppingList.Metadata(generatedId, listNameFromUserInput, shopNameFromUserInput);
                    }
                    ShoppingList.Content newListContent = new ShoppingList.Content(newListMetadata);
                    string listUserInput = "";
                    while (listUserInput != "3")
                    {
                        Menu.DisplayItemCombo(currentConfig);
                        listUserInput = Menu.GetRealUserInput(currentConfig, Menu.DisplayItemCombo);
                        if (listUserInput != "1" && listUserInput != "2" && listUserInput != "3")
                        {
                            Menu.DisplayOptionError(currentConfig);
                        }
                        else if (listUserInput == "1")  // add new Item
                        {
                            string newItemName = Menu.GetItemName(currentConfig);
                            int newItemQuantity = Convert.ToInt32(Menu.GetItemQuantity(currentConfig));
                            ShoppingList.Item newItem = new ShoppingList.Item(newItemQuantity, newItemName);
                            newListContent.AddItem(newItem);
                        }
                        else if (listUserInput == "2")  // remove item
                        {
                            // TODO: remove item if time available
                        }
                        else if (listUserInput == "3")  // finish list
                        {
                            ShoppingList.Write(currentConfig, newListContent);
                        }
                    }
                }
                else if (userInput == "2")  // select list (show all lists)
                {
                    allShlistMetadata = Shlindex.Read(currentConfig);
                    string? selectUserInput = "";
                    while (selectUserInput.ToLower() != "b")
                    {
                        Menu.DisplayShoppingLists(currentConfig, allShlistMetadata);
                        Menu.DisplaySelectRequest(currentConfig);
                        selectUserInput = Menu.GetUserInput();
                        selectUserInput ??= "";
                        int convertedInput = -1;
                        if (int.TryParse(selectUserInput, out convertedInput))
                        {
                            if (!(convertedInput < 0 && convertedInput >= allShlistMetadata.MetadataShlindex.Count))
                            {
                                Menu.DisplayWhichSelected(currentConfig, convertedInput);
                                Menu.DisplaySelectedOptions(currentConfig);
                                // TODO: add delete
                                // TODO: add show
                            }
                            else
                            {
                                Menu.DisplayOptionError(currentConfig);
                            }
                        }
                        else
                        {
                            Menu.DisplayOptionError(currentConfig);
                        }

                    }
                }
            }
        }

    }
}