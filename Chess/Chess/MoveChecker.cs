namespace Chess;

public class MoveChecker
{
    public bool BasicCheck(string playerToMove, char piece, char newPiece)
    {
        bool valid = false;
        valid  = playerToMove == "Blue" && char.IsUpper(piece) || playerToMove == "Red" && char.IsLower(piece);
        if (newPiece != '\0' && valid == true)
        {
            if (playerToMove == "Blue" && char.IsUpper(newPiece) == true && (newPiece != 'N' && piece != 'K'))
                valid = false;
            else if (playerToMove == "Red" && char.IsLower(newPiece) == true && (newPiece != 'n' && piece != 'k'))
                valid = false;
        }
        return valid;
    }

    public (bool, int) PawnCheck(int newPosition, int currentPosition, string turn, Board board, int enPassentSquares)
    {
        bool enPassent = false;
        bool valid = true;
        int offset = 0;
        if (turn == "Blue")
            offset = -8;
        else
            offset = 8;

        if (board.board[newPosition] == '\0') // if the square is empty
        {
            if (currentPosition + offset != newPosition)
                valid =  false;
            if(currentPosition is >= 8 and <= 15 or >= 48 and <= 55)
                if (currentPosition + offset * 2 == newPosition)
                {
                    enPassentSquares = newPosition - offset;
                    enPassent = true;
                    valid = true;
                }

            if (newPosition == enPassentSquares)
            {
                board.board[enPassentSquares - offset] = '\0';
                valid = true;
            }
        }
        else   // if the square has a piece 
        {
            valid = false;
            if (turn == "Blue")
            {
                if (board.board[currentPosition - 7] != '\0' || board.board[currentPosition - 9] != '\0')
                    valid = true;
            }
            else
            {
                if (board.board[currentPosition + 7] != '\0' || board.board[currentPosition + 9] != '\0')
                    valid = true;
            }
        }

        if (enPassent == false)
            enPassentSquares = -555;
        
        return (valid, enPassentSquares);
    }
    
    private bool SimpleMoverCheck(int currentPosition, int newPosition, Board board, int[] offsets)
    {
        foreach (int direction in offsets)
        {
            int tempPostion = currentPosition;
            while (tempPostion >= 0 && tempPostion <= board.board.Length - 1)
            {
                tempPostion += direction;
                if(tempPostion is >= 63 or < 0)
                    break;
                if (tempPostion == newPosition)
                    return true;
                if (board.board[tempPostion].ToString() != "\0")
                    break;
            }
        }

        return false;
    }

    public bool RookCheck(int currentPosition, int newPosition, Board board)
    {
        int[] offsets = {-1, 8, 1, -8}; // left, up, right, down
        return SimpleMoverCheck(currentPosition, newPosition, board, offsets);
    }

    public bool BishopCheck(int currentPosition, int newPostion, Board board)
    {
        int[] offsets = {7, 9, -7, -9}; // left, up, right, down
        return SimpleMoverCheck(currentPosition, newPostion, board, offsets);
    }

    public bool QueenCheck(int currentPosition, int newPostion, Board board)
    {
        int[] offsets = {-1, 8, 1, -8, 7, 9, -7, -9};
        return SimpleMoverCheck(currentPosition, newPostion, board, offsets);
    }

    public (bool, bool) KingCheck(int currentPosition, int newPosition, bool[] casstleChances, Board board)
    {
        int[] offsets = {1, 7, 8, 9, -1, -7, -8, -9};
        foreach (int direction in offsets)
        {
            if (currentPosition + direction == newPosition)
                return (true, false);
        }

        int[] casstleMoves = new[] {-4, 3, -4, -3};
        if (board.board[newPosition] == 'n' || board.board[newPosition] == 'N')
        {
            for (int i = 0; i < casstleMoves.Length; i++)
            {
                int offset = casstleMoves[i];
                if (currentPosition + casstleMoves[i] == newPosition && casstleChances[i] == true)
                {
                    int inverseOffset = offset * -1;
                    List<int> inbetweenSquares = new List<int>();
                    for (i = newPosition; i != currentPosition; i += Math.Clamp(inverseOffset, -1, 1))
                    {
                        inbetweenSquares.Add(i);
                    }

                    inbetweenSquares.RemoveAt(inbetweenSquares.Count - 1);
                    inbetweenSquares.RemoveAt(0);

                    foreach (int squareNumber in inbetweenSquares)
                    {
                        if (board.board[squareNumber] != '\0')
                            return (false, false);
                    }

                    return (true, true);
                }
            }        
        }

        return (false, false);
    }

    public bool KnightCheck(int currentPosition, int newPosition)
    {
        int[] offsets = {15, 17, 6, 10, -6, -10, -15, -17};
        return offsets.Any(direction => currentPosition + direction == newPosition);
    }
}