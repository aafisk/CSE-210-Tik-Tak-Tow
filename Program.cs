class TicTacToe
{
    static void Main(string[] args)
    {

        Board board = new Board();
        string currentPlayer = "x";

        while (!IsGameOver(board))
        {
            board.print();

            int choice = GetMoveChoice(currentPlayer);
            MakeMove(board, choice, currentPlayer);

            currentPlayer = GetNextPlayer(currentPlayer);
        }

        board.print();
        Console.WriteLine("Good game. Thanks for playing!");
    }

    /// <summary>
    /// Determines if the game is over because of a win or a tie.
    /// </summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the game is over</returns>
    static bool IsGameOver(List<string> board)
    {
        bool isGameOver = false;
        
        if(IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
        {
            isGameOver = true;
        }

        return isGameOver;
    }

    /// <summary>Determines if the provided player has a tic tac toe.</summary>
    /// <param name="board">The current board</param>
    /// <param name="player">The player to check for a win</param>
    /// <returns></returns>
    static bool IsWinner(List<string> board, string player)
    {
        //horizontal win
        if (board[0] == player && board[1] == player && board[2] == player)  
        {
            return true;
        } else if (board[3] == player && board[4] == player && board[5] == player) 
        {
            return true;
        } else if (board[6] == player && board[7] == player && board[8] == player)
        {
            return true;
        
        // Vertical win
        } else if (board[0] == player && board[3] == player && board[6] == player) 
        {
            return true;
        } else if (board[1] == player && board[4] == player && board[7] == player) 
        {
            return true;
        } else if (board[2] == player && board[5] == player && board[8] == player) 
        {
            return true;
        
        // Diagonal win
        } else if (board[0] == player && board[4] == player && board[8] == player) 
        {
            return true;
        } else if (board[2] == player && board[4] == player && board[6] == player) 
        {
            return true;
        } else 
        {
            return false;
        }
    }

    /// <summary>Determines if the board is full with no more moves possible.</summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the board is full.</returns>
    static bool IsTie(List<string> board)
    {
        foreach (string value in board) 
        {
            if (char.IsDigit(value[0]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>Cycles through the players (from x to o and o to x)</summary>
    /// <param name="currentPlayer">The current players sign (x or o)</param>
    /// <returns>The next players sign (x or o)</returns>
    static string GetNextPlayer(string currentPlayer)
    {
        if (currentPlayer == "x")
        {
            return "o";
        } else if (currentPlayer == "o")
        {
            return "x";
        } else {
            return "x";
        }
    }

    /// <summary>Gets the 1-based spot number associated with the user's choice.</summary>
    /// <param name="currentPlayer">The sign (x or o) of the current player.</param>
    /// <returns>A 1-based spot number (not a 0-based index)</returns>
    static int GetMoveChoice(string currentPlayer)
    {
        Console.WriteLine($"{currentPlayer}'s turn to choose a square (1-9): ");
        string playerChoice = Console.ReadLine() ?? "";
        int choice = int.Parse(playerChoice);
        return choice;
    }

    /// <summary>
    /// Places the current players mark on the board at the desired spot.
    /// This method does NOT check to ensure the spot is available.
    /// </summary>
    /// <param name="board">The current board</param>
    /// <param name="choice">The 1-based spot number (not a 0-based index).</param>
    /// <param name="currentPlayer">The current player's sign (x or o)</param>
    static void MakeMove(List<string> board, int choice, string currentPlayer)
    {
        board[choice - 1] = currentPlayer;
    }
}
