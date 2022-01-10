using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] playField =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        static void Main(string[] args)
        {
            // Our variables
            int player = 1;                 // We starting the do while by flipping the players turn. So player 1 starts.
            int input = 0;                  // The input from the player
            bool validInput = true;         // To check if the player typed a valid input
            char playerTile = 'X';          // The file for the player to set. X or O.
            char[,] initPlayField = playField.Clone() as char[,];  // Take a copy of the playfield at start
            string lastKeyPress = "";

            do
            {
                // Press enter to start the game
                Console.WriteLine("TicTacToe is about to start. Press <ENTER> to start the game");
                Console.WriteLine("You can enter q + enter at anytime during the gameplay to exit the game");
                lastKeyPress = Console.ReadLine().ToLower();

                if (lastKeyPress != "q")
                {
                    Console.Clear();    // Clear the screen on start
                    playField = initPlayField.Clone() as char[,];
                    SetPlayField();     // Set the initial playfield on screen
                }

                while (lastKeyPress != "q")
                {
                    Console.Write("Player {0}: Choose your field: ", player);   // Ask for player input
                    lastKeyPress = Console.ReadLine().ToLower();        // Save the player input to see if the player wants to quit
                    validInput = int.TryParse(lastKeyPress, out input);
                    if (validInput && input > 0 && input < 10)  // Check if it is a valid number and between 1 and 9
                    {
                        if (AvailableTile(input))       // Check if the tile is available before we allow the player to take it
                        {
                            Console.Clear();            // Clear the screen on start
                            SetTile(input, playerTile); // Set the tile on the position the player wanted
                            SetPlayField();             // Update the playfield on screen
                            if (CheckForDraw())         // If it is a draw, exit current while loop
                            {
                                Console.WriteLine("Game is a draw");
                                break;
                            }
                            if (CheckForWin())           // Check if there is a win condition and exit while loop if it is
                            {
                                Console.WriteLine("Player {0} has won!", player);
                                break;
                            }
                            // Flip player and player tile
                            player = (player == 2) ? 1 : 2;
                            playerTile = (playerTile == 'X') ? 'O' : 'X';
                        }
                        else    // If the tile is not available
                        {
                            Console.WriteLine("Tile not available");
                        }

                    }
                    else        // If the player did not input a valid tile number
                    {
                        if (lastKeyPress != "q")
                            Console.WriteLine("Not a valid input. Try again!");
                    }

                };
            } while (lastKeyPress != "q");
        }

        static void SetPlayField()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("");
        }

        // input = 1-9, playTile = X/O
        static void SetTile(int input, char playTile)
        {
            switch (input)
            {
                case 1: playField[0, 0] = playTile; break;
                case 2: playField[0, 1] = playTile; break;
                case 3: playField[0, 2] = playTile; break;
                case 4: playField[1, 0] = playTile; break;
                case 5: playField[1, 1] = playTile; break;
                case 6: playField[1, 2] = playTile; break;
                case 7: playField[2, 0] = playTile; break;
                case 8: playField[2, 1] = playTile; break;
                case 9: playField[2, 2] = playTile; break;
            }
        }

        static bool AvailableTile(int input)    // input = player input 1-9.
        {
            foreach (char num in playField)
            {
                if (num == Convert.ToChar(input.ToString()))    // If it is equal then it must be available, if not it would be an X or O
                    return true; // Return true if tile is available
            }
            return false;   // Return false if the tile is not available
        }

        static bool CheckForWin()   // Check for any wining combinations. There are 8 ways to win.
        {
            if ((playField[0, 0] == playField[0, 1] && playField[0, 1] == playField[0, 2]) ||
                (playField[1, 0] == playField[1, 1] && playField[1, 1] == playField[1, 2]) ||
                (playField[2, 0] == playField[2, 1] && playField[2, 1] == playField[2, 2]) ||
                (playField[0, 0] == playField[1, 0] && playField[1, 0] == playField[2, 0]) ||
                (playField[0, 1] == playField[1, 1] && playField[1, 1] == playField[2, 1]) ||
                (playField[0, 2] == playField[1, 2] && playField[1, 2] == playField[2, 2]) ||
                (playField[0, 0] == playField[1, 1] && playField[1, 1] == playField[2, 2]) ||
                (playField[2, 0] == playField[1, 1] && playField[1, 1] == playField[0, 2])
            )
                return true;    // Return true if there is a win
            return false;       // Return false if there is no win found
        }

        static bool CheckForDraw()
        {
            foreach (char num in playField)
            {
                if (!char.IsLetter(num)) // If there is any numbers left on the playfield the game is stil on and not a draw
                    return false;
            }
            return true;    // Return true if there is a draw
        }
    }
}