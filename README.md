# Terminal TicTacToe

TicTacToe for terminal<br>
Just a simple version of the Tic Tac Toe game<br>

## Screenshot
![Screenshot](https://soltveit.org/files/tictactoe.png)

## About the game

The Main is a bit messy, but it was done quickly for a programming exercise.<br>

However there are some interesting parts.<br>

The playfield is stored as a 2D array. That was part of the exercise.<br>
```
static char[,] playField =
{
    {'1','2','3'},
    {'4','5','6'},
    {'7','8','9'}
};
```

To place the tiles I just do a simple switch to check for which tile the player wants and just put in a X or O there.<br>
```
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
```

To check if the tile is available for the player to take I have this method.<br>
```
static bool AvailableTile(int input)    // input = player input 1-9.
{
    foreach (char num in playField)
    {
        if (num == Convert.ToChar(input.ToString()))    // If it is equal then it must be available
            return true; // Return true if tile is available
    }
    return false;   // Return false if the tile is not available
}
```

To check if there is a win I am checking all 8 winning combinations manually. It is probably the worst if statement I have ever made. So for each of the combinations I check the first tile with the second tile, then I check the second tile with the third tile. If they are equal there must be a win. It doesn't matter if the tiles are X or O. The current player when the win is happening is the winner.<br>
```
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
```

To check if it is a draw I just check if there is any numbers left in the 2d array. If there is no more numbers that means all tiles are X and O and without a winning combination it must be a draw.<br>
```
static bool CheckForDraw()
{
    foreach (char num in playField)
    {
        if (!char.IsLetter(num)) // If there is any numbers left on the playfield the game is stil on and not a draw
            return false;
    }
    return true;    // Return true if there is a draw
}
```

