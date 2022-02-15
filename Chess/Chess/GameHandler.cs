namespace Chess;

public class GameHandler
{
    public string Turn = "Blue";
    private int enPassentSquare = -555;
    private bool[] _castlePossibiltys = new[] { true, true, true, true};
    public Board PlayerMove(Board board, MoveChecker checker)
    {
        Console.WriteLine($"It is {Turn} time to move enter current cell and the cell you want to move to");
        string[] temp = Console.ReadLine().Split(' ');
        int currentPosition = ConvertCellToInt(temp[0].ToLower());
        int newPosition = ConvertCellToInt(temp[1].ToLower());

        char currentPiece = board.board[currentPosition];

        (bool validMove, bool castle) = CheckMove(currentPiece, newPosition, currentPosition, board, checker);

        if (validMove)
        {
            if (castle == true)
            {
                board.board[currentPosition] = board.board[newPosition];
                board.board[newPosition] = currentPiece;
            }
            else
            {
                board.board[currentPosition] = '\0';
                board.board[newPosition] = currentPiece;
            }

            Turn = Turn == "Blue" ? "Red" : "Blue";
        }
        else
        {
            Console.WriteLine("Invalid move");
        }

        return board;
    }

    private (bool, bool) CheckMove(char currentPiece, int newPosition, int currentPosition, Board board, MoveChecker checker)
    {
        
        bool castle = false;
        bool valid = true;
        valid = checker.BasicCheck(Turn, currentPiece, board.board[newPosition]);
        if (valid == false) return (valid, castle);
        switch (char.ToLower(currentPiece))
        {
            case 'p':
                (valid, enPassentSquare) = checker.PawnCheck(newPosition, currentPosition, Turn, board, enPassentSquare);
                break;
            case 'r':
                valid = checker.RookCheck(currentPosition, newPosition, board);

                if (valid == true)
                {
                    switch (currentPosition)
                    {
                        case 0:
                            _castlePossibiltys[2] = false;
                            break;
                        case 7:
                            _castlePossibiltys[3] = false;
                            break;
                        case 56:
                            _castlePossibiltys[0] = false;
                            break;
                        case 63:
                            _castlePossibiltys[1] = false;
                            break;
                    }
                }
                
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
                (valid, castle )= checker.KingCheck(currentPosition, newPosition, _castlePossibiltys, board);
                switch (valid)
                {
                    case true when Turn == "Blue":
                        _castlePossibiltys[0] = false;
                        _castlePossibiltys[1] = false;
                        break;
                    case true:
                        _castlePossibiltys[2] = false;
                        _castlePossibiltys[3] = false;
                        break;
                }
                enPassentSquare = -555;
                break;
        }
        return (valid, castle);
    }

    private int ConvertCellToInt(string cell)
    {
        return Convert.ToInt32(cell[0]) - 96 + ((Convert.ToInt32(cell[1]) - 48) * 8) - 9;
    }
}