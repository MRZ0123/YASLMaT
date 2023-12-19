using System;
using Manuel;

namespace Team
{
  class Menu
  {
    /** Added by: Jugi
     * 
     * function used to display the commandline menu
     * 
     */
    public static void Display(Config.Content currentConfig)
    {
      Console.WriteLine(currentConfig.Language == "DE" ? "Hauptmenü" : "Main menu");
      Console.WriteLine(currentConfig.Language == "DE" ? "1. Liste erstellen" : "1. Create list");
      Console.WriteLine(currentConfig.Language == "DE" ? "2. Alle vorhandenen Listen anzeigen" : "2. Show existing lists");
      Console.WriteLine(currentConfig.Language == "DE" ? "3. Beenden" : "3. Quit");
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
     * Function DisplayListCreation
     * 
     */
    public static void DisplayListNameQuestion(Config.Content currentConfig)
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
      string? name = GetUserInput();
      while (name == null)
      {
        DisplayNullError(currentConfig);
        DisplayListNameQuestion(currentConfig);
        name = GetUserInput();
      }
      return name;
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


    /** Added by: Sven
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
          // use [i] instead of .elementAt(i) for performance reasons
          ShoppingList.Metadata currentMetadata = index.MetadataShlindex[i];
          Console.WriteLine($"{"(" + i + "):",3}{(currentConfig.Language == "DE" ? "Name: " : "name: ")}{currentMetadata.Name,30}{"; " + (currentMetadata.Shop == "" ? (currentConfig.Language == "DE" ? "Kein Laden spezifiziert." : "no shop specified") : currentMetadata.Shop)}{"; " + (currentConfig.Language == "DE" ? "Artikel: " : "Items: ")}{currentMetadata.FullItemCount}");
        }
      }
    }
  }
}
