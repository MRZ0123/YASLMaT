using System;
using System.Reflection.Metadata.Ecma335;
using Manuel;
using YASLMAT;
using static Manuel.ShoppingList;

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
  }
}