using System;
using Manuel;
using Sven;

namespace Jugi
{
  class Menu
  {
    /** Added by: Jugi
     * 
     * function used to display the commandline menu
     * 
     */
    private static void Display(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Hauptmenü" : "Main menu");
      Console.WriteLine(currentConfig.Language == "DE" ? "1. Liste erstellen" : "1. Create list");
      Console.WriteLine(currentConfig.Language == "DE" ? "2. Eine vorhandene Liste auswählen" : "2. Select an existing list");
      Console.WriteLine(currentConfig.Language == "DE" ? "3. Beenden" : "3. Quit");
    }


    /** Added by: Jugi
     * 
     * function used to display select options
     * 
     */
    public static void DisplaySelect(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte wähle eine Liste aus (Zahl)" : "Please select a list (number)");
    }


    /** Added by: Jugi
     * 
     * Function to capture user input
     * 
     */
    public static ConsoleKeyInfo GetUserKeyInput()
    {
      return Console.ReadKey(false);
    }


    /** Added by: Jugi
     * 
     * Function to display null error
     * 
     */
    public static void DisplayNullError(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Dieses Feld muss ausgefüllt sein!" : "This column must be filled out!");
    }


    /** Added by: Jugi
     * 
     * function to display option error
     * 
     */
    public static void DisplayOptionError(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte benutzen Sie eine der angezeigten Optionen!" : "Please use one of the displayed options!");
    }


    /** Added by: Jugi
     * 
     * function to display file missing error
     * 
     */
    public static void DisplayFileMissingError(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "## ERROR: Eine Datei, welche eigentlich existieren sollte ist nicht da." : "## ERROR: Some file that should exists doesn't actually exist.");
    }


    /** Added by: Jugi
     * 
     * function used to ask for deletion in shlindex
     * 
     */
    public static void DisplayShlindexOnlyDeleteQuestion(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Diese Einkaufsliste existiert nicht in dem Einkaufslistenordner. Möchten Sie diese aus der Index Datei löschen? (y/n):" : "This shopping list doesn't exist in the shopping list directory. Do you want to delete it from the index file? (y/n)");
    }


    /** Added by: Jugi
     * 
     * Function DisplayListCreation
     * 
     */
    private static void DisplayListNameQuestion(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte geben Sie einen Namen für die Einkaufsliste ein:" : "Please enter a name for the shopping list:");
    }


    /** Added by: Jugi
     * 
     * Function to ask for shop name
     * 
     */
    public static void DisplayShopQuestion(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "(Optional) Bitte geben Sie einen Laden ein:" : "(optional) Please enter the name of the shop:");
    }


    /** Added by: Jugi
     * 
     * Function to get user input as string
     * 
     */
    public static string? GetUserInput()
    {
      return Console.ReadLine();
    }

    /** Added by: Jugi
     * 
     * Function to get list name from user input
     * 
     */
    public static string GetListName(Config.Content currentConfig)
    {
      DisplayListNameQuestion(currentConfig);
      return GetRealUserInput(currentConfig, DisplayListNameQuestion);
    }


    /** Added by: Jugi
     * 
     * function to ask for shopping list selection
     * 
     */
    public static void DisplaySelectListRequest(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte wählen Sie eine Liste aus oder schreiben Sie b um zurück zu kommen" : "Please select a list or type b to go back");
    }


    /** Added by: Jugi
     * 
     * function to ask for item selection
     * 
     */
    public static void DisplaySelectItemRequest(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte wählen Sie einen Artikel aus oder schreiben Sie b um zurück zu kommen" : "Please select an item or type b to go back");
    }


    /** Added by: Jugi
     * 
     * Function to get shop name from user input
     * 
     */
    public static string? GetShopName(Config.Content currentConfig)
    {
      DisplayShopQuestion(currentConfig);
      return GetUserInput();
    }


    /** Added by: Jugi
     * 
     * function to display a request for a choice from the user
     * 
     */
    public static void DisplayChoiceRequest(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte wählen Sie eine Option (1-3):" : "Please choose an option (1-3):");
    }


    /** Added by: Jugi
     * 
     * function to display a request for a choice from the user
     * 
     */
    private static void DisplayChoiceRequestFive(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte wählen Sie eine Option (1-5):" : "Please choose an option (1-5):");
    }


    /** Added by: Jugi
     * 
     * function used to display delete warning
     * 
     */
    public static void DisplayDeleteWarning(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Möchten Sie das wirklich löschen? (y/n)" : "Do you really want to delete this? (y/n)");
    }


    /** Added by: Jugi
     * 
     * function to display option when a list is selected
     * 
     */
    private static void DisplayListOptions(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "1. Listeninhalt anzeigen" : "1. Show list content");
      // Console.WriteLine(currentConfig.Language == "DE" ? "2. Liste umbenennen" : "2. Rename list");
      // Console.WriteLine(currentConfig.Language == "DE" ? "3. Liste bearbeiten" : "3. edit list");
      Console.WriteLine(currentConfig.Language == "DE" ? "4. Liste löschen" : "4. delete list");
      Console.WriteLine(currentConfig.Language == "DE" ? "5. Zurück" : "5. Back");
    }


    /** Added by: Jugi
     * 
     * function to combo selected options and request
     * 
     */
    public static void DisplayListCombo(Config.Content currentConfig)
    {
      DisplayListOptions(currentConfig);
      DisplayChoiceRequestFive(currentConfig);
    }


    /** Added by: Jugi
     * 
     * function to display which list is selected
     * 
     */
    public static void DisplayWhichListSelected(Config.Content currentConfig, int listNumber)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? $"Sie haben Liste Nummer {listNumber} ausgewählt" : $"You have selected list number {listNumber}");
    }


    /** Added by: Jugi
     * 
     * function to display which Item is selected
     * 
     */
    public static void DisplayWhichItemSelected(Config.Content currentConfig, int itemNumber)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? $"Sie haben Artikel Nummer {itemNumber} ausgewählt" : $"You have selected item number {itemNumber}");
    }


    /** Added by: Jugi
     * 
     * Function to display combo
     * 
     */
    public static void DisplayMainMenuCombo(Config.Content currentConfig)
    {
      Display(currentConfig);
      DisplayChoiceRequest(currentConfig);
    }


    /** Added by: Jugi
     * 
     * function to get a yes or no from user
     * 
     */
    public static bool GetYesNoUserInput(Config.Content currentConfig, Action<Config.Content> DisplayFunction)
    {
      int failureCount = 0;
      string? userInput = GetUserInput();
      userInput ??= "";
      while (userInput.ToLower() != "y" && userInput.ToLower() != "n")
      {
        failureCount += 1;
        DisplayOptionError(currentConfig);
        DisplayFunction(currentConfig);
        userInput = GetUserInput();
      }
      if (userInput.ToLower() == "y")
      {
        return true;
      }
      else
      {
        return false;
      }
    }


    /** Added by: Jugi
     * 
     * fuction used to get and return userinput but catch empty or null
     * 
     */
    public static string GetRealUserInput(Config.Content currentConfig, Action<Config.Content> DisplayFunction)
    {
      int nullOrEmptyFailCount = 0;
      string? userInput = GetUserInput();
      while (userInput == null || userInput == "")
      {
        nullOrEmptyFailCount += 1;
        DisplayNullError(currentConfig);
        DisplayFunction(currentConfig);
        userInput = GetUserInput();
      }
      return userInput;
    }


    /** Added by: Jugi
     * 
     * function used to display an entire shopping list with item name and quantity
     * 
     */
    public static void DisplayShoppingListContent(Config.Content currentConfig, ShoppingList.Content shlistContent)
    {
      Console.WriteLine($"{(currentConfig.Language == "DE" ? "Liste: " : "list: ")}{shlistContent.Metadata.Name,30}{"; " + (shlistContent.Metadata.Shop == "" ? (currentConfig.Language == "DE" ? "Kein Laden spezifiziert." : "no shop specified") : shlistContent.Metadata.Shop)}{"; " + (currentConfig.Language == "DE" ? "Artikel: " : "Items: ")}{shlistContent.Metadata.FullItemCount}");
      if (shlistContent.Items.Count > 0) { Console.WriteLine(); }
      for (int i = 0; i < shlistContent.Items.Count; i++)
      {
        // use [i] instead of .elementAt(i) for performance reasons
        ShoppingList.Item currentItem = shlistContent.Items[i];
        Console.WriteLine($"({i + "): ",6}{(currentConfig.Language == "DE" ? "Artikel: " : "Item: ")}{currentItem.ItemName,-30}{(currentConfig.Language == "DE" ? "Menge: " : "amount: ")}{currentItem.ItemCount,-5}");
      }
    }


    /** Added by: Jugi
     *
     * Function to display name, shops and number of items from lists
     * 
     */
    public static void DisplayShoppingLists(Config.Content currentConfig, Shlindex.Content index)
    {
      if (index.MetadataShlindex.Count == 0)
      {
        Console.WriteLine(currentConfig.Language == "DE" ? "Es wurden noch keine Einkaufslisten erstellt." : "No shopping lists have been created.");
      }
      else
      {
        for (int i = 0; i < index.MetadataShlindex.Count; i++)
        {
          ShoppingList.Metadata currentMetadata = index.MetadataShlindex[i];
          Console.WriteLine($"{$"({i + "): ",6}{(currentConfig.Language == "DE" ? "Name: " : "name: ")}{currentMetadata.Name,30}{"; " + (currentMetadata.Shop == "" ? (currentConfig.Language == "DE" ? "Kein Laden spezifiziert." : "no shop specified") : currentMetadata.Shop)}",-80}{(currentConfig.Language == "DE" ? "Artikel: " : "Items: ")}{currentMetadata.FullItemCount}");
        }
      }
    }


    /** Added by: Jugi
      * 
      * Function to ask for item name
      * 
      */
    private static void DisplayItemNameQuestion(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte geben Sie einen Artikel ein:" : "Please enter a shopping item:");
    }


    /** Added by: Jugi
      * 
      * Function to ask for items' quantity
      * 
     */
    private static void DisplayItemQuantityQuestion(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Bitte geben Sie die Anzahl des Artikels ein:" : "Please enter the quantity of your shopping item:");
    }


    /** Added by: Jugi
     * 
     * Function to get item name from user input
     * 
     */
    public static string GetItemName(Config.Content currentConfig)
    {
      DisplayItemNameQuestion(currentConfig);
      return GetRealUserInput(currentConfig, DisplayItemNameQuestion);
    }


    /** Added by: Jugi
    * 
    * Function to get items' quantity from user input
    * 
    */
    public static string GetItemQuantity(Config.Content currentConfig)
    {
      DisplayItemQuantityQuestion(currentConfig);
      return GetRealUserInput(currentConfig, DisplayItemQuantityQuestion);
    }


    /** Added by: Jugi
      * 
      * Function to display item options
      * 
     */
    private static void DisplayItemOptionQuestion(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "1. Neuer Artikel hinzufügen" : "1. Add new item");
      Console.WriteLine(currentConfig.Language == "DE" ? "2. Artikel entfernen" : "2. Delete Item");
      Console.WriteLine(currentConfig.Language == "DE" ? "3. Fertigstellen" : "3. Finish");
    }


    /** Added by: Jugi
     * 
     * Function to display combo for items
     * 
     */
    public static void DisplayItemCombo(Config.Content currentConfig)
    {
      DisplayItemOptionQuestion(currentConfig);
      DisplayChoiceRequest(currentConfig);
    }
  }
}
