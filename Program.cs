using System;
using System.IO;
using System.Text.Json;
using Manuel;
using Team;


/** Added by: Manuel
 * 
 * Place to store global variables
 * 
 */
public static class Globals
{
    public const bool DEBUG = false;
}


namespace YASLMAT
{

    class Program
    {

        static void Main(string[] args)
        {
            string configFileLocation = "./conf.ig";

            // ***** DEBUG MSG *****
            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tChecking for config file at \"{configFileLocation}\"."); }
            // **   -**#####**-   **

            if (!Config.Check(configFileLocation))
            {

                // ***** DEBUG MSG *****
                if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tNo config present.\nCreating config at \"{configFileLocation}\"."); }
                // **   -**#####**-   **

                Config.Create(configFileLocation);
            }
            else
            {
                // ***** DEBUG MSG *****
                if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tA config has been found."); }
                // **   -**#####**-   **
            }

            // ***** DEBUG MSG *****
            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tReading from config."); }
            // **   -**#####**-   **

            Config.Content currentConfig = Config.Read(configFileLocation);

            // ***** DEBUG MSG *****
            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tCurrent config content is:\n{currentConfig}"); }
            // **   -**#####**-   **

            if (!Directory.Exists(currentConfig.ShoppingListDirectory))
            {
                Directory.CreateDirectory(currentConfig.ShoppingListDirectory);
            }

            // ***** DEBUG MSG *****
            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tChecking if there's a Shlindex file."); }
            // **   -**#####**-   **

            if (!Shlindex.Check(currentConfig))
            {

                // ***** DEBUG MSG *****
                if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tNo Shlindexfile found at\"{currentConfig.ShlindexFileLocation}\""); }
                // **   -**#####**-   **

                Console.WriteLine(currentConfig.Language == "DE" ? "Es scheint, als wäre es das erste Mal, dass Sie dieses Programm gestartet haben.\nViel Spaß beim Benutzen dieses Programmes!" : "This seems to be the first time you have started this application.\nHave fun using this application!");

                // ***** DEBUG MSG *****
                if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tCreating empty Shlindex file."); }
                // **   -**#####**-   **

                Shlindex.Create(currentConfig);
            }
            else
            {

                // ***** DEBUG MSG *****
                if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tA shlindex has been found."); }
                // **   -**#####**-   **

            }

            // ***** DEBUG MSG *****
            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tReading all Shopping lists from shlindex."); }
            // **   -**#####**-   **

            Shlindex.Content allShlistMetadata = Shlindex.Read(currentConfig);

            // ***** DEBUG MSG *****
            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tDisplaying all Shopping lists."); }
            // **   -**#####**-   **

            Menu.DisplayShoppingLists(currentConfig, allShlistMetadata);

            // ***** DEBUG MSG *****
            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tDisplaying main menu."); }
            // **   -**#####**-   **

            string userInput = "";
            while (userInput != "3")
            {
                Menu.DisplayMainMenuCombo(currentConfig);

                // ***** DEBUG MSG *****
                if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGetting user input."); }
                // **   -**#####**-   **

                userInput = Menu.GetRealUserInput(currentConfig, Menu.DisplayMainMenuCombo);

                // ***** DEBUG MSG *****
                if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tChecking user input validity."); }
                // **   -**#####**-   **

                if (userInput != "1" && userInput != "2" && userInput != "3")
                {

                    // ***** DEBUG MSG *****
                    if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tUser input not valid."); }
                    // **   -**#####**-   **


                    // ***** DEBUG MSG *****
                    if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tDisplaying error."); }
                    // **   -**#####**-   **

                    Menu.DisplayOptionError(currentConfig);
                }
                else if (userInput == "1")  // Create new list
                {

                    // ***** DEBUG MSG *****
                    if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tUser wants to create a new list."); }
                    // **   -**#####**-   **


                    // ***** DEBUG MSG *****
                    if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGetting name for new list."); }
                    // **   -**#####**-   **

                    string listNameFromUserInput = Menu.GetListName(currentConfig);

                    // ***** DEBUG MSG *****
                    if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGetting name for shop of new list"); }
                    // **   -**#####**-   **

                    string? shopNameFromUserInput = Menu.GetShopName(currentConfig);

                    // ***** DEBUG MSG *****
                    if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGenerating a new id for list."); }
                    // **   -**#####**-   **

                    string generatedId = ShoppingList.GenerateNewId();

                    // ***** DEBUG MSG *****
                    if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGenerating metadata for the list from gathered information."); }
                    // **   -**#####**-   **

                    ShoppingList.Metadata newListMetadata;
                    if (shopNameFromUserInput == null || shopNameFromUserInput == "")
                    {
                        newListMetadata = new ShoppingList.Metadata(generatedId, listNameFromUserInput);
                    }
                    else
                    {
                        newListMetadata = new ShoppingList.Metadata(generatedId, listNameFromUserInput, shopNameFromUserInput);
                    }

                    // ***** DEBUG MSG *****
                    if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGenerating list content with metadata."); }
                    // **   -**#####**-   **

                    ShoppingList.Content newListContent = new ShoppingList.Content(newListMetadata);
                    string listUserInput = "";
                    while (listUserInput != "3")
                    {

                        // ***** DEBUG MSG *****
                        if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tDisplaying list content."); }
                        // **   -**#####**-   **

                        Menu.DisplayShoppingListContent(currentConfig, newListContent);

                        // ***** DEBUG MSG *****
                        if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tDisplaying user options for adding items / finishing."); }
                        // **   -**#####**-   **

                        Menu.DisplayItemCombo(currentConfig);

                        // ***** DEBUG MSG *****
                        if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGettung user input."); }
                        // **   -**#####**-   **

                        listUserInput = Menu.GetRealUserInput(currentConfig, Menu.DisplayItemCombo);

                        // ***** DEBUG MSG *****
                        if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tChecking user input validity."); }
                        // **   -**#####**-   **

                        if (listUserInput != "1" && listUserInput != "2" && listUserInput != "3")
                        {

                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tUser input not valid."); }
                            // **   -**#####**-   **


                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tDisplaying error."); }
                            // **   -**#####**-   **

                            Menu.DisplayOptionError(currentConfig);
                        }
                        else if (listUserInput == "1")  // add new Item
                        {

                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tUser wants to add a new item to the list."); }
                            // **   -**#####**-   **


                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGetting item name from user."); }
                            // **   -**#####**-   **

                            string newItemName = Menu.GetItemName(currentConfig);

                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGetting quantity for item from user."); }
                            // **   -**#####**-   **

                            int newItemQuantity = Convert.ToInt32(Menu.GetItemQuantity(currentConfig));

                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tGenerating new item based on gathered information."); }
                            // **   -**#####**-   **

                            ShoppingList.Item newItem = new ShoppingList.Item(newItemQuantity, newItemName);

                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tAdding new item to list."); }
                            // **   -**#####**-   **

                            newListContent.AddItem(newItem);
                        }
                        else if (listUserInput == "2")  // remove item
                        {
                            string? userInputSelectedItem = "";
                            while (userInputSelectedItem.ToLower() != "b")
                            {
                                Menu.DisplayShoppingListContent(currentConfig, newListContent);
                                Menu.DisplaySelectItemRequest(currentConfig);
                                userInputSelectedItem = Menu.GetUserInput();
                                userInputSelectedItem ??= "";
                                int userInputSelectedItem_converted = -1;
                                if (int.TryParse(userInputSelectedItem, out userInputSelectedItem_converted))
                                {
                                    if (!(userInputSelectedItem_converted < 0 && userInputSelectedItem_converted >= newListContent.Items.Count))
                                    {
                                        Menu.DisplayWhichItemSelected(currentConfig, userInputSelectedItem_converted);
                                        Menu.DisplayDeleteWarning(currentConfig);
                                        if (Menu.GetYesNoUserInput(currentConfig, Menu.DisplayDeleteWarning))
                                        {
                                            newListContent.RemoveItemIndex(userInputSelectedItem_converted);
                                            break;
                                        }

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
                        else if (listUserInput == "3")  // finish list
                        {

                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tUser wants to finish the list."); }
                            // **   -**#####**-   **


                            // ***** DEBUG MSG *****
                            if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tWriting list to disk."); }
                            // **   -**#####**-   **

                            ShoppingList.Write(currentConfig, newListContent);
                        }
                    }
                }
                else if (userInput == "2")  // select list (show all lists)
                {
                    string? selectUserInput = "";
                    while (selectUserInput.ToLower() != "b")
                    {
                        allShlistMetadata = Shlindex.Read(currentConfig);
                        Menu.DisplayShoppingLists(currentConfig, allShlistMetadata);
                        Menu.DisplaySelectListRequest(currentConfig);
                        selectUserInput = Menu.GetUserInput();
                        selectUserInput ??= "";
                        int userSelectedList_converted = -1;
                        if (int.TryParse(selectUserInput, out userSelectedList_converted))
                        {
                            if (!(userSelectedList_converted < 0 && userSelectedList_converted >= allShlistMetadata.MetadataShlindex.Count))
                            {
                                Menu.DisplayWhichListSelected(currentConfig, userSelectedList_converted);
                                string? userInputAfterSelect = "";
                                while (userInputAfterSelect != "5")
                                {
                                    Menu.DisplayListCombo(currentConfig);
                                    userInputAfterSelect = Menu.GetRealUserInput(currentConfig, Menu.DisplayListCombo);
                                    if (userInputAfterSelect == "1")    // show list content
                                    {

                                        // ***** DEBUG MSG *****
                                        if (Globals.DEBUG) { Console.WriteLine($"DEBUG:\tID: {allShlistMetadata.MetadataShlindex[userSelectedList_converted].Id}"); }
                                        // **   -**#####**-   **

                                        ShoppingList.Content shoppingListToBeDisplayed = ShoppingList.Read(currentConfig, allShlistMetadata.MetadataShlindex[userSelectedList_converted].Id);
                                        if (shoppingListToBeDisplayed.Equals(new ShoppingList.Content()))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Menu.DisplayShoppingListContent(currentConfig, shoppingListToBeDisplayed);
                                        }
                                    }
                                    else if (userInputAfterSelect == "2")   // rename list
                                    {   // Feature cut due to time

                                    }
                                    else if (userInputAfterSelect == "3")   // edit list
                                    {   // Feature cut due to time

                                    }
                                    else if (userInputAfterSelect == "4")   // delete list
                                    {
                                        Menu.DisplayDeleteWarning(currentConfig);
                                        if (Menu.GetYesNoUserInput(currentConfig, Menu.DisplayDeleteWarning))
                                        {
                                            ShoppingList.Remove(currentConfig, allShlistMetadata.MetadataShlindex[userSelectedList_converted].Id);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Menu.DisplayOptionError(currentConfig);
                                    }
                                }
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