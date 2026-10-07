using System.Data;

namespace Rock_paper_scissors

// Developed in Visual Studio 2022, C# 12.0, .NET 8.0

{
    internal class Program
    {
        static void Main(string[] args)
        {
            // functions

            // this function changes the background and foreground colours of the selected menu item
            void ItemSelectColours()
            // this function changes the background and foreground colours of the selected menu item
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            // this function displays the menu items from a string array and selected index and highlights the selected item
            void DisplayMenu(string[] menuArray, int selectedIndex)
            // this function displays the menu items from a string array and selected index and highlights the selected item
            {
                for (int counter = 0; counter < menuArray.Length; counter++)
                {  //this happens before the menu item is printed             
                    if (counter == selectedIndex)
                    {
                        ItemSelectColours();
                    }
                    Console.Write("  "); //writing the menu item
                    Console.Write(menuArray[counter]);
                    // this happens after the menu item is printed
                    if (counter == selectedIndex)
                    {
                        Console.Write(" ");
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }

            // this function allows the user to navigate the menu using W and S keys and returns the new selected index and isMenu boolean
            (int, bool) MenuNav(int selectedIndex, string[] menuArray, bool isMenu)
            // this TUPLE function changes selected index based on user input and returns the new selected index for menu navigation
            {
                // uses the key pressed not the character
                ConsoleKey userInput = Console.ReadKey(true).Key;

                // switch statement to handle user input for menu navigation
                switch (userInput)
                {
                    case ConsoleKey.W:
                        if (selectedIndex > 0)
                        {
                            selectedIndex--;
                        }
                        isMenu = true;
                        return (selectedIndex, isMenu);

                    case ConsoleKey.S:
                        if (selectedIndex < menuArray.Length - 1)
                        {
                            selectedIndex++;
                        }
                        isMenu = true;
                        return (selectedIndex, isMenu);

                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.ResetColor();
                        isMenu = false;
                        return (selectedIndex, isMenu);

                }
                // returns both the selected index and isMenu boolean to the calling function
                return (selectedIndex, isMenu);
            }

            // this function makes above the menu pretty
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

            // this function makes below the menu pretty
            void MenuBelow()
            // this function makes below the menu pretty
            {
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }

            // this function allows the player to select a menu item from the string array and returns the selected item
            string GetMenuSelection(string[] menuArray, int selectedIndex, bool isMenu)
            // actual menu navigation engine, returns the selected menu item from the string array
            {
                do
                {
                    MenuAbove();
                    DisplayMenu(menuArray, selectedIndex);
                    MenuBelow();
                    (selectedIndex, isMenu) = MenuNav(selectedIndex, menuArray, isMenu);
                    Console.Clear();
                }
                while (isMenu);
                return menuArray[selectedIndex];
            }

            // this function allows the player to select their weapon choice from the rock paper scissors menu and returns the selection
            string PlayerWeaponChoice(string[] rpsArray, int selectedIndex, bool isMenu)
            // allows the player to select their weapon choice from the rock paper scissors menu and returns the selection
            {
                string rpsSelection = GetMenuSelection(rpsArray, selectedIndex, isMenu);
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
                return rpsSelection;
            }

            // this function allows the computer to select a weapon choice from the rock paper scissors menu and returns the selection
            string ComputerWeaponChoice(string[] rpsArray)
            {
                // create a new instance of the Random class
                Random rnd = new Random();

                // computer picks and assigns weapon choice based on random number and string[] rockPaperScissors
                string pcWeaponSelection = rpsArray[rnd.Next(0, 3)];
                return pcWeaponSelection;
            }

            //put the whole rps single player game in to a function and call it from the main menu, including all the previous functions and code to compare the rps outcome and keep score
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

                // variables
                string[] menuItems = new string[4] { "Single Player", "Multiplayer (in development)", "Leaderboard (in development)", "Exit" };
                int selected = 0;
                bool isMenuActive = false;
                string[] rockPaperScissors = new string[4] { "Rock", "Paper", "Scissors", "Exit" };
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
                        Console.WriteLine("You selected Multiplayer");
                        break;

                    case "Choice C":
                        Console.Clear();
                        Console.WriteLine("You selected Leaderboard");
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

