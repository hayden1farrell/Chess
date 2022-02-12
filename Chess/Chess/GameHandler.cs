namespace Chess;

public class GameHandler
{
    public string Turn = "Blue";
    private int enPassentSquare = -555;
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
            board.board[currentPosition] = '\0';
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

    private bool CheckMove(char currentPiece, int newPosition, int currentPosition, Board board)
    {
        MoveChecker checker = new();
        bool valid = true;
        valid = checker.BasicCheck(Turn, currentPiece, board.board[newPosition]);
        Console.Write(valid);
        if (valid == false) return valid;
        switch (char.ToLower(currentPiece))
        {
            case 'p':
                (valid, enPassentSquare) = checker.PawnCheck(newPosition, currentPosition, Turn, board, enPassentSquare);
                break;
            case 'r':
                valid = checker.RookCheck(currentPosition, newPosition, board);
                enPassentSquare = -555;
                break;
            case 'n':
                valid =  checker.KnightCheck(currentPosition, newPosition);
                enPassentSquare = -555;
                break;
            case 'b':
                valid = checker.BishopCheck(currentPosition, newPosition, board);
                enPassentSquare = -555;
                break;
            case 'q':
                valid =  checker.QueenCheck(currentPosition, newPosition, board);
                enPassentSquare = -555;
                break;
            case 'k':
                valid = checker.KingCheck(currentPosition, newPosition);
                enPassentSquare = -555;
                break;
        }
        return valid;
    }

    private int ConvertCellToInt(string cell)
    {
        return Convert.ToInt32(cell[0]) - 96 + ((Convert.ToInt32(cell[1]) - 48) * 8) - 9;
    }
}