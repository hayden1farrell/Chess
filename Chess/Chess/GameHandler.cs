namespace Chess;

public class GameHandler
{
    public string Turn = "Blue";
    
    public void PlayerMove(Board board)
    {
        Console.WriteLine($"It is {Turn} time to move enter current cell and the cell you want to move to");
        string[] temp = Console.ReadLine().Split(' ');
        int currentPosition = ConvertCellToInt(temp[0].ToLower());
        int newPosition = ConvertCellToInt(temp[1].ToLower());

        char currentPiece = board.board[currentPosition];

        bool validMove = CheckMove(currentPiece, newPosition, currentPosition, board);

        if (validMove)
        {
            board.board[currentPosition] = ' ';
            board.board[newPosition] = currentPiece;

            if (Turn == "Blue")
                Turn = "Red";
            else
                Turn = "Blue";
        }
        else
        {
            Console.WriteLine("Invalid move");
        }
    }

    private bool CheckMove(char currentPeice, int newPosition, int currentPosition, Board board)
    {
        MoveChecker checker = new();
        bool valid = true;
        valid = checker.BasicCheck(Turn, currentPeice);
        switch (Char.ToLower(currentPeice))
        {
            case 'p':
                valid = checker.PawnCheck(newPosition, currentPosition, Turn, board);
                break;
            case 'r':
                checker.RookCheck();
                break;
            case 'n':
                checker.KnightCheck();
                break;
            case 'b':
                checker.BishopCheck();
                break;
            case 'q':
                checker.QueenCheck();
                break;
            case 'k':
                checker.KingCheck();
                break;
                
        }

        return valid;
    }

    private int ConvertCellToInt(string cell)
    {
        return Convert.ToInt32(cell[0]) - 96 + ((Convert.ToInt32(cell[1]) - 48) * 8) - 9;
    }
}