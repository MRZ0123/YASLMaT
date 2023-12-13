using System;
using Manuel;
using YASLMAT;

namespace Team
{
  class Menu
  {
    /** Added by: Jugi
     * 
     * function used to display the commandline menu
     * 
     */




/** Added by: Jugi
 * 
 * Function for menu display in English and German
 * 
 */ 
 
 public static void Display(Config.Content currentConfig)
{
  Console.WriteLine(currentConfig.Language == "DE" ? "Hauptmenü" : "Main menu");
  Console.WriteLine(currentConfig.Language == "DE" ? "1. Liste erstellen" : "1. Create list");
  Console.WriteLine(currentConfig.Language == "DE" ? "2. Alle vorhandenen Listen anzeigen" : "2. Show existing lists");
  Console.WriteLine(currentConfig.Language == "DE" ? "3. Beenden" : "3. Quit");


ConsoleKeyInfo taste;
do
{
  taste = Console.ReadKey(false);
  switch (taste.KeyChar)
  {
    case '1':
    Console.WriteLine(currentConfig.Language == "DE" ? "1. Liste erstellen" : "1. Create list");
    
    break;
    case '2':
    Console.WriteLine(currentConfig.Language == "DE" ? "2. Alle vorhandenen Listen anzeigen" : "2. Show existing lists");
    // here function ShowAllList
    break;
    case '3':
    Console.WriteLine(currentConfig.Language == "DE" ? "3. Beenden" : "3. Quit");
    // here function QuitProgram
    break;


  }

}
while (taste.Key != ConsoleKey.Escape);
Console.Write("\nProgramm beendet...");
Console.ReadKey();
}

static void CreateList()
    {
        Console.WriteLine("Automatische ID-Generierung für die Liste:");
        int newId = GenerateUniqueID();

        Console.WriteLine("Geben Sie den Namen der Liste ein:");
        string name = Console.ReadLine();

        // hier weiterarbeiten

    }

  
} 
  
  }