using System.Data;

namespace Rock_paper_scissors

// Developed in Visual Studio 2022, C# 12.0, .NET 8.0

{
    internal class Program
    {
        static void Main(string[] args)
        {
            // functions

            // changes the background and foreground colours of the selected menu item
            void ItemSelectColours()
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            // displays the menu items from a string array and selected index and highlights the selected item
            void DisplayMenu(string[] menuArray, int selectedIndex)
            {
                // variables
                int counter;

                // this for loop iterates through the menu items and displays them, highlighting the selected item
                for (counter = 0; counter < menuArray.Length; counter++)
                {  //this happens before the menu item is printed             
                    if (counter == selectedIndex) // if the counter is equal to the selected index, change the background and foreground colours of the selected menu item
                    {
                        ItemSelectColours();
                    }
                    Console.Write("  "); //writing the menu item selected by the user with a space before it for formatting
                    Console.Write(menuArray[counter]);
                    // this happens after the menu item is printed, printing a space after the selected item and resetting the colours to default
                    if (counter == selectedIndex)
                    {
                        Console.Write(" ");
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }

            // allows the user to navigate the menu using W and S keys and returns the new selected index and isMenu boolean for menu navigation
            (int, bool) MenuNav(int selectedIndex, string[] menuArray, bool isMenu)
            {
                // uses the key pressed not the character
                ConsoleKey userInput = Console.ReadKey(true).Key;

                // switch statement to handle user input for menu navigation
                switch (userInput)
                {
                    case ConsoleKey.W: // if the user presses W, move the selected index up, but not below 0
                        if (selectedIndex > 0)
                        {
                            selectedIndex--;
                        }
                        isMenu = true;
                        return (selectedIndex, isMenu);

                    case ConsoleKey.S: // if the user presses S, move the selected index down, but not above the length of the menu array
                        if (selectedIndex < menuArray.Length - 1)
                        {
                            selectedIndex++;
                        }
                        isMenu = true;
                        return (selectedIndex, isMenu);

                    case ConsoleKey.Enter: // if the user presses Enter, exit the menu and return the selected index and isMenu boolean to select the item in the menu
                        Console.Clear();
                        Console.ResetColor();
                        isMenu = false;
                        return (selectedIndex, isMenu);

                }
                // returns both the selected index and isMenu boolean to the calling function
                return (selectedIndex, isMenu);
            }

            // makes above the menu pretty
            void MenuAbove()
            // This function makes above the menu pretty
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("              Menu              ");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ResetColor();
                Console.WriteLine("Use W and S to navigate the menu");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine();
            }

            // makes below the menu pretty
            void MenuBelow()
            // this function makes below the menu pretty
            {
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }

            // allows the player to select a menu item from the string array and returns the selected item
            string GetMenuSelection(string[] menuArray, int selectedIndex, bool isMenu)
            // actual menu navigation engine, returns the selected menu item from the string array
            {
                do
                {
                    MenuAbove();
                    DisplayMenu(menuArray, selectedIndex);
                    MenuBelow();
                    (selectedIndex, isMenu) = MenuNav(selectedIndex, menuArray, isMenu); // calls the MenuNav function to get the new selected index and isMenu boolean for menu navigation
                    Console.Clear();
                }
                while (isMenu);
                return menuArray[selectedIndex]; // returns the selected menu item from the string array
            }

            // allows the player to select their weapon choice from the rock paper scissors menu and returns the selection
            string PlayerWeaponChoice(string[] rpsArray, int selectedIndex, bool isMenu)
            {
                string rpsSelection = GetMenuSelection(rpsArray, selectedIndex, isMenu); // calls the GetMenuSelection function to get the selected weapon choice from the rock paper scissors menu
                switch (rpsSelection)
                {
                    case "Rock":
                        Console.Clear();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("You selected Rock");
                        Console.WriteLine();
                        Console.ResetColor();
                        break;
                    case "Paper":
                        Console.Clear();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("You selected Paper");
                        Console.WriteLine();
                        Console.ResetColor();
                        break;
                    case "Scissors":
                        Console.Clear();
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("You selected Scissors");
                        Console.WriteLine();
                        Console.ResetColor();
                        break;
                    case "Exit":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("Exiting...");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.ResetColor();
                        break;

                }
                return rpsSelection; // returns the selected weapon choice from the rock paper scissors menu
            }

            // allows the computer to select a weapon choice from the rock paper scissors menu and returns the selection
            string ComputerWeaponChoice(string[] rpsArray)
            {
                // create a new instance of the Random class
                Random rnd = new Random();

                // computer picks and assigns weapon choice based on random number and string[] rockPaperScissors
                string pcWeaponSelection = rpsArray[rnd.Next(0, 3)];
                return pcWeaponSelection;
            }

            // has the whole rps single player game including all the previous functions and code to compare the rps outcome and keep score
            void SinglePlayerGame(string[] rpsArray, int selectedIndex, bool isMenu)
            {

                bool runRPS = true;
                int myScore = 0;
                int pcScore = 0;

                while (runRPS)
                {
                    Console.Clear();

                    string weaponSelection = PlayerWeaponChoice(rpsArray, selectedIndex, isMenu);

                    string pcWeaponSelection = ComputerWeaponChoice(rpsArray);

                    Console.WriteLine("Computer selected " + pcWeaponSelection);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                    // determine winner by comparing weaponSelection and pcWeaponSelection
                    if (weaponSelection == pcWeaponSelection)
                    {
                        Console.WriteLine();
                        ItemSelectColours();
                        Console.WriteLine("~~~~~~~~~~~~~~");
                        Console.WriteLine(" It's a tie!  ");
                        Console.WriteLine("~~~~~~~~~~~~~~");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("My score: " + myScore + " " + "Computer Score: " + pcScore);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else if ((weaponSelection == "Rock" && pcWeaponSelection == "Scissors") ||
                             (weaponSelection == "Paper" && pcWeaponSelection == "Rock") ||
                             (weaponSelection == "Scissors" && pcWeaponSelection == "Paper"))
                    {
                        Console.WriteLine();
                        ItemSelectColours();
                        Console.WriteLine("~~~~~~~~~~~~~~");
                        Console.WriteLine("   You win!   ");
                        Console.WriteLine("~~~~~~~~~~~~~~");
                        myScore++;
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine();
                        VictoryBeep();
                        Console.WriteLine("My score: " + myScore + " " + "Computer Score: " + pcScore);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else if (weaponSelection == "Exit")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Thank you for playing. Press any key to exit");
                        Console.ResetColor();
                        runRPS = false;

                    }
                    else
                    {
                        Console.WriteLine();
                        ItemSelectColours();
                        Console.WriteLine("~~~~~~~~~~~~~~~~");
                        Console.WriteLine(" Computer wins! ");
                        Console.WriteLine("~~~~~~~~~~~~~~~~");
                        pcScore++;
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("My score: " + myScore + " " + "Computer Score: " + pcScore);
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                    }
                }

            }

            // can be used to play a victory beep sound when the player wins
            void VictoryBeep()
            {
                    // Define notes for victory beeps
                    int[] frequencies = { 494, 440, 494 }; // B, A, B
                    int[] durations = { 400, 400, 800 }; // Durations in ms

                // Loop through the notes, uses the same index for both arrays so both arrays must have the same number of things in them
                for (int index = 0; index < frequencies.Length; index++) 
                {
                        Console.Beep(frequencies[index], durations[index]);
                    }
             }

                // variables
                string[] menuItems = { "Single Player", "Multiplayer", "Settings", "Exit" };
                int selected = 0;
                bool isMenuActive = false;
                string[] rockPaperScissors = { "Rock", "Paper", "Scissors", "Exit" };
                string mainMenuSelection;

                // config
                Console.CursorVisible = false;

                // main code
                mainMenuSelection = GetMenuSelection(menuItems, selected, isMenuActive);
                switch (mainMenuSelection)
                {
                    case "Single Player":
                    SinglePlayerGame(rockPaperScissors, selected, isMenuActive);
                    break;

                    case "Multiplayer":
                        Console.Clear();
                        Console.WriteLine("You selected Multiplayer, this is still in development. Press any key to Exit");
                        break;

                    case "Settings":
                        Console.Clear();
                        Console.WriteLine("You selected Settings, this is still in development. Press any key to Exit");
                        break;

                    case "Exit":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Thank you for playing, press any key to exit");
                        Console.ResetColor();
                        break;
                }






            }
        }
    }

